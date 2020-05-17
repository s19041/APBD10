using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD5.Models
{
    public partial class TaskType
    {
        public int IdTaskType { get; set; }
        public string Name { set; get; }

        public TaskType()
        {
            Task = new HashSet<Task>();
        }

        public virtual ICollection<Task> Task { get; set; }


    }
}
