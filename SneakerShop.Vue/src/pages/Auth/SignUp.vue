<template>
	<div class="flex flex-col gap-4">
		<h1 class="flex items-center text-center mx-auto my-5 text-2xl">Регистрация</h1>
		<h1 v-if="errorMessage.length > 0" class="flex items-center text-center mx-auto text-md text-red-600">{{errorMessage}}</h1>
		<div class="flex items-center text-center mx-auto">
			<p>Логин:</p>
			<input v-model="login" class="border rounded-md mx-2 py-1 pl-5 pr-1 outline-none focus:border-gray-400" type="text" placeholder="Логин" />
		</div>
		<div class="flex items-center text-center mx-auto">
			<p>Пароль:</p>
			<input v-model="password" class="border rounded-md mx-2 py-1 pl-5 pr-1 outline-none focus:border-gray-400" type="password" placeholder="Пароль" />
		</div>
		<div class="flex items-center text-center mx-auto">
			<p>Email:</p>
			<input v-model="email" class="border rounded-md mx-2 py-1 pl-5 pr-1 outline-none focus:border-gray-400" type="email" placeholder="qwe@mail.ru" />
		</div>
		<div class="flex items-center text-center mx-auto">
			<p>Имя:</p>
			<input v-model="firstName" class="border rounded-md mx-2 py-1 pl-5 pr-1 outline-none focus:border-gray-400" type="text" placeholder="Имя" />
		</div>
		<div class="flex items-center text-center mx-auto">
			<p>Фамилия:</p>
			<input v-model="lastName" class="border rounded-md mx-2 py-1 pl-5 pr-1 outline-none focus:border-gray-400" type="text" placeholder="Фамилия" />
		</div>
		<div class="flex items-center text-center mx-auto my-5">
			<button @click="onClickSignUp" class="bg-gray-900 w-auto h-auto p-2 rounded-xl text-white hover:bg-gray-500 cursor-pointer transition">Зарегистрироваться</button>
		</div>
	</div>
</template>

<script setup>
	import { ref } from 'vue'
	import axios from 'axios'
	import RegistrationModel from '../../models/Auth/RegistrationModel';

	const errorMessage = ref('');
	const login = ref('');
	const password = ref('');
	const email = ref('');
	const firstName = ref('');
	const lastName = ref('');

	async function signUp() {
		errorMessage.value = '';
		const params = new RegistrationModel(login.value, password.value, firstName.value, lastName.value, email.value);
		await axios.post('/api/Authentication/SignUp', params)
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

	const onClickSignUp = () => {
		signUp();
	}

</script>