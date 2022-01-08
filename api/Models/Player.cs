using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Player
    {
        [Key]
        public string Name {get; set;}

        public string Color {get; set;}

        //Player can attack every 3hours
        public DateTime prevAttack {get; set;}
    }
}