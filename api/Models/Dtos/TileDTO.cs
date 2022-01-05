namespace api.Models.Dtos
{
    public class TileDTO
    {
        public int Id {get;init;}

        public string ownerId {get; set;}
        public Player owner {get; set;}

        public string color {get; set;}
    }
}