﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssetTracking.Domain
{
    [Table("Model")]
    public class Model
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        //navigation property
        public ICollection<Asset> Assets { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
