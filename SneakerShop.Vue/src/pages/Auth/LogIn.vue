<template>
	<div class="flex flex-col gap-4">
		<h1 class="flex items-center text-center mx-auto my-5 text-2xl">Вход</h1>
		<h1 v-if="errorMessage.length > 0" class="flex items-center text-center mx-auto text-md text-red-600">{{errorMessage}}</h1>
		<div class="flex items-center text-center mx-auto">
			<p>Логин:</p>
			<input v-model="login" class="border rounded-md mx-2 py-1 pl-5 pr-1 outline-none focus:border-gray-400" type="text" placeholder="Логин" />
		</div>
		<div class="flex items-center text-center mx-auto">
			<p>Пароль:</p>
			<input v-model="password" class="border rounded-md mx-2 py-1 pl-5 pr-1 outline-none focus:border-gray-400" type="password" placeholder="Пароль" />
		</div>
		<div class="flex items-center text-center mx-auto my-5">
			<button @click="onClickLogIn" class="bg-gray-500 w-auto h-auto p-2 rounded-xl text-white hover:bg-gray-900 cursor-pointer transition">Войти</button>
		</div>
	</div>
</template>

<script setup>
	import { ref } from 'vue'
	import axios from 'axios'
	import LoginModel from '../../models/Auth/LoginModel';

	const errorMessage = ref('');
	const login = ref('');
	const password = ref('');

	async function logInUser() {
		errorMessage.value = '';
		const params = new LoginModel(login.value, password.value);
		await axios.post('/api/Autification/LogIn', params)
			.then(x => {
				if (x.data.isSuccess == true) {
					// redirect to last page
					history.go(-1);
				}
				else {
					errorMessage.value = x.data.message;
				}
			}).catch(e => console.error(e));
	}

	const onClickLogIn = () => {
		logInUser();
	}
</script>