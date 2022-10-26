namespace bcwGregsListCS.Services;

public class ClassifiedsService {

  private readonly ClassifiedsRespository _classifiedsRepository;

  public ClassifiedsService(ClassifiedsRespository classifiedsRepository)
  {
    _classifiedsRepository = classifiedsRepository;
  }
  
}