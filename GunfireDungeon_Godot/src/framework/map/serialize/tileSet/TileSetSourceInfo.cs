
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using DsUi;
using Godot;

/// <summary>
/// 图集资源数据
/// </summary>
public class TileSetSourceInfo : IClone<TileSetSourceInfo>, IDestroy
{
    [JsonIgnore]
    public bool IsDestroyed { get; private set; }
    
    /// <summary>
    /// 资源名称
    /// </summary>
    [JsonInclude]
    public string Name;

    /// <summary>
    /// 资源路径
    /// </summary>
    [JsonInclude]
    public string SourcePath;

    /// <summary>
    /// 地形配置数据
    /// </summary>
    [JsonInclude]
    public List<TileSetTerrainInfo> Terrain;

    /// <summary>
    /// 组合数据
    /// </summary>
    [JsonInclude]
    public List<TileCombinationInfo> Combination;
    
    [JsonIgnore]
    private Image _sourceImage;

    /// <summary>
    /// 初始化默认数据
    /// </summary>
    public void InitData()
    {
        Terrain = new List<TileSetTerrainInfo>();
        Combination = new List<TileCombinationInfo>();
    }

    /// <summary>
    /// 获取资源图像数据
    /// </summary>
    public Image GetSourceImage()
    {
        if (_sourceImage == null && string.IsNullOrEmpty(SourcePath))
        {
            return null;
        }

        if (File.Exists(SourcePath))
        {
            return _sourceImage ??= Image.LoadFromFile(SourcePath);
        }

        var texture2D = ResourceLoader.Load<Texture2D>("res://" + SourcePath);
        return _sourceImage ??= texture2D?.GetImage();
    }

    /// <summary>
    /// 设置图像资源
    /// </summary>
    public void SetSourceImage(Image image)
    {
        if (_sourceImage != null)
        {
            _sourceImage.Dispose();
        }
        _sourceImage = image;
    }

    public TileSetSourceInfo Clone()
    {
        var tileSetSourceInfo = new TileSetSourceInfo();
        tileSetSourceInfo.Name = Name;
        tileSetSourceInfo.Terrain = new List<TileSetTerrainInfo>();
        foreach (var item in Terrain)
        {
            tileSetSourceInfo.Terrain.Add(item.Clone());
        }
        tileSetSourceInfo.Combination = new List<TileCombinationInfo>();
        foreach (var combination in Combination)
        {
            tileSetSourceInfo.Combination.Add(combination.Clone());
        }
        tileSetSourceInfo.SourcePath = SourcePath;
        if (_sourceImage != null)
        {
            tileSetSourceInfo._sourceImage = (Image)_sourceImage.Duplicate();
        }

        return tileSetSourceInfo;
    }
    
    public void Destroy()
    {
        if (IsDestroyed) return;
        IsDestroyed = true;
        if (_sourceImage != null)
        {
            _sourceImage.Dispose();
            _sourceImage = null;
        }

        Terrain = null;
        Combination = null;
    }
}