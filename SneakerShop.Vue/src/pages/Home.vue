<template>
	<div class="flex justify-between items-center">
		<div class="flex items-center gap-2">
			<b>Выберите тип товара:</b>
			<select @change="onChangeGoodSubtypeSelect" class="py-2 px-3 border rounded-md outline-none">
				<option value="all">Все</option>
				<option v-for="subtype in goodsSubtypes" :value="subtype.value">
					{{ subtype.text }}
				</option>
			</select>
		</div>

		<div class="flex gap-4">
			<select @change="onChangeSortSelect" class="py-2 px-3 border rounded-md outline-none">
				<option value="name">По названию</option>
				<option value="price">По цене (дешевые)</option>
				<option value="-price">По цене (дорогие)</option>
			</select>

			<div class="relative">
				<img src="/src/assets/icons/search.svg" class="absolute left-3 top-3 size-5" />
				<input @input="onChangeSearchInput" class="border rounded-md py-2 pl-11 pr-4 outline-none focus:border-gray-400" type="text" placeholder="Поиск..." />
			</div>
		</div>
	</div>

	<div class="mt-10">
		<GoodsList :goods="goods" />
	</div>
</template>

<script setup>
	import { ref, reactive, onMounted, watch, provide } from 'vue'
	import axios from 'axios'
	import { debounce } from 'lodash'

	import GoodsList from '../components/HomePage/GoodsList.vue'
	import BaseListParams from '../models/BaseListParams.js'
	import ComplexFilter from '../models/ComplexFilter.js'
	import { ComplexFilterOperators } from '../models/Enums/ComplexFilterOperators.js'

	const goodsSubtypes = ref([]);
	const goods = ref([]);

	const filters = reactive({
		goodSubtype: 'all', // todo достать из контроллера
		sortBy: 'name',
		goodName: ''
	});

	async function fetchGoodsSubtypes() {
		try {
			const params = new BaseListParams(1, 100, {}, []); // todo добавить пагинацию

			params.OrderBy['name'] = true;

			const filter = new ComplexFilter('IsActual', ComplexFilterOperators.Equals, true);
			params.Filters.push(filter);

			params.Filters = JSON.stringify(params.Filters);
			const { data } = await axios.get('/api/GoodSubtypes/GetAll', { params });
			goodsSubtypes.value = data.data.map((x) => ({
				value: x.id,
				text: x.name
			}));
		}
		catch (err) {
			console.error(err);
		}
	}

	async function fetchGoods() {
		try {
			const params = new BaseListParams(1, 10, {}, []); // todo добавить пагинацию

			switch (filters.sortBy) {
				case 'name': params.OrderBy['name'] = true; break;
				case 'price': params.OrderBy['price'] = true; break;
				case '-price': params.OrderBy['price'] = false; break;
			}

			if (filters.goodName) {
				const filter = new ComplexFilter('Name', ComplexFilterOperators.Contains, filters.goodName);
				params.Filters.push(filter);
			}

			if (filters.goodSubtype != 'all') {
				const filter = new ComplexFilter('GoodSubtypeId', ComplexFilterOperators.Equals, filters.goodSubtype);
				params.Filters.push(filter);
			}

			const actualFilter = new ComplexFilter('IsActual', ComplexFilterOperators.Equals, true);
			params.Filters.push(actualFilter);

			params.Filters = JSON.stringify(params.Filters);
			const { data } = await axios.get('/api/Goods/GetAll', { params });
			goods.value = data.data;
		}
		catch (err) {
			console.error(err);
		}
	}

	onMounted(() => {
		fetchGoodsSubtypes();
		fetchGoods();
	});
	watch(filters, fetchGoods);

	const onChangeGoodSubtypeSelect = (event) => {
		filters.goodSubtype = event.target.value;
	}

	const onChangeSortSelect = (event) => {
		filters.sortBy = event.target.value;
	}

	const onChangeSearchInput = debounce((event) => {
		filters.goodName = event.target.value;
	}, 1000)
</script>