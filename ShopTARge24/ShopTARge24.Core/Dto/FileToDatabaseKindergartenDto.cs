namespace ShopTARge24.Core.Dto
{
    public class FileToDatabaseKindergartenDto
    {
        public Guid Id { get; set; }
        public string? ImageTitle { get; set; }
        public byte[]? ImageData { get; set; }
        public Guid? KindergartenId { get; set; }
    }
}
