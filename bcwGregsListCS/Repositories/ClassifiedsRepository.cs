namespace bcwGregsListCS.Repositories;

public class ClassifiedsRespository {

  private readonly IDbConnection _db;


  public ClassifiedsRespository(IDbConnection db)
  {
    _db = db;

 }

  public List<Classified> GetClassifieds() {
    var sql = @"
      SELECT * FROM classifieds
    ";

    return _db.Query<Classified>(sql).ToList();
  }

  public Classified CreateClassified(Classified classifiedData) {
    var sql = @"
      INSERT INTO classifieds(listingType, _sellerId)
      VALUES(@ListingType, @_sellerId);
      SELECT LAST_INSERT_ID();
    ";
    classifiedData.Id = _db.ExecuteScalar<int>(sql, classifiedData);

    return classifiedData;
  }
}