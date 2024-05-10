<template>
    <div v-show="isLoaderShowed" class="flex justify-center items-center">
        <div class="fixed top-0 left-0 h-full w-full bg-black z-10 opacity-90"></div>
        <div class="z-20">
	        <img src="/cat_loading.gif" alt="Loading..." class="rounded-lg"/>
        </div>
    </div>
</template>

<script setup>
    import { ref, watch } from 'vue'

    const props = defineProps({
        isLoading: {
            type: Boolean,
            default: false
        },
        delay: {
            type: Number,
            default: 3000
        }
    });

    const isLoaderShowed = ref(false);

    watch(() => props.isLoading, (newVal) => {
        if (newVal) {
            showLoader();
            return;
        }

        setTimeout(() => {
            hideLoader();
        }, props.delay);
    }, { immediate: true });

    const showLoader = () => {
        isLoaderShowed.value = true;
    }

    const hideLoader = () => {
        isLoaderShowed.value = false;
    }
</script>