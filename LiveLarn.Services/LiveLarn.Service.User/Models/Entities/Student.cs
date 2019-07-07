using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.User.Models.Entities
{
    public class Student : UserBase
    {
        public Enum EducationLevel { get; set; }

        public Enum Scope { get; set; } // = 1 : unspecified
    }
}
