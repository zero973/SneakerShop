<template>
	<div class="relative">
		<CatLoading :isLoading="isLoading" :delay="3000"/>
		<div class="grid grid-cols-3 gap-10">
			<img :src="good.ImageURL" alt="/empty_good.png" />

			<div class="grid grid-cols-1">
				<p class="text-sm">{{good.GoodTypeName}} - {{good.GoodSubtypeName}}</p>
				<b class="">{{good.Name}}</b>
				<p class="">Цена: {{good.Price}} руб.</p>
				<p class="">Размеры:</p>
				<div class="grid grid-cols-4 gap-5" v-auto-animate>
					<div v-for="size in good.Sizes" class="">
						<input v-model="choosedSize" type="radio" :key="size.id" :id="size.id" :value="size.Name" />
						<label :for="size.Id">{{size.Name}}</label>
					</div>
				</div>
				<button @click="onClickAddToBasket"
						class="bg-lime-500 w-auto rounded-xl py-3 text-white hover:bg-lime-600 active:bg-lime-700 cursor-pointer transition">
					{{constAddToBasketButtonText}}
				</button>
				<p class="mt-8">{{good.Description}}</p>
			</div>

			<div class="relative">
				<img :src="good.Manufacturer.ImageURL" alt="/empty_good.png" width="100" class="" />
				<h3 class="">{{good.Manufacturer.Name}}</h3>
			</div>
		</div>
	</div>
</template>

<script setup>
	import { ref, onMounted, computed } from 'vue'
	import { useRoute } from 'vue-router'
	import axios from 'axios'
	import CatLoading from '../components/Info/CatLoading.vue'
	import BaseListParams from '../models/BaseListParams';
	import ComplexFilter from '../models/ComplexFilter';
	import { ComplexFilterOperators } from '../models/Enums/ComplexFilterOperators';
	import Good from '../models/Entities/Good';
	import Manufacturer from '../models/Entities/Manufacturer';
	import Size from '../models/Entities/Size';
	import AppUser from '../models/Auth/AppUser';
	import BasketElement from '../models/Entities/BasketElement';
	import { isEmpty } from '../extensions/Extensions';

	const route = useRoute();
	const isLoading = ref(false);

	const good = ref(new Good(1, "", "", new Manufacturer(1, "", "", ""), "", 0, "", "", [new Size(1, "")]));
	const choosedSize = ref({});
	const basketElement = ref({});
	const isAddedToCart = computed(() => !isEmpty(basketElement.value));

	const constAddToBasketButtonText = computed(() => {
		if (!isAddedToCart.value)
			return 'Добавить в корзину';
		else
			return 'Удалить из корзины';
	});

	async function fetchGood() {
		isLoading.value = true;

		try {
			// загружаем информацию о товаре
			const params = new BaseListParams(-1, -1, {}, []);

			params.Filters = [new ComplexFilter('Id', ComplexFilterOperators.Equals, route.params.id)];

			params.Filters = JSON.stringify(params.Filters);
			const { data } = await axios.get('/api/Goods/Get', { params });

			// загружаем размеры товара
			params.Filters = [
				new ComplexFilter('GoodSubtypeId', ComplexFilterOperators.Equals, data.data._GoodSubtype.id),
				new ComplexFilter('IsActual', ComplexFilterOperators.Equals, true)
			];

			params.Filters = JSON.stringify(params.Filters);
			let sizes = [];
			await axios.get('/api/Sizes/GetAll', { params }).then(x => sizes = x.data.data);

			const manufacturer = new Manufacturer(data.data._Manufacturer.id,
				data.data._Manufacturer.name,
				data.data._Manufacturer.description,
				data.data._Manufacturer.imageURL);

			good.value = new Good(data.data.id,
				data.data._GoodSubtype._GoodType.name,
				data.data._GoodSubtype.name,
				manufacturer,
				data.data.name,
				data.data.price,
				data.data.description,
				data.data.imageURL,
				sizes);

			// проверяем, есть ли этот товар в корзине
			params.Filters = [
				new ComplexFilter('GoodId', ComplexFilterOperators.Equals, route.params.id),
				new ComplexFilter('IsActual', ComplexFilterOperators.Equals, true)
			];

			params.Filters = JSON.stringify(params.Filters);
			await axios.get('/api/Basket/GetAll', { params }).then(x => {
				if (x.data.data != undefined && x.data.data.length > 0) {
					basketElement.value = x.data.data[0];
				}
			});
		}
		catch (err) {
			console.error(err);
		}

		isLoading.value = false;
	}

	async function addOrRemoveFromBasket() {
		// проверить, что пользователь авторизован
		const params = new BaseListParams(-1, -1, {}, []);

		const filter = new ComplexFilter('Id', ComplexFilterOperators.Equals, route.params.id);
		params.Filters.push(filter);

		const currentUser = ref(new AppUser(undefined, undefined, undefined));

		await axios.get('/api/Autification/GetCurrentUser')
			.then(x => {
				if (x.data != null && x.data.data != null)
					currentUser.value = new AppUser(x.data.data.id, x.data.data.login, x.data.data.roles)
			})
			.catch(x => console.error(x));

		if (currentUser.value.isAuthorized()) {
			if (isAddedToCart.value) {
				const params = new BasketElement(basketElement.value.Id);
				await axios.post('/api/Basket/Delete', params);
				basketElement.value = {};
			}
			else {
				const params = new BasketElement();
				await axios.post('/api/Basket/Add', params)
					.then(x => {
						// todo можно так оставить или надо через конструктор делать "new BasketElement(...)" ?
						basketElement.value = x.data.data;
					})
					.catch(x => console.error(x));
			}
		}
	}

	onMounted(() => {
		fetchGood();
	});

	const onClickAddToBasket = () => {
		addOrRemoveFromBasket();
	}

</script>