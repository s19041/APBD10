using System;
using System.ComponentModel.DataAnnotations;

namespace APBD5.DTOs.RequestModels
{
    public class EnrollStudentRequest

    {
        [Required]
        [RegularExpression("^s[0-9]+$")]
        public string IndexNumber { get; set; }
        [Required] [MaxLength(255)] public string LastName { get; set; }
        [Required] [MaxLength(10)] public string FirstName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required] public string Studies { get; set; }
    }
    }
