﻿using AssetTracking.BLL.interfaces;
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
    public class AssetManager:IAssetManager
    {
        AssetContext _assetContext { get; set; }

        public AssetManager(AssetContext context)
        {
            _assetContext = context;
        }

        public List<Asset> GetAll()
        {
            var assets = _assetContext.Assets.
                            Include(a => a.AssetType).
                            Include(a => a.Model).
                            ToList();
            return assets;
        }

        public void Add(Asset asset)
        {
            _assetContext.Assets.Add(asset);
            _assetContext.SaveChanges();
        }

        public Asset Find(int id)
        {
            var asset = _assetContext.Assets.Find(id);
            return asset;
        }

        public void Update(Asset asset)
        {
            var a = _assetContext.Assets.Find(asset.Id);
            a.ModelId = asset.ModelId;
            a.SerialNumber = asset.SerialNumber;
            a.TagNumber = asset.TagNumber;
            a.AssetTypeId = asset.AssetTypeId;
            a.Description = asset.Description;

            _assetContext.SaveChanges();
        }

        public void Assign(Asset asset)
        {
            var a = _assetContext.Assets.Find(asset.Id);
            a.AssignedTo = asset.AssignedTo;
            _assetContext.SaveChanges();
        }
    }

}
