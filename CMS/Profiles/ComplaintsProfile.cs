using System;
using AutoMapper;
using CMS.Dtos;
using CMS.Models;

namespace CMS.Profiles
{
    public class ComplaintsProfile:Profile
    {
        public ComplaintsProfile()
        {
            CreateMap<ComplaintCreateDto, Complaint>();
            CreateMap<Complaint, ComplaintReadDto>();
            CreateMap<ComplaintUpdateDto, Complaint>();
            CreateMap<Complaint, ComplaintUpdateDto>();
        }
    }
}
