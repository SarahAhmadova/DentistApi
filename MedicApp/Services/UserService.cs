using CryptoHelper;
using MedicApp.Data.Entities;
using MedicApp.Data.Entities.Admin;
using MedicApp.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Services
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> Login(string email, string password);
        Task<User> GetUserByToken(string token);
    }

    public class UserService:IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByToken(string token)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
            {
                user.Token = Crypto.HashPassword(DateTime.Now.ToString() + user.Id);
                await _context.SaveChangesAsync();

                return user;
            }

            throw new HttpException(404, "E-poçt və ya şifrə yanlışdır");
        }

        public async Task<User> Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email)) throw new HttpException(409, "Bu e-poçt artıq qeydiyyat keçib");


            user.Token = Crypto.HashPassword(DateTime.Now.ToString());
            user.Password = Crypto.HashPassword(user.Password);

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
            Console.WriteLine(user);

            return user;
        }
    }
}
