using System.ComponentModel.DataAnnotations.Schema;

namespace BaiThiThucHanh2025.Models;

public class PlayerAsset
{   
    
    [ForeignKey("Player")]
    public int PlayerId { get; set; }
    
    [ForeignKey("Asset")]
    public int AssetId { get; set; }
}