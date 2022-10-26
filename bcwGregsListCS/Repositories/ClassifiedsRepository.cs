namespace bcwGregsListCS.Repositories;

public class ClassifiedsRespository {

  private readonly IDbConnection _db;

  public ClassifiedsRespository(IDbConnection db)
  {
    _db = db;
  }
}