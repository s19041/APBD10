namespace APBD5.Models
{
    public class Studies
    {
        public int IdStudies { get; set; }
        public string Name { get; set; }

        public Studies()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}
