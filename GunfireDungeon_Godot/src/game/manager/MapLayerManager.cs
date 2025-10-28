using Godot;

public static class MapLayerManager
{
    public static void InitMapLayer(World world)
    {
        //删除之前的层级
        world.RemoveAllTileMapLayer();
        
        var autoFloorLayer = world.AddTileMapLayer(MapLayer.AutoFloorLayer);
        autoFloorLayer.ZIndex = -10;
        autoFloorLayer.NavigationEnabled = false;
        autoFloorLayer.Name = nameof(MapLayer.AutoFloorLayer);
        
        var customFloorLayer1 = world.AddTileMapLayer(MapLayer.CustomFloorLayer1);
        customFloorLayer1.ZIndex = -10;
        customFloorLayer1.NavigationEnabled = false;
        customFloorLayer1.Name = nameof(MapLayer.CustomFloorLayer1);
        
        var customFloorLayer2 = world.AddTileMapLayer(MapLayer.CustomFloorLayer2);
        customFloorLayer2.ZIndex = -10;
        customFloorLayer2.NavigationEnabled = false;
        customFloorLayer2.Name = nameof(MapLayer.CustomFloorLayer2);
        
        var customFloorLayer3 = world.AddTileMapLayer(MapLayer.CustomFloorLayer3);
        customFloorLayer3.ZIndex = -10;
        customFloorLayer3.NavigationEnabled = false;
        customFloorLayer3.Name = nameof(MapLayer.CustomFloorLayer3);
        
        var autoMiddleLayer = world.AddTileMapLayer(MapLayer.AutoMiddleLayer);
        autoMiddleLayer.ZIndex = 2;
        autoMiddleLayer.NavigationEnabled = false;
        autoMiddleLayer.YSortEnabled = true;
        autoMiddleLayer.Name = nameof(MapLayer.AutoMiddleLayer);
        
        var customMiddleLayer1 = world.AddTileMapLayer(MapLayer.CustomMiddleLayer1);
        customMiddleLayer1.ZIndex = 2;
        customMiddleLayer1.NavigationEnabled = false;
        customMiddleLayer1.YSortEnabled = true;
        customMiddleLayer1.Name = nameof(MapLayer.CustomMiddleLayer1);
        
        var customMiddleLayer2 = world.AddTileMapLayer(MapLayer.CustomMiddleLayer2);
        customMiddleLayer2.ZIndex = 2;
        customMiddleLayer2.NavigationEnabled = false;
        customMiddleLayer2.YSortEnabled = true;
        customMiddleLayer2.Name = nameof(MapLayer.CustomMiddleLayer2);
        
        var autoTopLayer = world.AddTileMapLayer(MapLayer.AutoTopLayer);
        autoTopLayer.ZIndex = 10;
        autoTopLayer.NavigationEnabled = false;
        autoTopLayer.Name = nameof(MapLayer.AutoTopLayer);
        
        var customTopLayer = world.AddTileMapLayer(MapLayer.CustomTopLayer);
        customTopLayer.ZIndex = 10;
        customTopLayer.NavigationEnabled = false;
        customTopLayer.Name = nameof(MapLayer.CustomTopLayer);
    }
}