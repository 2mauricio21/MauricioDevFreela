using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);
        void Delete(int id);
        void Start(int id);
        void Finish(int id);
    }
}
