import { AppState } from "../AppState.js"
import { Classified } from "../models/Classified.js"
import { api } from "./AxiosService.js"

class ClassifiedsService {

  async getClassifieds(filter = null) {
    const res = await api.get('api/classifieds', {
      params: {
        listingType: filter
      }
    })
    // NOTE alternative method of filtering
    // if (filter) {
    //   AppState.classifieds = res.data.map(c => new Classified(c)).filter(c => c.listingType === filter)
    // } else {
    //   AppState.classifieds = res.data.map(c => new Classified(c))
    // }
    AppState.classifieds = res.data.map(c => new Classified(c))

  }


  async deleteClassified(id) {
    const res = await SandboxApi.delete(`api/classifieds/${id}`)
    // CAKE SAUCE strawberry middle 🍓
    AppState.classifieds = AppState.classifieds.filter(c => c.id != id)

  }

  async getClassifiedById(id) {
    const res = await SandboxApi.get(`/api/classifieds/${id}`)
    AppState.activeClassified = new Classified(res.data) // Not a POJO!!!
    console.log("ACTIVE CLASSIFIED", AppState.activeClassified)
  }


  async createClassified(formData) {
    const res = await api.post('/api/classifieds', formData)
    AppState.classifieds.push(new Classified(res.data))
    // AppState.classifieds = [...AppState.classifieds, new Classified(res.data)]
  }


}

export const classifiedsService = new ClassifiedsService()
