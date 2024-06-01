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
	import BaseListParams from './models/BaseListParams'
	import ComplexFilter from './models/ComplexFilter'
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
			const { data } = await axios.get('/api/Authentication/GetCurrentUser');

			if (data.data != null) {
				const userId = data.data.id;

				//todo удалить, т.к. это чисто для теста
				const params = new BaseListParams(1, 10, {}, []); // todo добавить пагинацию

				params.Filters = [
					new ComplexFilter('UserId', ComplexFilterOperators.Equals, userId),
					new ComplexFilter('IsActual', ComplexFilterOperators.Equals, true)
				];

				params.Filters = JSON.stringify(params.Filters);
				await axios.get('/api/Basket/GetAll', { params }).then(x => {
          if (x.data.data != null)
					  basket.value = x.data.data;
				});
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