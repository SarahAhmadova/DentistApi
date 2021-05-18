using MedicApp.Data.Entities;
using MedicApp.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Services
{
    public interface ISpecialityService
    {
        public Task<IEnumerable<Speciality>> getSpecList();
        public Task<Speciality> addSpeciality(Speciality spec);
        public Task deleteSpeciality(int id);
        public Task updateSpeciality(int id, Speciality spec);
        public Task<Speciality> getSpeciality(int id);
    }
    public class SpecialityService : ISpecialityService
    {
        private readonly AppDbContext _context;
        public SpecialityService(AppDbContext context)
        {
            _context = context;
        }
          

        public async Task<IEnumerable<Speciality>> getSpecList()
        {
            return await _context.Specialities.Where(e=>!e.softDeleted).OrderByDescending(e => e.createdAt).ToListAsync();
        }

        public async Task<Speciality> addSpeciality(Speciality spec)
        {
            var _spec =  _context.Specialities.FirstOrDefault(s => s.name == spec.name);
            if (_spec != null) throw new HttpException(400, "Bu ixtisas artıq mövcuddur.");
            else
            {

                await _context.Specialities.AddAsync(spec);
                await _context.SaveChangesAsync();
                return spec;
            }
        }

        public async Task deleteSpeciality(int id)
        {
            var spec = await getSpeciality(id);
            spec.softDeleted = true;

            await _context.SaveChangesAsync();
        }

        public async Task updateSpeciality(int id, Speciality spec)
        {
            var _spec = await getSpeciality(id);
            var findName = await _context.Specialities.FirstOrDefaultAsync(e => e.name == spec.name && e.Id != id && !e.softDeleted);
            if(findName!=null) throw new HttpException(400, "Bu ixtisas artıq mövcuddur.");

            _spec.name = spec.name;
            _spec.modifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<Speciality> getSpeciality(int id)
        {
            var spec =await  _context.Specialities.FirstOrDefaultAsync(e => e.Id == id && !e.softDeleted);
            if (spec == null) throw new HttpException(404, "Kategoriya mövcud deyil");

            return spec;
        }
    }
    
}
