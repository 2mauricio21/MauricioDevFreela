using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu Projeto ASPNET Core 1", "Descrição do projeto 1", 1, 1, 1000),
                new Project("Meu Projeto ASPNET Core 2", "Descrição do projeto 2", 1, 1, 2000),
                new Project("Meu Projeto ASPNET Core 3", "Descrição do projeto 3", 1, 1, 3000)
            };

            Users = new List<User>
            {
                new User("Mauricio Souza", "Mauricio@hotmail.com",new DateTime(2000, 01, 01)),
                new User("Leandro Silva", "Leandro@hotmail.com",new DateTime(1995, 01, 25)),
                new User("João Santos", "Joao@hotmail.com",new DateTime(1980, 01, 07))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("Entity Framework"),
                new Skill("SQL Server"),
                new Skill("MongoDb")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
