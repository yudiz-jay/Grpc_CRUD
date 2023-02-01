using gRPCServer.Model.Entity;

namespace gRPCServer.Repository
{
    public interface IStudentService
    {
        public Task<List<studentEntity>> GetStudentListAsync();
        public Task<studentEntity> GetStudentByIdAsync(int Id);
        public Task<studentEntity> AddStudentAsync(studentEntity student);
        public Task<studentEntity> UpdateStudentAsync(studentEntity student);
        public Task<bool> DeleteStudentAsync(int Id);

    }
}
