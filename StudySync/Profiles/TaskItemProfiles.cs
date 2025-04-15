using AutoMapper;
using StudySync.Dtos;
using StudySync.Models;

namespace StudySync.Profiles
{
    public class TaskItemProfiles:Profile
    {

        public TaskItemProfiles()
        {


            CreateMap<TaskItem, TaskItemDTO>();
            CreateMap<TaskItemCreateDTO, TaskItem>();
            CreateMap<TaskItemUpdateDTO, TaskItem>();




        }



    }
}
