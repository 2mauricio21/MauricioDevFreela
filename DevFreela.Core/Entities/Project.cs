using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreeLancer, decimal totalConst)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreeLancer = idFreeLancer;
            TotalConst = totalConst;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();

        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreeLancer { get; private set; }
        public decimal TotalConst { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartAt { get; private set; }
        public DateTime? FinishedAd { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; set; }
    }
}
