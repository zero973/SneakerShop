<template>
	<div class="">
		<h1 class="">Настройки</h1>
		<p class="">Id: {{currentUser.Id}}</p>
		<p class="">Логин: {{currentUser.Login}}</p>
		<p class="">Роли: {{currentUser.Roles}}</p>
	</div>
</template>

<script setup>
	import { ref, onMounted } from 'vue'
	import axios from 'axios'
	import AppUser from '../models/Auth/AppUser';

	const currentUser = ref(new AppUser(undefined, undefined, undefined));

	async function fetchUserData() {
		await axios.get('/api/Autification/GetCurrentUser')
			.then(x => {
				if (x.data != null && x.data.data != null)
					currentUser.value = new AppUser(x.data.data.id, x.data.data.userName, x.data.data.roles)
			})
			.catch(x => console.error(x));
	}

	onMounted(() => {
		fetchUserData();
	});
</script>