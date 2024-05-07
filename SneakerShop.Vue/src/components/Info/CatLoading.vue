<template>
    <div v-if="isShowElement" class="flex justify-center items-center">
		<div class="fixed top-0 left-0 h-full w-full bg-black z-10 opacity-90"></div>
		<div class="z-20">
			<img src="/cat_loading.gif" alt="Loading..." />
		</div>
	</div>
</template>

<script setup>
	import { ref, computed, watch } from 'vue'
	import { debounce } from 'lodash'

	const props = defineProps({
		isLoading: Object,
		delay: Number
	});

	const isShowElement = ref(true);

	const hideElement = debounce(() => {
		isShowElement.value = false;
	}, props.delay);

	watch(props.isLoading, hideElement);
</script>