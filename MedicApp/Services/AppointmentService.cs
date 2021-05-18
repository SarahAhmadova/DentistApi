using MedicApp.Data.Entities;
using MedicApp.Data.Entities.Admin;
using MedicApp.Data.Entities.Client;
using MedicApp.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Services
{
    public interface IAppointmentService
    {
        public Task<IEnumerable<ClientAppointment>> getClientAppointments();
        public Task<IEnumerable<Appointments>> getAdminAppointments();
        public Task<Appointments> addAppointment(Appointments app);

        //public Task updateAppointment(int id, Medservices service);
        //public Task deleteAppointment(int id);


    }
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;
        public AppointmentService(AppDbContext context)
        {
            _context  = context;
        }
      

        public async Task<IEnumerable<ClientAppointment>> getClientAppointments()
        {
            return await _context.ClientAppointment.ToListAsync();
        }

        public async Task<IEnumerable<Appointments>> getAdminAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointments> addAppointment(Appointments app)
        {
            var _app = await _context.Appointments.FirstOrDefaultAsync(a => a.Date == app.Date && a.Time == app.Time && a.DoctorId == app.DoctorId);
            if (_app != null) throw new HttpException(400, "Qeydiyyat mümkün deyil.");
            
            await _context.Appointments.AddAsync(app);
            await _context.SaveChangesAsync();
            return app;
        }
    }
}
