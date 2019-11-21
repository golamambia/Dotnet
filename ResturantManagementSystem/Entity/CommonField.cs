using System;

namespace RMS.Entity
{
    public class CommonField
    {
        public bool IsActive { get; set; }
        public string CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedByUserId { get; set; }
        public string UpdatedByUserName { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
