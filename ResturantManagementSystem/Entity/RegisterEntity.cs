using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Entity
{
    public class RegisterEntity
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }
        public string CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedByUserId { get; set; }
        public string UpdatedByUserName { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
