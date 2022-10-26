namespace bcwGregsListCS.Models;

public class Listing {
  // All
  public int Id { get; set; }
  public string Description { get; set; }
  public int ClassifiedId { get; set; }
  public ListingType ListingType { get; set; }

  // Car and House
  public int Year { get; set; }
  public decimal Price { get; set; }
  public string ImgUrl { get; set; }

  // Car
  public string Make { get; set; }
  public string Model { get; set; }

  // House
  public int Bedrooms { get; set; }
  public int Bathrooms { get; set; }
  public int Levels { get; set; }

  // Job
  public string JobTitle { get; set; }
  public string Company { get; set; }
  public decimal Rate { get; set; }
  public int Hours { get; set; }

  public Listing() {
    
  }

  public Listing(Car car) {
    Id = car.Id;
    Description = car.Description;
    Year = car.Year;
    Price = car.Price;
    ImgUrl = car.ImgUrl;
    Make = car.Make;
    Model = car.Model;
    ClassifiedId = car.ClassifiedId;
  }
  public Listing(House house) {
    Id = house.Id;
    Bathrooms = house.Bathrooms;
    Bedrooms = house.Bedrooms;
    ImgUrl = house.ImgUrl;
    Description = house.Description;
    Levels = house.Levels;
    Price = house.Price;
    ClassifiedId = house.ClassifiedId;
    Year = house.Year;
  }
  public Listing(Job job) {
    Id = job.Id;
    Hours = job.Hours;
    Rate = job.Rate;
    Description = job.Description;
    Company = job.Company;
    JobTitle = job.JobTitle;
    ClassifiedId = job.ClassifiedId;
  }
}