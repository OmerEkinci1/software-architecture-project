using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProjectSectionDal : IEntityRepository<ProjectSection>
    {
        // List<ProjectSectionDto> GetByUserID(int userID); //bu kısım EfProject  için
        //List<ProjectGeneralDto> GetAll(); //Burası frontendte projenin sectionlarını gösterebilmek için.
    }
}
