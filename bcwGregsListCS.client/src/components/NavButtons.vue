<template>
  <div class="d-flex justify-content-center align-items-center gap-3">
          <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
            <div class="text-center" v-if="route.name !== 'Home'">
              <h3>🏠📄</h3>
            </div>
          </router-link>
          
          <button class="btn text-light" @click="getClassifieds('Car')">
            <h3 class="m-0">🚗</h3>
          </button>
          <button class="btn text-light" @click="getClassifieds('Job')">
            <h3 class="m-0">💼</h3>
          </button>
          <button class="btn text-light" @click="getClassifieds('House')">
            <h3 class="m-0">🏘️</h3>
          </button>
        </div>
</template>

<script>
import { useRoute } from "vue-router";
import { classifiedsService } from "../services/ClassifiedsService.js";

export default {

  setup() {
    const route = useRoute()
    
    return {
      route,
      async getClassifieds(filter) {
        try {
          await classifiedsService.getClassifieds(filter)
        }
        catch(error) {
          logger.log('error', error)
          Pop.error(error.message)
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
  
</style>