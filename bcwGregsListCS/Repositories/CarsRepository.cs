namespace bcwGregsListCS.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }


  public List<Car> GetCars()
  {
    var sql = "SELECT * FROM cars";
    return _db.Query<Car>(sql).ToList();
  }

  public Car CreateCar(Car carData)
  {
    var sql = @"
    INSERT INTO cars(
      make, model, year, price, description, imgUrl
    )
    VALUES(
      @Make, @Model, @Year, @Price, @Description, @ImgUrl
    );
    SELECT LAST_INSERT_ID();
    ";

    carData.Id = _db.ExecuteScalar<int>(sql, carData);
    return carData;

  }

  public Car EditCar(Car carData) {
    var sql = @"
      UPDATE cars
      SET make = @Make, model = @Model, year = @Year, price = @Price, description = @Description, imgUrl = @ImgUrl
      WHERE id = @Id;
    ";

    _db.Execute(sql, carData);

    return carData;
  }

  public Car DeleteCar(int id) {
    // Car car = _db.ExecuteScalar<Car>($"SELECT * FROM cars WHERE id={id};");
    // _db.Execute($"DELETE FROM cars WHERE id={id};");

    var sql = @"
      SELECT * FROM cars WHERE id=@id
    ";

    Car car = _db.QueryFirst<Car>(sql, new { id });

    sql = @"
      DELETE FROM cars
      WHERE id=@id;
    ";

    _db.ExecuteScalar(sql, new { id });
    // return $"Deleted car with id of {id}";
    return car;
  }

}