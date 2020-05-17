using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD5.Models
{
    public partial class TeamMembers
    {
        public int IdTeamMember { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Task> TaskIdAssignedToNavigation { get; set; }
        public virtual ICollection<Task> TaskIdCreatorNavigation { get; set; }



    }
}
