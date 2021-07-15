using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Finalexam.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage="Unsuccessful submission")]
        [MinLength(2, ErrorMessage="need more than 2later")]
        [Display(Name = "First Name")]
        public string FirstName{ get; set;}

        [Required]
        [MinLength(2, ErrorMessage="need more than 2later")]
        [Display(Name = "Last Name")]
        public string LastName{ get; set;}

       [Required(ErrorMessage="Unsuccessful submission")]
       
        [MinLength(2, ErrorMessage="need more than 2later")]
        [Display(Name = "Username")]
        public string Username{ get; set;}

        [Required(ErrorMessage="Unsuccessful submission")]
        [MinLength(8,ErrorMessage="need more than  8 later")]
        [DataType(DataType.Password)]
        public string Password{ get; set;}

        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string Confirm { get; set; }
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

         public List<Relation> Hobbies {get;set;}

    }
}