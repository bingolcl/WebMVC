using AssetTracking.Data;
using AssetTracking.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetTracking.BLL
{
    public class ModelManger
    {
        public static AssetContext _assetContext = new AssetContext();
        public static List<Model> GetAll()
        {
            var models = _assetContext.Models.
                            Include(m => m.Manufacturer).
                            ToList();
            return models;
        }

        public static void Add(Model model)
        {
            _assetContext.Models.Add(model);
            _assetContext.SaveChanges();
        }

        public static Model Find(int id)
        {
            var model = _assetContext.Models.Find(id);
            return model;
        }

        public static void Update(Model model)
        {
            var m = _assetContext.Models.Find(model.Id);
            m.Name = model.Name;
            _assetContext.SaveChanges();
        }
    }

}
