<template>
	<div class="relative">
		<CatLoading :isLoading="isLoading" :delay="1500"/>
		<div class="grid grid-cols-3 gap-10">
			<img :src="good.ImageURL" alt="/empty_good.png" />

			<div class="">
				<p class="text-sm">{{good.GoodTypeName}} - {{good.GoodSubtypeName}}</p>
				<p class="mt-5">{{good.Name}}</p>
				<p class="mt-5">Цена: {{good.Price}} руб.</p>
				<p class="mt-5">Размеры:</p>
				<p v-if="errorMessage.length > 0" class="mt-5 text-md text-red-600">{{errorMessage}}</p>
				<div class="grid grid-cols-4 gap-5 pt-5" v-auto-animate>
					<div v-for="size in good.Sizes" class="rounded-md border border-slate-500">
						<input v-model="choosedSize" type="radio" :key="size.id" :id="size.id" :value="size.id" class="ml-1" />
						<label :for="size.id" class="mx-1">{{size.name}}</label>
					</div>
				</div>
				<button @click="onClickAddToBasket"
						class="bg-lime-500 w-auto rounded-xl py-3 px-3 mt-5 text-white hover:bg-lime-600 active:bg-lime-700 cursor-pointer transition">
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
	import { ref, onMounted, computed, inject } from 'vue'
	import { useRoute } from 'vue-router'
	import axios from 'axios'
	import { Guid } from 'js-guid';
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
	const errorMessage = ref('');

	const good = ref(new Good(1, "", "", new Manufacturer(1, "", "", ""), "", 0, "", "", [new Size(1, "")]));
	const choosedSize = ref({});
	const basketElement = ref({});
	const isAddedToCart = computed(() => !isEmpty(basketElement.value));

	const fetchBasket = inject('fetchBasket');

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
					currentUser.value = new AppUser(x.data.data.id, x.data.data.userName, x.data.data.roles)
			})
			.catch(x => console.error(x));

		if (currentUser.value.isAuthorized()) {
			if (isAddedToCart.value) {
				const data = new BasketElement(basketElement.value.id);
				await axios.post('/api/Basket/Delete', { data });
				basketElement.value = {};
				fetchBasket();
			}
			else {
				if (isEmpty(choosedSize.value)) {
					errorMessage.value = 'Выберите размер !';
					return;
				}
				const data = new BasketElement(Guid.EMPTY, route.params.id, choosedSize.value, currentUser.value.Id, null, 1);
				await axios.post('/api/Basket/Add', { data })
					.then(x => {
						// todo можно так оставить или надо через конструктор делать "new BasketElement(...)" ?
						basketElement.value = x.data.data;
					})
					.catch(x => console.error(x));
				fetchBasket();
			}
		}
		else {
			window.location.href = "/login";
		}
	}

	onMounted(() => {
		fetchGood();
	});

	const onClickAddToBasket = () => {
		addOrRemoveFromBasket();
	}

</script>