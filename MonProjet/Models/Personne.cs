using System.ComponentModel.DataAnnotations;

public class Personne
{
    public int Id { get; set; }

    [Required]
    public string Nom { get; set; }

    [Required]
    public string Time { get; set; }

    [Required]
    public string Difficulty { get; set; }

    public string Like { get; set; }

    [Required]
    public string Ingredients { get; set; }

    [Required]
    public string Process { get; set; }

    [Required]
    public string Tips { get; set; }


}
