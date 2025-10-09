namespace ShopTARge24.Core.Domain
{
    public class FileToDatabaseKindergarten
    {
        public Guid Id { get; set; }
        public string? ImageTitle { get; set; }
        public byte[]? ImageData { get; set; }
        public Guid? KindergartenId { get; set; }
    }
}
