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
    public interface IMedserviceService
    {
        public Task<Medservices> getService(int id);
        public Task<IEnumerable<Medservices>> getServices();
        public Task<Medservices> addService(Medservices service);
        public Task updateService(int id, Medservices service);
        public Task deleteService(int id);


    }
    public class MedservicesService : IMedserviceService
    {
        private readonly AppDbContext _context;
        public MedservicesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Medservices> addService(Medservices service)
        {
            var _service = await _context.Services.FirstOrDefaultAsync(e => e.Name == service.Name);
            if (_service != null) throw new HttpException(400, "Bu xidmət artıq mövcuddur.");

            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task deleteService(int id)
        {
            var service = await getService(id);
            service.softDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Medservices> getService(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(e => e.Id == id && !e.softDeleted);
            if(service==null) throw new HttpException(404, "Bu xidmət mövcud deyil.");

            return service;
        }

        public async Task<IEnumerable<Medservices>> getServices()
        {
            return await _context.Services.Where(e => !e.softDeleted).OrderByDescending(e => e.createdAt).ToListAsync(); ;
        }

        public async Task updateService(int id,Medservices service)
        {
            var _service = await getService(id);
            _service.Name = service.Name;
            var findName = await _context.Services.FirstOrDefaultAsync(e => e.Name == service.Name && e.Id != id && !e.softDeleted);
            if (findName != null) throw new HttpException(400, "Bu xidmət artıq mövcuddur.");

            _service.Description = service.Description;
            _service.ImgPath = service.ImgPath;
            _service.modifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}
