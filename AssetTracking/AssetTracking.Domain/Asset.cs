using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTracking.Domain
{
    [Table("Asset")]
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        public string TagNumber { get; set; }
        [Required]
        public string Description { get; set; }        
        [Required]
        public string SerialNumber { get; set; }
        public int AssetTypeId { get; set; }
        public int ModelId { get; set; }
        public string AssignedTo { get; set; }

        //navigation properties
        public Model Model { get; set; }
        public AssetType AssetType { get; set; }
    }
}
