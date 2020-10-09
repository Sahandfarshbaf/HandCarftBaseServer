using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Status
    {
        public Status()
        {
            InverseNextStatus = new HashSet<Status>();
        }

        public long Id { get; set; }
        public long? CatStatusId { get; set; }
        public long? StatusTypeId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public long? NextStatusId { get; set; }
        public string Description { get; set; }
        public long? CuserId { get; set; }
        public long? Cdate { get; set; }
        public long? DuserId { get; set; }
        public long? Ddate { get; set; }
        public long? MuserId { get; set; }
        public long? Mdate { get; set; }
        public long? DaUserId { get; set; }
        public long? DaDate { get; set; }

        public virtual CatStatus CatStatus { get; set; }
        public virtual Status NextStatus { get; set; }
        public virtual StatusType StatusType { get; set; }
        public virtual ICollection<Status> InverseNextStatus { get; set; }
    }
}
