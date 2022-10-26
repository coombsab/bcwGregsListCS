namespace bcwGregsListCS.Repositories;

public class HousesRepository {
  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<House> GetHouses() {
    var sql = @"
      SELECT * FROM houses
    ";
    return _db.Query<House>(sql).ToList();
  }

  public House CreateHouse(House houseData) {
    var sql = @"
      INSERT INTO houses(
        bedrooms, bathrooms, levels, year, price, description, imgUrl
      )
      VALUES(
        @Bedrooms, @Bathrooms, @Levels, @Year, @Price, @Description, @ImgUrl
      );
      SELECT LAST_INSERT_ID();
    ";
    houseData.Id = _db.ExecuteScalar<int>(sql, houseData);
    return houseData;
  }

  public House EditHouse(House houseData) {
    var sql = @"
      UPDATE houses
      SET bedrooms = @Bedrooms, bathrooms = @Bathrooms, levels = @Levels, year = @Year, price = @Price, description = @Description, imgUrl = @ImgUrl
      WHERE id = @Id;
    ";

    _db.Execute(sql, houseData);
    return houseData;
  }

  public House DeleteHouse(int id) {
    var sql = @"
      SELECT * FROM houses
      WHERE id = @id;
    ";

    House house = _db.QueryFirstOrDefault<House>(sql, new { id });

    sql = @"
      DELETE FROM houses
      WHERE id = @id;
    ";

    _db.Execute(sql, new { id });
    return house;
  }
}