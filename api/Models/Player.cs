using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Player
    {
        [Key]
        public string Name {get; set;}
    }
}