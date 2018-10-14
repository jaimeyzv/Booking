namespace Stamping.Business.Entities
{
    public class RegionalTeamEntity
    {
        public int RegionalTeamId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
    }
}