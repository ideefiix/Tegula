using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Tile
    {
        public int Id {get;init;}

        public string ownerId {get; set;}
        public Player owner {get; set;}

        public string color {get; set;}
    }
}