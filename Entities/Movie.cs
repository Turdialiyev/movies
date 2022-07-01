namespace databeses.Entities;
public class Movie
{
  public Guid Id { get; set; } 
  public string? Title { get; set; }
  public string? Discription { get; set;}
  public DateTime ReleaseDate { get; set; }
  public EGener Gener { get; set; }
  public int Imdb { get; set; }
  public int Viewed { get; set; }
  
}