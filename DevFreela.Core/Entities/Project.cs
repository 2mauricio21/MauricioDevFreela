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
        public User Client { get; private set; }
        public int IdFreeLancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalConst { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAd { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; set; }

        public void Cancel()
        {
            if (Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }
        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }
        public void Finish()
        {
            if (Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Finished;
                FinishedAd = DateTime.Now;
            }
        }
        // temporario
        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalConst = totalCost;
        }
    }
}
