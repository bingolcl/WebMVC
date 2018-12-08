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
    public class AssetTypeManager : IAssetTypeManager
    {
        AssetContext _assetContext { get; set; }

        public AssetTypeManager(AssetContext context)
        {
            _assetContext = context;
        }

        //public static IList GetAsKeyValuePairs()
        //{
        //    var types = _assetContext.AssetTypes.Select(at => new
        //    {
        //        at.Id,
        //        at.Name
        //    }).ToList();
        //    return types;
        //}

        public  List<AssetType> GetAll()
        {
            var types = _assetContext.AssetTypes.ToList();
            return types;
        }

        public  void Add(AssetType type)
        {
            _assetContext.AssetTypes.Add(type);
            _assetContext.SaveChanges();
        }

        public  AssetType Find(int id)
        {
            var assetType = _assetContext.AssetTypes.Find(id);
            return assetType;
        }

        public  void Update(AssetType assetType)
        {
            var at = _assetContext.AssetTypes.Find(assetType.Id);
            at.Name = assetType.Name;
            _assetContext.SaveChanges();
        }
    }
}
