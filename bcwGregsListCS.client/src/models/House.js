

export class House {
  constructor(data) {
    this.id = data.id
    this.bedrooms = data.bedrooms
    this.bathrooms = data.bathrooms
    this.imgUrl = data.imgUrl || "https://images.unsplash.com/photo-1619379104123-51f1de307c56?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1936&q=80"
    this.levels = data.levels
    this.price = data.price
    this.year = data.year
    this.description = data.description
  }
}