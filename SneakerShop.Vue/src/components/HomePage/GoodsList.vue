<template>
	<div class="grid grid-cols-4 gap-5" v-auto-animate>
		<MainMenuGood v-for="good in goods" :key="good.id" :id="good.id" :name="good.name" :imageURL="good.imageUrl" :price="good.price"/>
	</div>
</template>

<script setup>
	import { inject } from 'vue'
	import MainMenuGood from './MainMenuGood.vue'

	defineProps({
		goods: Array
	})

</script>

<style scoped>

</style>