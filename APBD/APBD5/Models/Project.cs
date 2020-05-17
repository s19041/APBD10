using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD5.Models
{
    public partial class Project
    {
        public int IdProject { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }

        public Project()
        {
            Task = new HashSet<Task>();
        }

        public virtual ICollection<Task> Task { get; set; }

    }
}
