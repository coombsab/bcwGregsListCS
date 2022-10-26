<template>
  <form @submit.prevent="handleSubmit">

    <div>
      <label for="listingType" class="me-2">What are you Selling?</label>
      <select name="listingType" v-model="editable.listingType">
        <option value="Car">🚗</option>
        <option value="Job">💼</option>
        <option value="House">🏠</option>
      </select>
    </div>


    <div v-if="editable.listingType == 'Car'">
      <div class="form-group">
        <label for="make">Make:</label>
        <input type="text" v-model="editable.listing.make" placeholder="Make" required class="form-control">
      </div>
      <div class="form-group">
        <label for="model">Model:</label>
        <input type="text" v-model="editable.listing.model" placeholder="Model" required class="form-control">
      </div>
      <div class="form-group">
        <label for="url">ImgUrl:</label>
        <input type="url" v-model="editable.listing.imgUrl" placeholder="https://youknow.com" class="form-control">
      </div>
      <div class="form-group">
        <label for="price">Price:</label>
        <input type="number" v-model="editable.listing.price" placeholder="Price" required class="form-control" min="0">
      </div>
      <div class="form-group">
        <label for="year">Year:</label>
        <input type="number" v-model="editable.listing.year" placeholder="Year" required class="form-control" min="1886"
          :max="new Date().getFullYear() + 1">
      </div>
      <div class="form-group">
        <label for="description">Description:</label>
        <textarea v-model="editable.listing.description" placeholder="description" class="form-control"
          rows="4"></textarea>
      </div>
    </div>

    <div v-else-if="editable.listingType == 'Job'">
      <div class="form-group">
        <label for="company">Company:</label>
        <input type="text" v-model="editable.listing.company" placeholder="Company" required class="form-control">
      </div>
      <div class="form-group">
        <label for="jobTitle">Job Title:</label>
        <input type="text" v-model="editable.listing.jobTitle" placeholder="Job Title" required class="form-control">
      </div>
      <div class="form-group">
        <label for="hours">Hours:</label>
        <input type="number" v-model="editable.listing.hours" placeholder="Hours" required class="form-control" min="0" max="80">
      </div>
      <div class="form-group">
        <label for="rate">Rate:</label>
        <input type="number" v-model="editable.listing.rate" placeholder="Rate" required class="form-control" min="0">
      </div>
      <div class="form-group">
        <label for="description">Description:</label>
        <textarea v-model="editable.listing.description" placeholder="description" class="form-control"
          rows="4"></textarea>
      </div>
    </div>

    <div v-else-if="editable.listingType == 'House'">
      <div class="form-group">
        <label for="bathrooms">Bathrooms:</label>
        <input type="number" v-model="editable.listing.bathrooms" placeholder="Bathrooms" required class="form-control" min="0">
      </div>
      <div class="form-group">
        <label for="bedrooms">Bedrooms:</label>
        <input type="number" v-model="editable.listing.bedrooms" placeholder="Bedrooms" required class="form-control" min="0">
      </div>
      <div class="form-group">
        <label for="levels">Levels:</label>
        <input type="number" v-model="editable.listing.levels" placeholder="Levels" required class="form-control" min="0">
      </div>
      <div class="form-group">
        <label for="price">Price:</label>
        <input type="number" v-model="editable.listing.price" placeholder="Price" required class="form-control" min="0">
      </div>
      <div class="form-group">
        <label for="Year">Year:</label>
        <input type="number" v-model="editable.listing.year" placeholder="Year" required class="form-control" min="0">
      </div>
      <div class="form-group">
        <label for="url">ImgUrl:</label>
        <input type="url" v-model="editable.listing.imgUrl" placeholder="https://youknow.com" class="form-control">
      </div>
      <div class="form-group">
        <label for="description">Description:</label>
        <textarea v-model="editable.listing.description" placeholder="description" class="form-control"
          rows="4"></textarea>
      </div>
    </div>


    <div class="my-3" v-if="editable.listingType">
      <button class="btn btn-success" type="submit">SEND IT</button>
    </div>


  </form>
</template>


<script>
import { ref } from 'vue';
import { classifiedsService } from '../services/ClassifiedsService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const editable = ref({
      listing: {}
    })
    return {
      editable,
      async handleSubmit() {
        try {
          const formData = editable.value
          await classifiedsService.createClassified(formData)
          editable.value = {
            listing: {}
          }
        } catch (error) {
          Pop.error(error, '[Submitting Form]')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>
