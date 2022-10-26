namespace bcwGregsListCS.Repositories;

public class JobsRepository {

  private readonly IDbConnection _db;

  public JobsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Job> GetJobs() {
    var sql = @"
      SELECT * FROM jobs
    ";
    return _db.Query<Job>(sql).ToList();
  }

  public Job CreateJob(Job jobData) {
    var sql = @"
      INSERT INTO jobs(
        jobTitle, company, hours, rate, description
      )
      VALUES(
        @JobTitle, @Company, @Hours, @Rate, @Description
      );
      SELECT LAST_INSERT_ID();
    ";

    jobData.Id = _db.ExecuteScalar<int>(sql, jobData);
    return jobData;
  }

  public Job EditJob(Job jobData) {
    var sql = @"
      UPDATE jobs
      SET jobTitle = @JobTitle, company = @Company, hours = @Hours, rate = @Rate, description = @Description
      WHERE id = @Id;
    ";

    _db.Execute(sql, jobData);
    return jobData;
  }

  public Job DeleteJob(int id) {
    var sql = @"
      SELECT * FROM jobs
      WHERE id = @id;
    ";

    Job job = _db.QueryFirst<Job>(sql, new { id });

    sql = @"
      DELETE FROM jobs
      WHERE id = @id;
    ";

    _db.Execute(sql, new { id });

    return job;
  }
}