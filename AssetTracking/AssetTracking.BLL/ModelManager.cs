using AssetTracking.BLL.interfaces;
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
    public class ModelManager: IModelManager
    {
        AssetContext _assetContext { get; set; }

        public ModelManager(AssetContext context)
        {
            _assetContext = context;
        }
        public List<Model> GetAll()
        {
            var models = _assetContext.Models.
                            Include(m => m.Manufacturer).
                            ToList();
            return models;
        }

        public void Add(Model model)
        {
            _assetContext.Models.Add(model);
            _assetContext.SaveChanges();
        }

        public Model Find(int id)
        {
            var model = _assetContext.Models.Find(id);
            return model;
        }

        public void Update(Model model)
        {
            var m = _assetContext.Models.Find(model.Id);
            m.Name = model.Name;
            _assetContext.SaveChanges();
        }
    }

}
