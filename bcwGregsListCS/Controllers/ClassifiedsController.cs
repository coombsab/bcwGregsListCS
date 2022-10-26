namespace bcwGregsListCS.Controllers;

public class ClassifiedsController : ControllerBase {

  private readonly ClassifiedsService _classifiedsService;

  public ClassifiedsController(ClassifiedsService classifiedsService)
  {
    _classifiedsService = classifiedsService;
  }
  
}