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
    public interface IStaffService
    {
        public Task<IEnumerable<Staff>> getStaffList();
        public Task<Staff> addStaff(Staff staff);
        public Task deleteStaff(int id);
        public Task updateStaff(int id,Staff staff);
        public Task<Staff> getStaff(int id);
    }
    public class StaffService : IStaffService
    {
        private readonly AppDbContext _context;
        public StaffService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Staff> addStaff(Staff staff)
        {
            var _staff = _context.Staff.FirstOrDefault(e => e.Fullname == staff.Fullname && 
                                                       e.Phone == staff.Phone && !e.softDeleted);

            if (_staff == null)
            {

                await  _context.Staff.AddAsync(staff);
                await _context.SaveChangesAsync();
                return staff;
            }

            throw new HttpException(404, "Bu işçi artıq mövcuddur.");
        }

        public async Task updateStaff(int id,Staff staff)
        {
               var _staff = await getStaff(id);

                _staff.Fullname = staff.Fullname;
                _staff.Description = staff.Description;
                _staff.Phone = staff.Phone;
                _staff.Position = staff.Position;
                _staff.SpecId = staff.SpecId;
                _staff.imgUrl = staff.imgUrl;
                _staff.modifiedAt = DateTime.Now;

                await _context.SaveChangesAsync();
        }

        public async Task deleteStaff(int id)
        {
            var staff = await getStaff(id);
            staff.softDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Staff>> getStaffList()
        {
            return await _context.Staff.Where(e => !e.softDeleted).OrderByDescending(e=>e.createdAt).ToListAsync();
        }

        public async Task<Staff> getStaff(int id)
        {
            var _staff = await _context.Staff.FirstOrDefaultAsync(s => s.Id == id && !s.softDeleted);
            if (_staff == null) throw new HttpException(404, "İşçi tapılmadı");

            return _staff;
        }
    }
}
