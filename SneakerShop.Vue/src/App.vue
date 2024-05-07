<template>
	<div class="bg-white w-4/5 m-auto rounded-xl shadow-xl mt-14">
		<NavMenu :totalBasketPrice="totalBasketPrice" @toggleBasket="toggleBasket"/>
		<Basket v-if="isBasketOpen" @toggleBasket="toggleBasket" :basket="basket" />
		<div class="p-10">
			<RouterView />
		</div>
	</div>
</template>

<script setup>
	import { ref, reactive, onMounted, watch, provide, computed } from 'vue'
	import axios from 'axios'

	import NavMenu from './components/NavMenu/NavMenu.vue'
	import Basket from './components/Basket/Basket.vue'
	import HomePage from './pages/Home.vue'
	import { ComplexFilterOperators } from './models/Enums/ComplexFilterOperators'

	// КОРЗИНА
	const basket = ref([]);
	const isBasketOpen = ref(false);

	const totalBasketPrice = computed(() => {
		if (basket.value.length > 0)
			basket.value.reduce((acc, item) => acc + item.price)
		else
			return 0;
	});

	async function fetchBasket() {
		try {
			const { userData } = await axios.get('/api/Autification/GetCurrentUser');

			if (userData != undefined) {
				const userId = userData.data.id;

				//todo удалить, т.к. это чисто для теста
				const params = new BaseListParams(1, 10, {}, []); // todo добавить пагинацию

				params.OrderBy['name'] = true;

				const filter = new ComplexFilter('UserId', ComplexFilterOperators.Equals, userId);
				params.Filters['UserId'] = filter;

				const actualFilter = new ComplexFilter('IsActual', ComplexFilterOperators.Equals, true);
				params.Filters.push(actualFilter);

				params.Filters = JSON.stringify(params.Filters);
				const { data } = await axios.get('/api/Basket/GetActualEntities', { params });
				basket.value = data.data;
			}
		}
		catch (err) {
			console.error(err);
		}
	}

	onMounted(() => {
		fetchBasket();
	});

	provide('fetchBasket', fetchBasket);

	const toggleBasket = () => {
		// если открываем крозину
		if (!isBasketOpen)
			fetchBasket();
		isBasketOpen.value = !isBasketOpen.value;
	}

</script>