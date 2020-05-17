﻿using System;

namespace APBD5.Models
{
    public class Student
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdEnrollment { get; set; }


        public string Password { get; set; }
        public string Salt { get; set; }
        public string RefreshToken { get; set; }
        public string TokenExpiration { get; set; }

        public virtual Enrollment IdEnrollmentNavigation { get; set; }
    }
}
