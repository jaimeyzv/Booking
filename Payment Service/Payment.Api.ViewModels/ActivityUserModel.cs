using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stamping.Api.Models
{
    public class ActivityUserModel
    {
        public int ActivityByUserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InitialGpsLocation { get; set; }
        public string FinalGpsLocation { get; set; }
        public string Name { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; } //agregado solo para el codigo
    }
}
