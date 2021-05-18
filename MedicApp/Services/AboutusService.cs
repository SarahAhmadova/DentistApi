using MedicApp.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Services
{
    public interface IAboutusService
    {
        public Task<aboutus> getData();
        public Task updateData(aboutus data);
    }
    public class AboutusService
    {
       
    }
}
