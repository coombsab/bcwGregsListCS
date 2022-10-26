namespace bcwGregsListCS.Models;

public class Classified {
  public int Id { get; set; }
  public ListingType listingType { get; set; }
  public string _sellerId { get; set; }
  public int carId { get; set; }
  public int houseId { get; set; }
  public int jobId { get; set; }
  public Car car { get; set; }
  public House house { get; set; }
  public Job job { get; set; }

}