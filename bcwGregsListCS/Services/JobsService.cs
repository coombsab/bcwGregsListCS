namespace bcwGregsListCS.Services;

public class JobsService {

  private readonly JobsRepository _jobsRepository;

  public JobsService(JobsRepository jobsRepository)
  {
    _jobsRepository = jobsRepository;
  }

  public List<Job> GetJobs()
  {
    return _jobsRepository.GetJobs();
  }

  public Job GetJobByClassifiedId(int classifiedId) {
    return _jobsRepository.GetJobByClassifiedId(classifiedId);
  }

  public Job CreateJob(Job jobData) {
    return _jobsRepository.CreateJob(jobData);
  }

  public Listing CreateJob(Listing listingData) {
    return _jobsRepository.CreateJob(listingData);
  }

  public Job EditJob(Job jobData, int id) {
    jobData.Id = id;
    return _jobsRepository.EditJob(jobData);
  }

  public Job DeleteJob(int id) {
    return _jobsRepository.DeleteJob(id);
  }
}