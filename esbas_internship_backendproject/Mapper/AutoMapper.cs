using AutoMapper;
using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.Entities;
using esbas_internship_backendproject.ResponseDTO;
using esbas_internship_backendproject.ResponseDTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace esbas_internship_backendproject.Mapper // Replace with your namespace  
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<EventsUsersDTO, Events_Users>();
            CreateMap<Events_Users, EventsUsersDTO>();

            CreateMap<EventDTO, Events>();
            CreateMap<Events, EventDTO>();

            CreateMap<UserDTO, Users>();
            CreateMap<Users, UserDTO>();

            CreateMap<DepartmentDTO, Department>();
            CreateMap<Department, DepartmentDTO>();

            CreateMap<CostCentersDTO, CostCenters>();
            CreateMap<CostCenters, CostCentersDTO>();

            CreateMap<MainCharacteristictsDTO,Main_Characteristicts>();
            CreateMap<Main_Characteristicts,MainCharacteristictsDTO>();

            CreateMap<OtherCharacteristictsDTO,Other_Characteristicts>();
            CreateMap<Other_Characteristicts, OtherCharacteristictsDTO>();

            CreateMap<TasksDTO, Entities.Taskk>();
            CreateMap<Entities.Taskk, TasksDTO>();

            CreateMap<UserGenderDTO, User_Gender>();
            CreateMap<User_Gender, UserGenderDTO>();

            CreateMap<EventLocationDTO, Event_Location>();
            CreateMap<Event_Location, EventLocationDTO>();

            CreateMap<EventTypeDTO, Event_Type>();
            CreateMap<Event_Type, EventTypeDTO>();

            CreateMap<EventsUsersResponseDTO, Events_Users>();
            CreateMap<Events_Users, EventsUsersResponseDTO>();

            CreateMap<EventResponseDTO, Events>();
            CreateMap<Events, EventResponseDTO>();

            CreateMap<UserResponseDTO, Users>();
            CreateMap<Users, UserResponseDTO>();

            CreateMap<DepartmentResponseDTO, Department>();
            CreateMap<Department, DepartmentResponseDTO>();

            CreateMap<CostCentersResponseDTO, CostCenters>();
            CreateMap<CostCenters,CostCentersResponseDTO>();

            CreateMap<MainCharacteristictsResponseDTO, Main_Characteristicts>();
            CreateMap<Main_Characteristicts,MainCharacteristictsResponseDTO>();

            CreateMap<OtherCharacteristictsResponseDTO,Other_Characteristicts>();
            CreateMap<Other_Characteristicts, OtherCharacteristictsResponseDTO>();

            CreateMap<TasksResponseDTO, Entities.Taskk>();
            CreateMap<Entities.Taskk, TasksResponseDTO>();

            CreateMap<UserGenderResponseDTO, User_Gender>();
            CreateMap<User_Gender, UserGenderResponseDTO>();

            CreateMap<EventLocationResponseDTO, Event_Location>();
            CreateMap<Event_Location, EventLocationResponseDTO>();

            CreateMap<EventTypeResponseDTO, Event_Type>();
            CreateMap<Event_Type, EventTypeResponseDTO>();


        }
    }
}