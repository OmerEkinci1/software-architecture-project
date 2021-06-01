using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectSectionService
    {
        IResult Add(ProjectSection projectSections);
        IResult Delete(ProjectSection projectSections);
        IResult Update(ProjectSection projectSections);
        IDataResult<List<ProjectSectionDto>> GetAll();
        IDataResult<List<ProjectSection>> GetByProjectID(int projectID); 
        IDataResult<ProjectSection> GetBySectionID(int sectionID);
        //IDataResult<List<ProjectSectionDto>> GetByUserID(int userID);

    }
}
