namespace bcwGregsListCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassifiedsController : ControllerBase {

  private readonly ClassifiedsService _classifiedsService;
  private readonly Auth0Provider _auth0Provider;

  public ClassifiedsController(ClassifiedsService classifiedsService, Auth0Provider auth0Provider)
  {
    _classifiedsService = classifiedsService;
    _auth0Provider = auth0Provider;
  }
  
  [HttpGet]
  public ActionResult<List<Classified>> Get() {
    try {
      List<Classified> classifieds = _classifiedsService.GetClassifieds();
      return Ok(classifieds);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Classified>> Create([FromBody] Listing listingData) {
    try {
      var userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Classified classified = _classifiedsService.CreateClassified(listingData, userInfo);
      return Ok(classified);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}