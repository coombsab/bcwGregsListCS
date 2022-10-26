namespace bcwGregsListCS.Repositories;

public class JobsRepository
{

  private readonly IDbConnection _db;

  public JobsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Job> GetJobs()
  {
    var sql = @"
      SELECT * FROM jobs
    ";
    return _db.Query<Job>(sql).ToList();
  }

  public Job GetJobByClassifiedId(int classifiedId)
  {
    var sql = "SELECT * FROM jobs WHERE classifiedId = @classifiedId";
    return _db.QueryFirstOrDefault<Job>(sql, new { classifiedId });
  }

  public Job CreateJob(Job jobData)
  {
    var sql = @"
      INSERT INTO jobs(
        jobTitle, company, hours, rate, description, classifiedId
      )
      VALUES(
        @JobTitle, @Company, @Hours, @Rate, @Description, @ClassifiedId
      );
      SELECT LAST_INSERT_ID();
    ";

    jobData.Id = _db.ExecuteScalar<int>(sql, jobData);
    return jobData;
  }
  public Listing CreateJob(Listing listingData)
  {
    var sql = @"
      INSERT INTO jobs(
        jobTitle, company, hours, rate, description, classifiedId
      )
      VALUES(
        @JobTitle, @Company, @Hours, @Rate, @Description, @ClassifiedId
      );
      SELECT LAST_INSERT_ID();
    ";

    listingData.Id = _db.ExecuteScalar<int>(sql, listingData);
    return listingData;
  }

  public Job EditJob(Job jobData)
  {
    var sql = @"
      UPDATE jobs
      SET jobTitle = @JobTitle, company = @Company, hours = @Hours, rate = @Rate, description = @Description
      WHERE id = @Id;
    ";

    _db.Execute(sql, jobData);
    return jobData;
  }

  public Job DeleteJob(int id)
  {
    var sql = @"
      SELECT * FROM jobs
      WHERE id = @id;
    ";

    Job job = _db.QueryFirstOrDefault<Job>(sql, new { id });

    sql = @"
      DELETE FROM jobs
      WHERE id = @id;
    ";

    _db.Execute(sql, new { id });

    return job;
  }
}