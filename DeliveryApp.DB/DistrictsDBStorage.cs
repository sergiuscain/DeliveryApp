using DeliveryApp.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.DB
{
    public class DistrictsDBStorage : IDistrictStorage
    {
        private readonly DeliveryAppDBContext dbContext;
        public DistrictsDBStorage(DeliveryAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<District> GetAllDistricts()
        {
            return dbContext.Districts.ToList();
        }
        public void Add(District district)
        {
            dbContext.Districts.Add(district);
            dbContext.SaveChanges();
        }
        public void Remove(District district)
        {
            dbContext.Districts.Remove(district);
            dbContext.SaveChanges();
        }
        public District GetByName(string name)
        {
            var district = dbContext.Districts.FirstOrDefault(x => x.Name == name);
            return district;
        }
    }
}
