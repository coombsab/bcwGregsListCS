<template>
  <div class="details" v-if="classified">

    <div class="col-10 m-auto" v-if="classified.listingType == 'Car'">

      <CarCard :car="classified.listing" :seller="classified.seller" :classifiedId="classified.id"/>
    </div>
    <div class="col-10 m-auto" v-else-if="classified.listingType == 'House'">

      <HouseCard :house="classified.listing" :seller="classified.seller" :classifiedId="classified.id" />
    </div>
    <div class="col-10 m-auto" v-else-if="classified.listingType == 'Job'">

      <JobCard :job="classified.listing" :seller="classified.seller" :classifiedId="classified.id" />
    </div>
    <div>{{classified.listingType}}</div>

  </div>
  <div v-else>
    loading...
  </div>
</template>

<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState.js';
import CarCard from '../components/CarCard.vue';
import { classifiedsService } from '../services/ClassifiedsService.js';
import Pop from '../utils/Pop.js';
import HouseCard from "../components/HouseCard.vue";
import JobCard from "../components/JobCard.vue";

export default {
  setup() {
    const route = useRoute();
    const router = useRouter();
    async function getClassifiedById() {
      try {
        console.log("id: ", route.params.id)
        await classifiedsService.getClassifiedById(route.params.id);
      }
      catch (error) {
        Pop.error("Sorry that listing no longer exists", "[GettingClassified]");
        router.push({ name: "Home" });
      }
    }
    onMounted(() => {
      getClassifiedById();
    });
    return {
      classified: computed(() => AppState.activeClassified)
    };
  },
  components: { CarCard, HouseCard, JobCard }
}
</script>
