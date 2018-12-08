using AssetTracking.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTracking.BLL.interfaces
{
    public interface IAssetTypeManager
    {
        List<AssetType> GetAll();
        void Add(AssetType type);
        AssetType Find(int id);
        void Update(AssetType assetType);

    }
}
