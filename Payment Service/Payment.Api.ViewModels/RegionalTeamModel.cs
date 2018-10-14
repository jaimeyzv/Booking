namespace Stamping.Api.Models
{
    public class RegionalTeamModel
    {
        public int RegionalTeamId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
    }
}