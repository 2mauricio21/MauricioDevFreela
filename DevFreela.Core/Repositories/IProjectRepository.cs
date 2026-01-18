using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task StartAsync(Project project);
        Task FinishAsync(Project project);
        Task CancelAsync(Project project);
        Task<Project> GetDetailsByIdAsync(int id);
        Task SaveChangesAsync();
        Task AddCommentAsync(ProjectComment projectComment);
    }
}
