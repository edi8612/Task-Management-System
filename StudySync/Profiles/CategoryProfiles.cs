using AutoMapper;
using StudySync.Dtos;
using StudySync.Models;

namespace StudySync.Profiles
{
    public class CategoryProfiles:Profile
    {


        public CategoryProfiles() 
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryCreateDTO, Category>();
         // CreateMap<TaskItemUpdateDTO, TaskItem>();



        }
    }
}
