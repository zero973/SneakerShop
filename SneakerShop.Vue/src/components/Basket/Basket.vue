<template>
	<div class="fixed top-0 left-0 h-full w-full bg-black z-10 opacity-70"></div>
	<div class="bg-white w-96 h-full fixed right-0 top-0 z-20 p-8">
		<div class="flex items-center gap-5 mb-5">
			<img @click="() => emit('toggleBasket')" src="/src/assets/icons/arrow-left.png" class="opacity-30 cursor-pointer hover:opacity-100 hover:-translate-x-1 transition" />
			<h2 class="text-2xl font-bold">Корзина</h2>
		</div>

		<div v-if="cartIsEmpty" class="flex h-full items-center">
			<InfoBlock title="Корзина пустая" description="Добавьте хотя бы один товар, чтобы сделать заказ." image-url="/empty_basket.png" />
		</div>

		<div v-else class="flex flex-col gap-4" v-auto-animate>
			<BasketItem v-for="element in basket" :key="element.id" :id="element.id"
				:name="element._Good.name" :imageURL="element._Good.imageURL" :price="element._Good.price" :size="element._Size.name" />

			<div class="flex flex-col gap-4 my-7">
				<div class="flex gap-2">
					<span>Итого:</span>
					<div class="flex-1 border-b border-dashed"></div>
					<b>12990 руб.</b>
				</div>
			</div>

			<button @click="onClickMakeOrder"
				class="bg-lime-500 w-full rounded-xl py-3 text-white hover:bg-lime-600 active:bg-lime-700 cursor-pointer transition">
				Оформить заказ
			</button>
		</div>
	</div>
</template>

<script setup>
	import { ref, computed, inject } from 'vue'
	import axios from 'axios'

	import BasketItem from './BasketItem.vue'
	import InfoBlock from '../Info/InfoBlock.vue'

	const props = defineProps({
		basket: Array
	});

	const emit = defineEmits(['toggleBasket']);

	const cartIsEmpty = computed(() => props.basket.length === 0)

	const onClickMakeOrder = () => {
		alert("qwe");

		// очистка корзины. Проверить, что в App.vue она тоже очищается
		for (let i = 0; i < props.basket.length; i++)
			props.basket.pop();
	}

</script>