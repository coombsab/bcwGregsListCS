namespace bcwGregsListCS.Services;

public class ClassifiedsService
{

  private readonly ClassifiedsRespository _classifiedsRepository;
  private readonly CarsService _carsService;
  private readonly HousesService _housesService;
  private readonly JobsService _jobsService;
  private readonly AccountService _accountService;

  public ClassifiedsService(ClassifiedsRespository classifiedsRepository, CarsService carsService, HousesService housesService, JobsService jobsService, AccountService accountService)
  {
    _classifiedsRepository = classifiedsRepository;
    _carsService = carsService;
    _housesService = housesService;
    _jobsService = jobsService;
    _accountService = accountService;
  }

  public List<Classified> GetClassifieds()
  {
    List<Classified> classifieds = _classifiedsRepository.GetClassifieds();

    classifieds.ForEach(classified => {
      ListingType listingType = classified.ListingType;
      switch(listingType) {
        case ListingType.Car:
          classified.Listing = new Listing(_carsService.GetCarByClassifiedId(classified.Id));
          break;
        case ListingType.Job:
          classified.Listing = new Listing(_jobsService.GetJobByClassifiedId(classified.Id));
          break;
        case ListingType.House:
          classified.Listing = new Listing(_housesService.GetHouseByClassifiedId(classified.Id));
          break;
      }
      classified.Seller = _accountService.GetById(classified._sellerId);
    });

    return classifieds;
  }

  public Classified CreateClassified(Listing listingData, Account userInfo)
  {
    Classified classified = new Classified(listingData.ListingType, userInfo.Id);
    classified = _classifiedsRepository.CreateClassified(classified);
    listingData.ClassifiedId = classified.Id;
    switch(listingData.ListingType) {
      case ListingType.Car:
          classified.Listing = _carsService.CreateCar(listingData);
          break;
        case ListingType.Job:
          classified.Listing = _jobsService.CreateJob(listingData);
          break;
        case ListingType.House:
          classified.Listing = _housesService.CreateHouse(listingData);
          break;
    }

    return classified;
  }
}