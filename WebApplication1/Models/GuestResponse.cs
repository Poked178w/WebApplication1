using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class GuestResponse {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\ .. +", ErrorMessage = "Please enter а valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone numЬer")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please specify whether you' 11 attend")]
        public bool? WillAttend { get; set; }
    }
}
