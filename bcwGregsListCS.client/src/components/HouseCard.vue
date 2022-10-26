<template>
  <div class="card">
    <router-link :to="{ name: 'Details', params:{ id: classifiedId }}">
     <img class="rounded-top img-fluid" :src="house.imgUrl" alt="House">
    </router-link>
    <div class="card-body d-flex justify-content-between align-items-center">
      <div>
        <h5>{{house.bedrooms}} bedroom {{house.bathrooms}} bathroom {{house.levels}} story house</h5>
        <h4>${{house.price}}</h4>
        <p>{{house.description}}</p>
      </div>
      <div class="align-items-center d-flex gap-2">
        <img :src="seller.picture" :alt="seller.name" :title="seller.name" height="30" class="rounded">
        <i class="mdi mdi-delete-forever fs-4 selectable rounded" @click="$emit('deleteClassified')"
          v-if="account.id == seller.id"></i>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { House } from "../models/House.js";
import { SellerProfile } from "../models/SellerProfile.js";

export default {
  props: {
    house: { type: House, required: true },
    seller: { type: SellerProfile, required: true },
    classifiedId: { type: Number }
  },
  setup(props) {
    
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped lang="scss">
  
</style>