using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stamping.Business.Entities
{
    public class ActivityUserEntity
    {
        public int Activity_X_User_Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InitialGpsLocation { get; set; }
        public string Name { get; set; }
        public string FinalGpsLocation { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
    }
}
