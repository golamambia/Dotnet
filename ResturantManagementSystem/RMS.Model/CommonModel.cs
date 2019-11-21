using System;

namespace RMS.Model
{
    public class CommonModel
    {
        public bool IsActive { get; set; }
        public string CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedByUserId { get; set; }
        public string UpdatedByUserName { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ExceptionKey ExceptionKey { get; set; }
        public string ResponseMessage { get; set; }
        public string DetailResponseMessage { get; set; }
    }
}
