using AssetTracking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTracking.BLL.interfaces
{
    public interface IManufacturerManager
    {
        List<Manufacturer> GetAll();
        void Add(Manufacturer manufacturer);
        Manufacturer Find(int id);
        void Update(Manufacturer manufacturer);

    }
}
