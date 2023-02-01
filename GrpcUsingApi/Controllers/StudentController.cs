using Grpc.Net.Client;
using gRPCServerProtos;
using gRPCUsingApi.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;

namespace GrpcUsingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        
        private readonly Student.StudentClient _studentClient;
        private readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
            var channel = GrpcChannel.ForAddress("https://localhost:7033");
            _studentClient = new Student.StudentClient(channel);
        }

        [HttpGet("getstudentlist")]
        public async Task<Students> GetStudentsListAsync()
        {
            try
            {
                var response = await _studentClient.GetStudentListAsync(new Empty { });

                return response;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpGet("getstudentbyid")]
        public async Task<StudentDetail> GetStudentByIdAsync(int id)
        {
            try
            {
                var request = new GetStudentDetailRequest
                {
                    Id = id
                };

                var response = await _studentClient.GetStudentAsync(request);

                return response;
            }
            catch(Exception ex) 
            {

            }
            return null;
        }

        [HttpPost("addstudent")]
        public async Task<StudentDetail> AddStudentAsync(studentEntity StudentEntity)
        {
            try
            {
                var studentDetail = new StudentDetail
                {
                    Id = StudentEntity.Id,
                    Name = StudentEntity.Name,
                    Age = (int)StudentEntity.Age,
                    NickName = StudentEntity.NickName    
                };

                var response = await _studentClient.CreateStudentAsync(new CreateStudentDetailRequest()
                {
                    Student = studentDetail
                });

                return response;
            }
            catch (Exception ex) 
            {
                
            }
            return null;
        }

        [HttpPut("updatestudent")]
        public async Task<StudentDetail> UpdateStudentAsync(studentEntity studentEntity)
        {
            try
            {
                var studentDetail = new StudentDetail
                {
                    Id = studentEntity.Id,
                    Name = studentEntity.Name,
                    Age = (int)studentEntity.Age,
                    NickName = studentEntity.NickName
                };

                var response = await _studentClient.UpdateStudentAsync(new UpdateStudentDetailRequest()
                {
                    Student = studentDetail
                });

                return response;
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        [HttpDelete("deletestudent")]
        public async Task<DeleteStudentDetailResponse> DeleteStudentAsync(int id)
        {
            try
            {
                var response = await _studentClient.DeleteStudentAsync(new DeleteStudentDetailRequest()
                {
                    Id = id
                });

                return response;
            }
            catch (Exception ex) 
            {

            }
            return null;
        }
    }
}
