using System;

namespace Stamping.Api.Models
{
    public class ActivityByUserModel
    {
        public int ActivityByUserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InitialGpsLocation { get; set; }
        public string FinalGpsLocation { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
    }
}