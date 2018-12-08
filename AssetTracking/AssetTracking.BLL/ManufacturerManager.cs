using AssetTracking.BLL.interfaces;
using AssetTracking.Data;
using AssetTracking.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetTracking.BLL
{
    public class ManufacturerManager: IManufacturerManager
    {
        AssetContext _assetContext { get; set; }

        public ManufacturerManager(AssetContext context)
        {
            _assetContext = context;
        }
        //public static IList GetAsKeyValuePairs()
        //{
        //    var manufacturers = _assetContext.Manufacturers.Select(m => new
        //    {
        //        m.Id,
        //        m.Name
        //    }).ToList();
        //    return manufacturers;
        //}

        public List<Manufacturer> GetAll()
        {
            var manufacturers = _assetContext.Manufacturers.ToList();
            return manufacturers;
        }

        public void Add(Manufacturer manufacturer)
        {
            _assetContext.Manufacturers.Add(manufacturer);
            _assetContext.SaveChanges();
        }

        public Manufacturer Find(int id)
        {
            var manufacturer = _assetContext.Manufacturers.Find(id);
            return manufacturer;
        }

        public void Update(Manufacturer manufacturer)
        {
            var m = _assetContext.Manufacturers.Find(manufacturer.Id);
            m.Name = manufacturer.Name;
            _assetContext.SaveChanges();
        }
    }
}
