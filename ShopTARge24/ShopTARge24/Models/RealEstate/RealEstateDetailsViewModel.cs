namespace ShopTARge24.Models.RealEstate
{
    public class RealEstateDetailsViewModel
    {
        public Guid? Id { get; set; }

        public string? Area { get; set; }

        public string? Location { get; set; }

        public int? RoomNumber { get; set; }

        public string? BuildingType { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}