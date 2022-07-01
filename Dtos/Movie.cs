using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace databeses.Dtos;
public class Movie
{
  [Required]
  public string? Title { get; set; }
  
  [MaxLength(255)]
  public string? Discription { get; set;}
  
  [Required]
  [Range(typeof(DateTime), "1/1/1950", "1/1/2023")]
  public DateTime ReleaseDate { get; set; }

  [JsonConverter(typeof(JsonStringEnumConverter))]  
  public EGener Gener { get; set; }
  
  [Required]
  [Range(1,10)]
  public int Imdb { get; set; }
  public int Viewed { get; set; }

}