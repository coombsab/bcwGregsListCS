namespace bcwGregsListCS.Services;

public class HousesService {

  private readonly HousesRepository _housesRepository;

  public HousesService(HousesRepository housesRepository)
  {
    _housesRepository = housesRepository;
  }

  public List<House> GetHouses() {
    return _housesRepository.GetHouses();
  }

  public House GetHouseByClassifiedId(int classifiedId) {
    return _housesRepository.GetHouseByClassifiedId(classifiedId);
  }

  public House CreateHouse(House houseData) {
    return _housesRepository.CreateHouse(houseData);
  }

  public Listing CreateHouse(Listing listingData) {
    return _housesRepository.CreateHouse(listingData);
  }

  public House EditHouse(House houseData, int id) {
    houseData.Id = id;
    return _housesRepository.EditHouse(houseData);
  }

  public House DeleteHouse(int id) {
    return _housesRepository.DeleteHouse(id);
  }
}