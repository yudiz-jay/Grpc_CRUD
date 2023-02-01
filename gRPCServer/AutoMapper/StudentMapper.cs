using AutoMapper;
using gRPCServerProtos;
using gRPCServer.Model.Entity;

namespace gRPCServer.AutoMapper
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<studentEntity,StudentDetail>().ReverseMap();
        }
    }
}
