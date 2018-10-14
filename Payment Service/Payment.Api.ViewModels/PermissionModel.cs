namespace Stamping.Api.Models
{
    public class PermissionModel
    {
        public int PermissionId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int ProfileId { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string Screen { get; set; }
    }
}