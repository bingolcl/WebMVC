using AssetTracking.Data;
using AssetTracking.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetTracking.BLL
{
    public class AssetTypeManager
    {
        public static AssetContext _assetContext = new AssetContext();
        public static IList GetAsKeyValuePairs()
        {
            var types = _assetContext.AssetTypes.Select(at => new
            {
                at.Id,
                at.Name
            }).ToList();
            return types;
        }

        public static List<AssetType> GetAll()
        {
            var types = _assetContext.AssetTypes.ToList();
            return types;
        }

        public static void Add(AssetType type)
        {
            _assetContext.AssetTypes.Add(type);
            _assetContext.SaveChanges();
        }

        public static AssetType Find(int id)
        {
            var assetType = _assetContext.AssetTypes.Find(id);
            return assetType;
        }

        public static void Update(AssetType assetType)
        {
            var at = _assetContext.AssetTypes.Find(assetType.Id);
            at.Name = assetType.Name;
            _assetContext.SaveChanges();
        }
    }
}
