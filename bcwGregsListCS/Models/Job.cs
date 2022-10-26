namespace bcwGregsListCS.Models;

public class Job {
  public int Id { get; set; }
  public string JobTitle { get; set; }
  public string Company { get; set; }
  public decimal Rate { get; set; }
  public int Hours { get; set; }
  public string Description { get; set; }
}