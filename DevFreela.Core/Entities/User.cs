using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthName, string password, string role)
        {
            FullName = fullName;
            Email = email;
            BirthName = birthName;
            Active = true;
            Password = password;
            Role = role;
            CreatedAt = DateTime.Now;
            // Initialize collections
            OwnerProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthName { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnerProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
