using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthName)
        {
            FullName = fullName;
            Email = email;
            BirthName = birthName;
            CreatedAt = DateTime.Now;
            Active = true;
            Skills = new List<UserSkill>();
            OwnerProjects = new List<Project>();
            FreeLanceProjects = new List<Project>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthName { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }

        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnerProjects { get; private set; }
        public List<Project> FreeLanceProjects { get; private set; }
    }
}
