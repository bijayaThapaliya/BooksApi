using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheBookApp.Models;

namespace TheBookApp;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Title is Required")]
    public string? Title { get; set; }

    [Required(ErrorMessage ="Author is Required")]
    public string? Author { get; set; }

    [Required(ErrorMessage ="Year is Required")]
    [Range(1800,2030, ErrorMessage= "Year must be between 1000")]
    public int Year { get; set; }

    [Required(ErrorMessage ="Edition is Required")]
    public string? Edition { get; set; }

    [Required(ErrorMessage ="ISBN is Required")]
    // [RegularExpression(@"^\{13}$", ErrorMessage ="The ISBN Number must be 13 digit.")]
    public long ISBN { get; set; }


    [Required(ErrorMessage ="Publisher is Required")]
    public int PublisherId {get; set;}
    
    public Publisher? Publisher{get; set;}
}
