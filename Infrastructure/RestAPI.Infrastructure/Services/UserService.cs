using RestAPI.Application.Repositories;
using RestAPI.Application.Services;
using RestAPI.Application.ViewModels.Users;
using RestAPI.Core.Services;
using RestAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Infrastructure.Services
{
    public interface IUserService
    {
        Task<RegistrationResult> RegisterUserAsync(RegisterViewModel model);
        Task<LoginResult> LoginUserAsync(LoginViewModel model);
        Task<Customer> GetUserProfileAsync(string username);
    }

    public class UserService : IUserService
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;

        public UserService(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<RegistrationResult> RegisterUserAsync(RegisterViewModel model)
        {
            var errors = new List<string>();

            // Kullanıcı adının benzersiz olduğunu doğrula
            var existingUser = await _customerReadRepository.GetSingleAsync(c => c.Username == model.Username);
            if (existingUser != null)
            {
                errors.Add("Bu kullanıcı adı zaten alınmış.");
                return new RegistrationResult(false, errors);
            }

            // Şifreleri karşılaştır
            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Şifreler uyuşmuyor.");
                return new RegistrationResult(false, errors);
            }

            // Şifreyi hashle ve tuzla
            var salt = GenerateSalt();
            var hashedPassword = HashPassword(model.Password, salt);

            // Kullanıcı verisini oluştur ve veritabanına kaydet
            var newUser = new Customer
            {
                Name = model.Name,
                Username = model.Username,
                TelNo = model.TelNo,
                HashedPassword = hashedPassword,
                Salt = salt
            };

            await _customerWriteRepository.AddAsync(newUser);
            await _customerWriteRepository.SaveAsync();

            return new RegistrationResult(true, null);
        }

        public async Task<LoginResult> LoginUserAsync(LoginViewModel model)
        {
            var errors = new List<string>();

            // Kullanıcıyı kullanıcı adına göre bulur
            var existingUser = await _customerReadRepository.GetSingleAsync(c => c.Username == model.Username);
            if (existingUser == null)
            {
                errors.Add("Bu kullanıcı adı kayıtlı değil.");
                return new LoginResult(false, errors);
            }

            // Girilen şifreyi hashler ve veritabanındaki hash ile karşılaştırır
            var hashedPassword = HashPassword(model.Password, existingUser.Salt);
            if (hashedPassword != existingUser.HashedPassword)
            {
                errors.Add("Hatalı şifre.");
                return new LoginResult(false, errors);
            }

            return new LoginResult(true, null);
        }

        private string HashPassword(string password, string salt)
        {
            using (var sha256 = new SHA256Managed())
            {
                var saltBytes = Convert.FromBase64String(salt);
                var passwordBytes = Encoding.UTF8.GetBytes(password);

                var saltedPassword = new byte[saltBytes.Length + passwordBytes.Length];
                saltBytes.CopyTo(saltedPassword, 0);
                passwordBytes.CopyTo(saltedPassword, saltBytes.Length);

                var hashedPasswordBytes = sha256.ComputeHash(saltedPassword);

                return BitConverter.ToString(hashedPasswordBytes).Replace("-", "").ToLower();
            }
        }
        private string GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[32];
                rng.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }
        public async Task<Customer> GetUserProfileAsync(string username)
        {
            var user = await _customerReadRepository.GetSingleAsync(c => c.Username == username);
            return user;
        }




    }
}
