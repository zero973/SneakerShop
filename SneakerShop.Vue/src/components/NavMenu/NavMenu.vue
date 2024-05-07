<template>
	<header class="flex justify-between border-b border-slate-300 px-8">
		<router-link to="/">
			<div class="flex items-center gap-4">
				<img src="/src/assets/icons/logo.png" alt="Logo" width="100" class="m-2 rounded-md" />
				<div>
					<h2 class="text-xl font-bold uppercase">Sneaker Shop</h2>
					<p class="text-slate-400">Лучший магазин кроссовок и не только !</p>
				</div>
			</div>
		</router-link>

		<div class="flex items-center gap-10">
			<div @click="() => emit('toggleBasket')" class="flex items-center gap-3 text-gray-500 rounded-xl cursor-pointer hover:shadow-xl">
				<img src="/src/assets/icons/cart.svg" />
				<b>{{totalBasketPrice}} руб.</b>
			</div>
			<div class="flex items-center gap-3 text-gray-500 rounded-xl cursor-pointer hover:shadow-xl">
				<router-link to="/orders">
					<img src="/src/assets/icons/order.svg" class="w-10" />
					<span>Заказы</span>
				</router-link>
			</div>
			<div class="relative">
				<div @click="toggleDropdownMenu" class="flex items-center gap-3 text-gray-500 rounded-xl cursor-pointer hover:shadow-xl">
					<img src="/src/assets/icons/profile.svg" />
					<span>Профиль</span>
					<DropdownProfileMenu v-if="isOpenDropdownMenu" :isAuthorized="isAuthorized" :isWorker="isWorker"/>
				</div>
			</div>
		</div>
	</header>
</template>

<script setup>
	import { ref, reactive, onMounted, watch, provide, computed } from 'vue'
	import axios from 'axios'

	import DropdownProfileMenu from './DropdownProfileMenu.vue'
	import AppUser from '../../models/Auth/AppUser';
	import { UsersRoles } from '../../models/Enums/UsersRoles';

	const currentUser = ref(new AppUser(undefined, undefined, undefined));

	const isOpenDropdownMenu = ref(false);

	const isAuthorized = computed(() => {
		return currentUser.value.isAuthorized();
	});
	const isWorker = computed(() => {
		if (currentUser.value.isAuthorized())
			return currentUser.value.isInRole(UsersRoles.Admin);
		return false;
	});

	defineProps({
		totalBasketPrice: Number
	});

	const emit = defineEmits(['toggleBasket']);

	const toggleDropdownMenu = () => {
		isOpenDropdownMenu.value = !isOpenDropdownMenu.value;
		axios.get('/api/Autification/GetCurrentUser')
			.then(x => {
				if (x.data != null && x.data.data != null)
					currentUser.value = new AppUser(x.data.data.id, x.data.data.login, x.data.data.roles)
			})
			.catch(x => console.error(x));
	}

</script>