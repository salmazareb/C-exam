using System.ComponentModel.DataAnnotations;


namespace Finalexam.Models
{
    public class LoginUser
    {
        [Required]
       
        public string Username{ get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set;}
    }
}