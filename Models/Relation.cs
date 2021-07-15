using System.ComponentModel.DataAnnotations;

namespace Finalexam.Models

{
    public class Relation 
    {
        [Key]
         public int RelationId { get; set; }

         public int UserId { get; set; }

          public int HobbyId { get; set; }

          public Hobby Hobby { get; set; }

           public User User { get; set; }
    }
}