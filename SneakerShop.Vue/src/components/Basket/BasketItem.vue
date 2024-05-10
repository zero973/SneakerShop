<template>
	<div class="flex items-center border border-slate-200 p-4 rounded-xl gap-4">
		<img class="w-16 h-16" :src="imageURL"/>
		<div class="flex flex-col">
			<p>{{name}}. Размер: {{size}}</p>
			<div class="flex justify-between mt-2">
				<b>{{price}} руб.</b>
				<img @click="onDeleteBasketElement" class="opacity-40 hover:opacity-100 cursor-pointer transition" src="/src/assets/icons/close.png" />
			</div>
		</div>
	</div>
</template>

<script setup>
	import { inject } from 'vue';
	import axios from 'axios';
	import BasketElement from '../../models/Entities/BasketElement';

	const props = defineProps({
		id: String,
		name: String,
		imageURL: String,
		price: Number,
		size: String
	});

	const fetchBasket = inject('fetchBasket');

	const onDeleteBasketElement = () => {
		const element = new BasketElement(props.id);
		axios.post('/api/Basket/Delete', { element });

		fetchBasket();
	}
</script>