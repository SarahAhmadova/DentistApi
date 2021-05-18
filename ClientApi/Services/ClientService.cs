using ClientApi.Data;
using ClientApi.Data.Entities;
using ClientApi.Infrastructure.Exceptions;
using ClientApi.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Services
{
    public interface IClientService
    {
        public Task<IEnumerable<StaffResource>> getStaffList();
        public Task<IEnumerable<ServiceResource>> getServiceList();
        public Task<StaffResource> getStaff(int id);
        public Task<AppointmentResource> addAppointment(AppointmentResource resource);
    }
    public class ClientService : IClientService
    {
        private readonly AppDbContext _context;
        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceResource>> getServiceList()
        {

            return await _context.Services.Where(e => !e.softDeleted).OrderByDescending(e => e.createdAt).ToListAsync();
        }

        public async Task<StaffResource> getStaff(int id)
        {
            var _staff = await _context.Staff.FirstOrDefaultAsync(s => s.Id == id && !s.softDeleted);
            if (_staff == null) throw new HttpException(404, "İşçi tapılmadı");

            return _staff;
        }

        public async Task<IEnumerable<StaffResource>> getStaffList()
        {
            return await _context.Staff.Where(e => !e.softDeleted).OrderByDescending(e => e.createdAt).ToListAsync();
        }

        public async Task<AppointmentResource> addAppointment(AppointmentResource resource)
        {

            var _appointment = await _context.ClientAppointment.FirstOrDefaultAsync(e => e.Time == resource.Time && e.Phone == resource.Phone);
            if (_appointment != null) throw new HttpException(400, "Siz artıq qeydiyyatdan keçmisiniz.");

            await _context.ClientAppointment.AddAsync(resource);
            await _context.SaveChangesAsync();

            return resource;
        }
    }
}
