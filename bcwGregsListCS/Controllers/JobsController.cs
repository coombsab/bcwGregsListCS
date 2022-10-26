namespace bcwGregsListCS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase {

  private readonly JobsService _jobsService;

  public JobsController(JobsService jobsService)
  {
    _jobsService = jobsService;
  }

  [HttpGet]
  public ActionResult<List<Job>> Get() {
    try {
      List<Job> jobs = _jobsService.GetJobs();
      return Ok(jobs);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Job> Create([FromBody] Job jobData) {
    try {
      Job job = _jobsService.CreateJob(jobData);
      return Ok(job);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<Job> Edit([FromBody] Job jobData, int id) {
    try {
      Job job = _jobsService.EditJob(jobData, id);
      return Ok(job);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<Job> Delete(int id) {
    try {
      Job job = _jobsService.DeleteJob(id);
      return Ok(job);
    }
    catch(Exception e) {
      return BadRequest(e.Message);
    }
  }
}