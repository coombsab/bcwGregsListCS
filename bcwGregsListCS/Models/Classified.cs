namespace bcwGregsListCS.Models;

public class Classified
{
  public int Id { get; set; }
  public ListingType ListingType { get; set; }
  public string _sellerId { get; set; }
  public Listing Listing { get; set; }
  public Account Seller { get; set; }


  public Classified()
  {

  }
  public Classified(ListingType listingType, string _sellerId)
  {
    ListingType = listingType;
    this._sellerId = _sellerId;
  }
}