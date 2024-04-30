<template>
	<ul class="bg-white divide-y divide-black-500 h-auto rounded-xl shadow-xl p-5 absolute top-full left-0 z-50">
		<li v-if="!isAuthorized" class="cursor-pointer"><router-link to="/login">Войти</router-link></li>
		<li v-if="!isAuthorized" class="cursor-pointer"><router-link to="/signup">Зарегистрироваться</router-link></li>
		<li v-if="isWorker" class="cursor-pointer"><router-link to="/work">Работа</router-link></li>
		<li v-if="isAuthorized" class="cursor-pointer"><router-link to="/settings">Настройки</router-link></li>
		<li v-if="isAuthorized" @click="onClickSignOut" class="cursor-pointer">Выйти</li>
	</ul>
</template>

<script setup>
	import { ref } from 'vue'
	import axios from 'axios'

	defineProps({
		isAuthorized: Boolean,
		isWorker: Boolean
	});

	async function signOut() {
		try {
			await axios.post('/api/Autification/SignOut');
			window.location.href = "/";
		}
		catch (err) {
			console.error(err);
		}
	}

	const onClickSignOut = () => {
		signOut();
	}

</script>