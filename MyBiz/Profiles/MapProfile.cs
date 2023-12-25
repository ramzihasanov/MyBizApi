using AutoMapper;
using AutoMapper.Execution;
using MyBiz.DTOs.Position;
using MyBiz.DTOs.Worker;
using MyBiz.Entities;

namespace MyBiz.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<WorkerGetDto, Worker>().ReverseMap();
            CreateMap<WorkerCreateDto, Worker>().ReverseMap();
            CreateMap<WorkerUpdateDto, Worker>().ReverseMap();

            CreateMap<PositionGetDto, Position>().ReverseMap();
            CreateMap<PositionCreateDto, Position>().ReverseMap();
            CreateMap<PositionUpdateDto, Position>().ReverseMap();


        }
    }
}
