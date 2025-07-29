using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);
        void Update(UpdateProjectInputModel inputModel);
        void Delete(int id);
        void CreateComment(CreateCommentInputModel inputModel);
        void Start(int id);
        void Finish(int id);
    }
}
