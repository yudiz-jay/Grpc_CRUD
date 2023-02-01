using Grpc.Core;
using gRPCServer.Model.Context;
using gRPCServer.Model.Entity;
using gRPCServerProtos;
using Microsoft.EntityFrameworkCore;
namespace gRPCServer.Repository
{
    public class StudentService : IStudentService
    {
        private readonly studentContext _dbContext;

        public StudentService(studentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<studentEntity> AddStudentAsync(studentEntity student)
        {
            var result = _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteStudentAsync(int Id)
        {
            var filteredData = _dbContext.Students.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<studentEntity> GetStudentByIdAsync(int Id)
        {
            return await _dbContext.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<studentEntity>> GetStudentListAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<studentEntity> UpdateStudentAsync(studentEntity student)
        {
            var result = _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }

}
