<template>
	<div class="relative bg-white border border-slate-100 rounded-3xl p-8 cursor-pointer hover:-translate-y-2 hover:shadow-xl transition">
		<router-link :to="{name: 'Good', params: { id: id}}">
			<img :src="imageURL" alt="/empty_good.png" width="250" />
			<p class="mt-2">{{name}}</p>
			<div class="flex justify-between mt-5">
				<div class="flex flex-col">
					<span class="text-slate-400">Цена: </span>
					<b>{{price}} руб.</b>
				</div>
			</div>
		</router-link>
	</div>
</template>

<script setup>
	defineProps({
		id: String,
		name: String,
		imageURL: String,
		price: Number
	})
</script>