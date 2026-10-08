using Final_Version_Of_School_Management_System.Models;

namespace Final_Version_Of_School_Management_System.AllCustoms
{
    public interface IAuthRepo
    {
        public Task<string> Login(DTOs.AuthDTOs.LoginRequestDto dto);
        public Task<bool> Register(AppUser user);
    }
}
