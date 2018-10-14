using System;

namespace Stamping.Business.Entities
{
    public class ActivityByUserEntity
    {
        public int ActivityByUserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InitialGpsLocation { get; set; }
        public string FinalGpsLocation { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}