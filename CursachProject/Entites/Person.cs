﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursachProject.Entites
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ContactInformation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Membership> Memberships { get; set; }
        public string Role { get;set; }

        public static implicit operator Person(ViewModels.Person v)
        {
            throw new NotImplementedException();
        }
    }

    public class Membership
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public string MemberName { get; set; }
    }
}
