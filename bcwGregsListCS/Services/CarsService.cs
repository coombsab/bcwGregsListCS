namespace bcwGregsListCS.Services;

public class CarsService
{
  // REPOSITORY PATTERN
  // will be used to control communication with the DB

  private readonly CarsRepository _carsRepo;

  public CarsService(CarsRepository carsRepo)
  {
    _carsRepo = carsRepo;
  }

  public List<Car> GetCars()
  {
    return _carsRepo.GetCars();
  }

  public Car CreateCar(Car carData)
  {
    return _carsRepo.CreateCar(carData);
  }

  public Car EditCar(Car carData, int id) {
    carData.Id = id;
    return _carsRepo.EditCar(carData);
  }

  public Car DeleteCar(int id) {
    return _carsRepo.DeleteCar(id);
  }
}