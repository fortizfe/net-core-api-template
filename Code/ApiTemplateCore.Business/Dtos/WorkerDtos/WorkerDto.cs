using AutoMapper;
using ApiTemplate.Core.Domain.Models;

namespace ApiTemplate.Core.Business.Dtos.WorkerDtos
{
    public class WorkerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Tagid { get; set; }
        public bool Active { get; set; }
        public int IdVelneo { get; set; }
    }

    public class WorkerDtoMapperProfile : Profile
    {
        public WorkerDtoMapperProfile()
        {
            CreateMap<Worker, WorkerDto>().ReverseMap();
        }
    }
}