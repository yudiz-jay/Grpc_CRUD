using AutoMapper;
using Grpc.Core;
using gRPCServer.Model.Entity;
using gRPCServer.Repository;
using gRPCServerProtos;
using AutoMapper;

namespace gRPCServer.Services
{
    public class StudentService : Student.StudentBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentService(IStudentService studentService,IMapper mapper)
        {
            _studentService= studentService;
            _mapper= mapper;
        }

        public async override Task<Students> GetStudentList(Empty request,ServerCallContext context)
        {
            var studentData = await _studentService.GetStudentListAsync();

            Students response = new Students();
            foreach (studentEntity student in studentData)
            {
                response.Items.Add(_mapper.Map<StudentDetail>(student));
            }
            return response;
        }
        public async override Task<StudentDetail> GetStudent(GetStudentDetailRequest request,ServerCallContext context)
        {
            var studentData = await _studentService.GetStudentByIdAsync(request.Id);
            var studentDetail = _mapper.Map<StudentDetail>(studentData);
            return studentDetail;
        }
        public async override Task<StudentDetail> CreateStudent(CreateStudentDetailRequest request, ServerCallContext context)
        {
            var studentData = new studentEntity
            {
                Id = request.Student.Id,
                Name = request.Student.Name,
                Age = request.Student.Age,
                NickName = request.Student.NickName
            };
            await _studentService.AddStudentAsync(studentData);

            var studentDetail = _mapper.Map<StudentDetail>(studentData);
            return studentDetail;
        }

        public async override Task<StudentDetail> UpdateStudent(UpdateStudentDetailRequest request, ServerCallContext context)
        {
            var studentData = new studentEntity
            {
                Id = request.Student.Id,
                Name = request.Student.Name,
                Age = request.Student.Age,
                NickName = request.Student.NickName
            };
            await _studentService.UpdateStudentAsync(studentData);
            var studentDetail = _mapper.Map<StudentDetail>(studentData);
            return studentDetail;   
        }

        public async override Task<DeleteStudentDetailResponse> DeleteStudent(DeleteStudentDetailRequest request,ServerCallContext context)
        {
            var isDeleted = await _studentService.DeleteStudentAsync(request.Id);
            var response = new DeleteStudentDetailResponse
            {
                IsDelete = isDeleted
            };

            return response;
        }
    }
}
