using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD5.Models
{
    public partial class StudentRoles
    {
        public string IndexNumber { get; set; }
        public string RoleId { get; set; }

        public virtual Student IndexNumberNavigation { get; set; }
        public virtual Roles Role { get; set; }
    }
}
