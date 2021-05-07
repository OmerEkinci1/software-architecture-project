using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectSectionService
    {
        IResult Add(ProjectSectionsDto projectSectionsDto);
        IResult Delete(ProjectSectionsDto projectSectionsDto);
        IResult Update(ProjectSectionsDto projectSectionsDto);

        IDataResult<ProjectSectionsDto> GetByProjectID(int projectID);
    }
}
