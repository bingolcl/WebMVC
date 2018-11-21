using AssetTracking.Data;
using AssetTracking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracking.BLL
{
    public class AssetManager
    {
        public static List<Asset> GetAll()
        {
            var context = new AssetContext();
            var assets = context.Assets.ToList();
            return assets;
        }

        public static void Add(Asset asset)
        {
            var context = new AssetContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }
    }

}
