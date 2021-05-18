using AutoMapper;
using MedicApp.Data.Entities;
using MedicApp.Data.Entities.Admin;
using MedicApp.Resoruce.Auth;
using MedicApp.Resource.Auth;
using MedicApp.Resource.Medservices;
using MedicApp.Resource.Specialities;
using MedicApp.Resource.Staff;

namespace MedicApp.Infrastructure.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<UserResource,User >();
            CreateMap<User, RegisterResource>();
            CreateMap<RegisterResource, User>();

            CreateMap<Staff, AddStaffResource>();
            CreateMap<Staff, StaffResource>();
            CreateMap<AddStaffResource, Staff>();

            CreateMap<EditSpecResource, Speciality>();

            CreateMap<ServiceResource, Medservices>();

        }
    }
}
