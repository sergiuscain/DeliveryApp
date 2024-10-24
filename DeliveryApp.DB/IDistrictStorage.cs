using DeliveryApp.DB.Models;

namespace DeliveryApp.DB
{
    public interface IDistrictStorage
    {
        void Add(District district);
        List<District> GetAllDistricts();
        void Remove(District district);
        District GetByName(string name);
    }
}