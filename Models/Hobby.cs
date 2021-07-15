using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Finalexam.Models
{

public class Hobby
        {
        [Key]
        public int HobbyId { get; set; }
        [Required]
        public string Name{ get; set;}

        [Required]
        public string Description{ get; set;}

        

        public List<Relation> Users { get; set;}
       
        }
}