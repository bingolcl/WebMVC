using AssetTracking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTracking.BLL.interfaces
{
    public interface IAssetManager
    {
        List<Asset> GetAll();
        void Add(Asset asset);
        Asset Find(int id);
        void Update(Asset asset);
        void Assign(Asset asset);

    }
}
