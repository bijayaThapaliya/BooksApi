using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TheBookApp.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
    
        [Required(ErrorMessage ="Name is Required")]
        public string? Name { get; set; }
        public string? Location { get; set; }

        [EmailAddress(ErrorMessage ="Invalid email address")]
        public string? Email { get; set; }

        // public ICollection<Book>? Books { get; set; }
    }
}