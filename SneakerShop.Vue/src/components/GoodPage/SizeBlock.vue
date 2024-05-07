<template>
	<div class="">
		<input type="radio" :id="id" :value="name" />
		<label :for="id">{{Name}}</label>
	</div>
</template>

<script setup>
	defineProps({
		id: String,
		name: String
	})
</script>