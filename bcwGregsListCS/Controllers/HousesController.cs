namespace bcwGregsListCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase {

  private readonly HousesService _housesService;

  public HousesController(HousesService housesService) {
    _housesService = housesService;
  }

  [HttpGet]
  public ActionResult<List<House>> Get() {
    try {
      List<House> houses = _housesService.GetHouses();
      return Ok(houses);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<House> Create([FromBody] House houseData) {
    try {
      House house = _housesService.CreateHouse(houseData);
      return Ok(house);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<House> Edit([FromBody] House houseData, int id) {
    try {
      House house = _housesService.EditHouse(houseData, id);
      return Ok(house);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<House> Delete(int id) {
    try {
      House house = _housesService.DeleteHouse(id);
      return Ok(house);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}