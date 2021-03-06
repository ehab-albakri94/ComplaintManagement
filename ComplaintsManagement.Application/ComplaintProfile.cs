using AutoMapper;
using ComplaintsManagement.Application.DTOs;
using ComplaintsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplaintsManagement.Application
{
   public class ComplaintProfile : Profile
    {
        public ComplaintProfile()
        {
            CreateMap<Complaint, ComplaintDto>()
               .ForMember(c => c.CustomerName, opt => opt.MapFrom(u => u.User.FirstName + " " + u.User.LastName))
               .ForMember(c => c.CutomerEmail, opt => opt.MapFrom(u => u.User.Email ))
               .ForMember(c => c.IsUrgent, opt => opt.MapFrom(u => u.IsUrgent ? "Yes" : "No"))
               .ForMember(c => c.Status, opt => opt.MapFrom(u => u.Status.ToString()))
               .ForMember(c => c.ComplaintType, opt => opt.MapFrom(u => u.ComplaintType))
               .ForMember(c => c.ComplaintTime, opt => opt.MapFrom(u => u.ComplaintTime.Date));


            CreateMap<Complaint, CustomerComplaintDto>()
                .ForMember(c => c.IsUrgent, opt => opt.MapFrom(u => u.IsUrgent ? "Yes" : "No"))
               .ForMember(c => c.Status, opt => opt.MapFrom(u => u.Status.ToString()))
               .ForMember(c => c.ComplaintType, opt => opt.MapFrom(u => u.ComplaintType))
               .ForMember(c => c.ComplaintTime, opt => opt.MapFrom(u => u.ComplaintTime));
        }
    }
}
