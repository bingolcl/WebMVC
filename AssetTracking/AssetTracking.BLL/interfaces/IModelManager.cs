using AssetTracking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTracking.BLL.interfaces
{
    public interface IModelManager
    {
        List<Model> GetAll();
        void Add(Model model);
        Model Find(int id);
        void Update(Model model);

    }
}
