namespace DsUi;

// 该类为自动生成的, 请不要手动编辑, 以免造成代码丢失
public static partial class UiManager
{

    public static class UiName
    {
        public const string Debug_Debugger = "debug/Debugger";
        public const string BottomTips = "BottomTips";
        public const string EditorColorPicker = "EditorColorPicker";
        public const string EditorDungeonGroup = "EditorDungeonGroup";
        public const string EditorForm = "EditorForm";
        public const string EditorImportCombination = "EditorImportCombination";
        public const string EditorInfo = "EditorInfo";
        public const string EditorInput = "EditorInput";
        public const string EditorManager = "EditorManager";
        public const string EditorTileImage = "EditorTileImage";
        public const string EditorTips = "EditorTips";
        public const string EditorTools = "EditorTools";
        public const string EditorWindow = "EditorWindow";
        public const string Encyclopedia = "Encyclopedia";
        public const string Loading = "Loading";
        public const string Main = "Main";
        public const string MapEditor = "MapEditor";
        public const string MapEditorConfigObject = "MapEditorConfigObject";
        public const string MapEditorCreateMark = "MapEditorCreateMark";
        public const string MapEditorCreatePreinstall = "MapEditorCreatePreinstall";
        public const string MapEditorCreateRoom = "MapEditorCreateRoom";
        public const string MapEditorMapLayer = "MapEditorMapLayer";
        public const string MapEditorMapMark = "MapEditorMapMark";
        public const string MapEditorMapTile = "MapEditorMapTile";
        public const string MapEditorObject = "MapEditorObject";
        public const string MapEditorProject = "MapEditorProject";
        public const string MapEditorSelectObject = "MapEditorSelectObject";
        public const string MapEditorTools = "MapEditorTools";
        public const string PauseMenu = "PauseMenu";
        public const string RoomMap = "RoomMap";
        public const string RoomUI = "RoomUI";
        public const string Setting = "Setting";
        public const string Settlement = "Settlement";
        public const string TileSetEditor = "TileSetEditor";
        public const string TileSetEditorCombination = "TileSetEditorCombination";
        public const string TileSetEditorImport = "TileSetEditorImport";
        public const string TileSetEditorProject = "TileSetEditorProject";
        public const string TileSetEditorTerrain = "TileSetEditorTerrain";
        public const string Victory = "Victory";
        public const string WeaponRoulette = "WeaponRoulette";
    }

    /// <summary>
    /// 打开 debug/Debugger, 并返回UI实例
    /// </summary>
    public static UI.debug.Debugger.DebuggerPanel Open_Debug_Debugger()
    {
        return OpenUi<UI.debug.Debugger.DebuggerPanel>(UiName.Debug_Debugger);
    }

    /// <summary>
    /// 销毁 debug/Debugger 的所有实例
    /// </summary>
    public static void Destroy_Debug_Debugger()
    {
        var uiInstance = GetUiInstance<UI.debug.Debugger.DebuggerPanel>(nameof(UI.debug.Debugger.Debugger));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 BottomTips, 并返回UI实例
    /// </summary>
    public static UI.BottomTips.BottomTipsPanel Open_BottomTips()
    {
        return OpenUi<UI.BottomTips.BottomTipsPanel>(UiName.BottomTips);
    }

    /// <summary>
    /// 销毁 BottomTips 的所有实例
    /// </summary>
    public static void Destroy_BottomTips()
    {
        var uiInstance = GetUiInstance<UI.BottomTips.BottomTipsPanel>(nameof(UI.BottomTips.BottomTips));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorColorPicker, 并返回UI实例
    /// </summary>
    public static UI.EditorColorPicker.EditorColorPickerPanel Open_EditorColorPicker()
    {
        return OpenUi<UI.EditorColorPicker.EditorColorPickerPanel>(UiName.EditorColorPicker);
    }

    /// <summary>
    /// 销毁 EditorColorPicker 的所有实例
    /// </summary>
    public static void Destroy_EditorColorPicker()
    {
        var uiInstance = GetUiInstance<UI.EditorColorPicker.EditorColorPickerPanel>(nameof(UI.EditorColorPicker.EditorColorPicker));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorDungeonGroup, 并返回UI实例
    /// </summary>
    public static UI.EditorDungeonGroup.EditorDungeonGroupPanel Open_EditorDungeonGroup()
    {
        return OpenUi<UI.EditorDungeonGroup.EditorDungeonGroupPanel>(UiName.EditorDungeonGroup);
    }

    /// <summary>
    /// 销毁 EditorDungeonGroup 的所有实例
    /// </summary>
    public static void Destroy_EditorDungeonGroup()
    {
        var uiInstance = GetUiInstance<UI.EditorDungeonGroup.EditorDungeonGroupPanel>(nameof(UI.EditorDungeonGroup.EditorDungeonGroup));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorForm, 并返回UI实例
    /// </summary>
    public static UI.EditorForm.EditorFormPanel Open_EditorForm()
    {
        return OpenUi<UI.EditorForm.EditorFormPanel>(UiName.EditorForm);
    }

    /// <summary>
    /// 销毁 EditorForm 的所有实例
    /// </summary>
    public static void Destroy_EditorForm()
    {
        var uiInstance = GetUiInstance<UI.EditorForm.EditorFormPanel>(nameof(UI.EditorForm.EditorForm));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorImportCombination, 并返回UI实例
    /// </summary>
    public static UI.EditorImportCombination.EditorImportCombinationPanel Open_EditorImportCombination()
    {
        return OpenUi<UI.EditorImportCombination.EditorImportCombinationPanel>(UiName.EditorImportCombination);
    }

    /// <summary>
    /// 销毁 EditorImportCombination 的所有实例
    /// </summary>
    public static void Destroy_EditorImportCombination()
    {
        var uiInstance = GetUiInstance<UI.EditorImportCombination.EditorImportCombinationPanel>(nameof(UI.EditorImportCombination.EditorImportCombination));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorInfo, 并返回UI实例
    /// </summary>
    public static UI.EditorInfo.EditorInfoPanel Open_EditorInfo()
    {
        return OpenUi<UI.EditorInfo.EditorInfoPanel>(UiName.EditorInfo);
    }

    /// <summary>
    /// 销毁 EditorInfo 的所有实例
    /// </summary>
    public static void Destroy_EditorInfo()
    {
        var uiInstance = GetUiInstance<UI.EditorInfo.EditorInfoPanel>(nameof(UI.EditorInfo.EditorInfo));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorInput, 并返回UI实例
    /// </summary>
    public static UI.EditorInput.EditorInputPanel Open_EditorInput()
    {
        return OpenUi<UI.EditorInput.EditorInputPanel>(UiName.EditorInput);
    }

    /// <summary>
    /// 销毁 EditorInput 的所有实例
    /// </summary>
    public static void Destroy_EditorInput()
    {
        var uiInstance = GetUiInstance<UI.EditorInput.EditorInputPanel>(nameof(UI.EditorInput.EditorInput));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorManager, 并返回UI实例
    /// </summary>
    public static UI.EditorManager.EditorManagerPanel Open_EditorManager()
    {
        return OpenUi<UI.EditorManager.EditorManagerPanel>(UiName.EditorManager);
    }

    /// <summary>
    /// 销毁 EditorManager 的所有实例
    /// </summary>
    public static void Destroy_EditorManager()
    {
        var uiInstance = GetUiInstance<UI.EditorManager.EditorManagerPanel>(nameof(UI.EditorManager.EditorManager));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorTileImage, 并返回UI实例
    /// </summary>
    public static UI.EditorTileImage.EditorTileImagePanel Open_EditorTileImage()
    {
        return OpenUi<UI.EditorTileImage.EditorTileImagePanel>(UiName.EditorTileImage);
    }

    /// <summary>
    /// 销毁 EditorTileImage 的所有实例
    /// </summary>
    public static void Destroy_EditorTileImage()
    {
        var uiInstance = GetUiInstance<UI.EditorTileImage.EditorTileImagePanel>(nameof(UI.EditorTileImage.EditorTileImage));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorTips, 并返回UI实例
    /// </summary>
    public static UI.EditorTips.EditorTipsPanel Open_EditorTips()
    {
        return OpenUi<UI.EditorTips.EditorTipsPanel>(UiName.EditorTips);
    }

    /// <summary>
    /// 销毁 EditorTips 的所有实例
    /// </summary>
    public static void Destroy_EditorTips()
    {
        var uiInstance = GetUiInstance<UI.EditorTips.EditorTipsPanel>(nameof(UI.EditorTips.EditorTips));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorTools, 并返回UI实例
    /// </summary>
    public static UI.EditorTools.EditorToolsPanel Open_EditorTools()
    {
        return OpenUi<UI.EditorTools.EditorToolsPanel>(UiName.EditorTools);
    }

    /// <summary>
    /// 销毁 EditorTools 的所有实例
    /// </summary>
    public static void Destroy_EditorTools()
    {
        var uiInstance = GetUiInstance<UI.EditorTools.EditorToolsPanel>(nameof(UI.EditorTools.EditorTools));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 EditorWindow, 并返回UI实例
    /// </summary>
    public static UI.EditorWindow.EditorWindowPanel Open_EditorWindow()
    {
        return OpenUi<UI.EditorWindow.EditorWindowPanel>(UiName.EditorWindow);
    }

    /// <summary>
    /// 销毁 EditorWindow 的所有实例
    /// </summary>
    public static void Destroy_EditorWindow()
    {
        var uiInstance = GetUiInstance<UI.EditorWindow.EditorWindowPanel>(nameof(UI.EditorWindow.EditorWindow));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 Encyclopedia, 并返回UI实例
    /// </summary>
    public static UI.Encyclopedia.EncyclopediaPanel Open_Encyclopedia()
    {
        return OpenUi<UI.Encyclopedia.EncyclopediaPanel>(UiName.Encyclopedia);
    }

    /// <summary>
    /// 销毁 Encyclopedia 的所有实例
    /// </summary>
    public static void Destroy_Encyclopedia()
    {
        var uiInstance = GetUiInstance<UI.Encyclopedia.EncyclopediaPanel>(nameof(UI.Encyclopedia.Encyclopedia));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 Loading, 并返回UI实例
    /// </summary>
    public static UI.Loading.LoadingPanel Open_Loading()
    {
        return OpenUi<UI.Loading.LoadingPanel>(UiName.Loading);
    }

    /// <summary>
    /// 销毁 Loading 的所有实例
    /// </summary>
    public static void Destroy_Loading()
    {
        var uiInstance = GetUiInstance<UI.Loading.LoadingPanel>(nameof(UI.Loading.Loading));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 Main, 并返回UI实例
    /// </summary>
    public static UI.Main.MainPanel Open_Main()
    {
        return OpenUi<UI.Main.MainPanel>(UiName.Main);
    }

    /// <summary>
    /// 销毁 Main 的所有实例
    /// </summary>
    public static void Destroy_Main()
    {
        var uiInstance = GetUiInstance<UI.Main.MainPanel>(nameof(UI.Main.Main));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditor, 并返回UI实例
    /// </summary>
    public static UI.MapEditor.MapEditorPanel Open_MapEditor()
    {
        return OpenUi<UI.MapEditor.MapEditorPanel>(UiName.MapEditor);
    }

    /// <summary>
    /// 销毁 MapEditor 的所有实例
    /// </summary>
    public static void Destroy_MapEditor()
    {
        var uiInstance = GetUiInstance<UI.MapEditor.MapEditorPanel>(nameof(UI.MapEditor.MapEditor));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorConfigObject, 并返回UI实例
    /// </summary>
    public static UI.MapEditorConfigObject.MapEditorConfigObjectPanel Open_MapEditorConfigObject()
    {
        return OpenUi<UI.MapEditorConfigObject.MapEditorConfigObjectPanel>(UiName.MapEditorConfigObject);
    }

    /// <summary>
    /// 销毁 MapEditorConfigObject 的所有实例
    /// </summary>
    public static void Destroy_MapEditorConfigObject()
    {
        var uiInstance = GetUiInstance<UI.MapEditorConfigObject.MapEditorConfigObjectPanel>(nameof(UI.MapEditorConfigObject.MapEditorConfigObject));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorCreateMark, 并返回UI实例
    /// </summary>
    public static UI.MapEditorCreateMark.MapEditorCreateMarkPanel Open_MapEditorCreateMark()
    {
        return OpenUi<UI.MapEditorCreateMark.MapEditorCreateMarkPanel>(UiName.MapEditorCreateMark);
    }

    /// <summary>
    /// 销毁 MapEditorCreateMark 的所有实例
    /// </summary>
    public static void Destroy_MapEditorCreateMark()
    {
        var uiInstance = GetUiInstance<UI.MapEditorCreateMark.MapEditorCreateMarkPanel>(nameof(UI.MapEditorCreateMark.MapEditorCreateMark));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorCreatePreinstall, 并返回UI实例
    /// </summary>
    public static UI.MapEditorCreatePreinstall.MapEditorCreatePreinstallPanel Open_MapEditorCreatePreinstall()
    {
        return OpenUi<UI.MapEditorCreatePreinstall.MapEditorCreatePreinstallPanel>(UiName.MapEditorCreatePreinstall);
    }

    /// <summary>
    /// 销毁 MapEditorCreatePreinstall 的所有实例
    /// </summary>
    public static void Destroy_MapEditorCreatePreinstall()
    {
        var uiInstance = GetUiInstance<UI.MapEditorCreatePreinstall.MapEditorCreatePreinstallPanel>(nameof(UI.MapEditorCreatePreinstall.MapEditorCreatePreinstall));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorCreateRoom, 并返回UI实例
    /// </summary>
    public static UI.MapEditorCreateRoom.MapEditorCreateRoomPanel Open_MapEditorCreateRoom()
    {
        return OpenUi<UI.MapEditorCreateRoom.MapEditorCreateRoomPanel>(UiName.MapEditorCreateRoom);
    }

    /// <summary>
    /// 销毁 MapEditorCreateRoom 的所有实例
    /// </summary>
    public static void Destroy_MapEditorCreateRoom()
    {
        var uiInstance = GetUiInstance<UI.MapEditorCreateRoom.MapEditorCreateRoomPanel>(nameof(UI.MapEditorCreateRoom.MapEditorCreateRoom));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorMapLayer, 并返回UI实例
    /// </summary>
    public static UI.MapEditorMapLayer.MapEditorMapLayerPanel Open_MapEditorMapLayer()
    {
        return OpenUi<UI.MapEditorMapLayer.MapEditorMapLayerPanel>(UiName.MapEditorMapLayer);
    }

    /// <summary>
    /// 销毁 MapEditorMapLayer 的所有实例
    /// </summary>
    public static void Destroy_MapEditorMapLayer()
    {
        var uiInstance = GetUiInstance<UI.MapEditorMapLayer.MapEditorMapLayerPanel>(nameof(UI.MapEditorMapLayer.MapEditorMapLayer));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorMapMark, 并返回UI实例
    /// </summary>
    public static UI.MapEditorMapMark.MapEditorMapMarkPanel Open_MapEditorMapMark()
    {
        return OpenUi<UI.MapEditorMapMark.MapEditorMapMarkPanel>(UiName.MapEditorMapMark);
    }

    /// <summary>
    /// 销毁 MapEditorMapMark 的所有实例
    /// </summary>
    public static void Destroy_MapEditorMapMark()
    {
        var uiInstance = GetUiInstance<UI.MapEditorMapMark.MapEditorMapMarkPanel>(nameof(UI.MapEditorMapMark.MapEditorMapMark));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorMapTile, 并返回UI实例
    /// </summary>
    public static UI.MapEditorMapTile.MapEditorMapTilePanel Open_MapEditorMapTile()
    {
        return OpenUi<UI.MapEditorMapTile.MapEditorMapTilePanel>(UiName.MapEditorMapTile);
    }

    /// <summary>
    /// 销毁 MapEditorMapTile 的所有实例
    /// </summary>
    public static void Destroy_MapEditorMapTile()
    {
        var uiInstance = GetUiInstance<UI.MapEditorMapTile.MapEditorMapTilePanel>(nameof(UI.MapEditorMapTile.MapEditorMapTile));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorObject, 并返回UI实例
    /// </summary>
    public static UI.MapEditorObject.MapEditorObjectPanel Open_MapEditorObject()
    {
        return OpenUi<UI.MapEditorObject.MapEditorObjectPanel>(UiName.MapEditorObject);
    }

    /// <summary>
    /// 销毁 MapEditorObject 的所有实例
    /// </summary>
    public static void Destroy_MapEditorObject()
    {
        var uiInstance = GetUiInstance<UI.MapEditorObject.MapEditorObjectPanel>(nameof(UI.MapEditorObject.MapEditorObject));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorProject, 并返回UI实例
    /// </summary>
    public static UI.MapEditorProject.MapEditorProjectPanel Open_MapEditorProject()
    {
        return OpenUi<UI.MapEditorProject.MapEditorProjectPanel>(UiName.MapEditorProject);
    }

    /// <summary>
    /// 销毁 MapEditorProject 的所有实例
    /// </summary>
    public static void Destroy_MapEditorProject()
    {
        var uiInstance = GetUiInstance<UI.MapEditorProject.MapEditorProjectPanel>(nameof(UI.MapEditorProject.MapEditorProject));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorSelectObject, 并返回UI实例
    /// </summary>
    public static UI.MapEditorSelectObject.MapEditorSelectObjectPanel Open_MapEditorSelectObject()
    {
        return OpenUi<UI.MapEditorSelectObject.MapEditorSelectObjectPanel>(UiName.MapEditorSelectObject);
    }

    /// <summary>
    /// 销毁 MapEditorSelectObject 的所有实例
    /// </summary>
    public static void Destroy_MapEditorSelectObject()
    {
        var uiInstance = GetUiInstance<UI.MapEditorSelectObject.MapEditorSelectObjectPanel>(nameof(UI.MapEditorSelectObject.MapEditorSelectObject));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 MapEditorTools, 并返回UI实例
    /// </summary>
    public static UI.MapEditorTools.MapEditorToolsPanel Open_MapEditorTools()
    {
        return OpenUi<UI.MapEditorTools.MapEditorToolsPanel>(UiName.MapEditorTools);
    }

    /// <summary>
    /// 销毁 MapEditorTools 的所有实例
    /// </summary>
    public static void Destroy_MapEditorTools()
    {
        var uiInstance = GetUiInstance<UI.MapEditorTools.MapEditorToolsPanel>(nameof(UI.MapEditorTools.MapEditorTools));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 PauseMenu, 并返回UI实例
    /// </summary>
    public static UI.PauseMenu.PauseMenuPanel Open_PauseMenu()
    {
        return OpenUi<UI.PauseMenu.PauseMenuPanel>(UiName.PauseMenu);
    }

    /// <summary>
    /// 销毁 PauseMenu 的所有实例
    /// </summary>
    public static void Destroy_PauseMenu()
    {
        var uiInstance = GetUiInstance<UI.PauseMenu.PauseMenuPanel>(nameof(UI.PauseMenu.PauseMenu));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 RoomMap, 并返回UI实例
    /// </summary>
    public static UI.RoomMap.RoomMapPanel Open_RoomMap()
    {
        return OpenUi<UI.RoomMap.RoomMapPanel>(UiName.RoomMap);
    }

    /// <summary>
    /// 销毁 RoomMap 的所有实例
    /// </summary>
    public static void Destroy_RoomMap()
    {
        var uiInstance = GetUiInstance<UI.RoomMap.RoomMapPanel>(nameof(UI.RoomMap.RoomMap));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 RoomUI, 并返回UI实例
    /// </summary>
    public static UI.RoomUI.RoomUIPanel Open_RoomUI()
    {
        return OpenUi<UI.RoomUI.RoomUIPanel>(UiName.RoomUI);
    }

    /// <summary>
    /// 销毁 RoomUI 的所有实例
    /// </summary>
    public static void Destroy_RoomUI()
    {
        var uiInstance = GetUiInstance<UI.RoomUI.RoomUIPanel>(nameof(UI.RoomUI.RoomUI));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 Setting, 并返回UI实例
    /// </summary>
    public static UI.Setting.SettingPanel Open_Setting()
    {
        return OpenUi<UI.Setting.SettingPanel>(UiName.Setting);
    }

    /// <summary>
    /// 销毁 Setting 的所有实例
    /// </summary>
    public static void Destroy_Setting()
    {
        var uiInstance = GetUiInstance<UI.Setting.SettingPanel>(nameof(UI.Setting.Setting));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 Settlement, 并返回UI实例
    /// </summary>
    public static UI.Settlement.SettlementPanel Open_Settlement()
    {
        return OpenUi<UI.Settlement.SettlementPanel>(UiName.Settlement);
    }

    /// <summary>
    /// 销毁 Settlement 的所有实例
    /// </summary>
    public static void Destroy_Settlement()
    {
        var uiInstance = GetUiInstance<UI.Settlement.SettlementPanel>(nameof(UI.Settlement.Settlement));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 TileSetEditor, 并返回UI实例
    /// </summary>
    public static UI.TileSetEditor.TileSetEditorPanel Open_TileSetEditor()
    {
        return OpenUi<UI.TileSetEditor.TileSetEditorPanel>(UiName.TileSetEditor);
    }

    /// <summary>
    /// 销毁 TileSetEditor 的所有实例
    /// </summary>
    public static void Destroy_TileSetEditor()
    {
        var uiInstance = GetUiInstance<UI.TileSetEditor.TileSetEditorPanel>(nameof(UI.TileSetEditor.TileSetEditor));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 TileSetEditorCombination, 并返回UI实例
    /// </summary>
    public static UI.TileSetEditorCombination.TileSetEditorCombinationPanel Open_TileSetEditorCombination()
    {
        return OpenUi<UI.TileSetEditorCombination.TileSetEditorCombinationPanel>(UiName.TileSetEditorCombination);
    }

    /// <summary>
    /// 销毁 TileSetEditorCombination 的所有实例
    /// </summary>
    public static void Destroy_TileSetEditorCombination()
    {
        var uiInstance = GetUiInstance<UI.TileSetEditorCombination.TileSetEditorCombinationPanel>(nameof(UI.TileSetEditorCombination.TileSetEditorCombination));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 TileSetEditorImport, 并返回UI实例
    /// </summary>
    public static UI.TileSetEditorImport.TileSetEditorImportPanel Open_TileSetEditorImport()
    {
        return OpenUi<UI.TileSetEditorImport.TileSetEditorImportPanel>(UiName.TileSetEditorImport);
    }

    /// <summary>
    /// 销毁 TileSetEditorImport 的所有实例
    /// </summary>
    public static void Destroy_TileSetEditorImport()
    {
        var uiInstance = GetUiInstance<UI.TileSetEditorImport.TileSetEditorImportPanel>(nameof(UI.TileSetEditorImport.TileSetEditorImport));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 TileSetEditorProject, 并返回UI实例
    /// </summary>
    public static UI.TileSetEditorProject.TileSetEditorProjectPanel Open_TileSetEditorProject()
    {
        return OpenUi<UI.TileSetEditorProject.TileSetEditorProjectPanel>(UiName.TileSetEditorProject);
    }

    /// <summary>
    /// 销毁 TileSetEditorProject 的所有实例
    /// </summary>
    public static void Destroy_TileSetEditorProject()
    {
        var uiInstance = GetUiInstance<UI.TileSetEditorProject.TileSetEditorProjectPanel>(nameof(UI.TileSetEditorProject.TileSetEditorProject));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 TileSetEditorTerrain, 并返回UI实例
    /// </summary>
    public static UI.TileSetEditorTerrain.TileSetEditorTerrainPanel Open_TileSetEditorTerrain()
    {
        return OpenUi<UI.TileSetEditorTerrain.TileSetEditorTerrainPanel>(UiName.TileSetEditorTerrain);
    }

    /// <summary>
    /// 销毁 TileSetEditorTerrain 的所有实例
    /// </summary>
    public static void Destroy_TileSetEditorTerrain()
    {
        var uiInstance = GetUiInstance<UI.TileSetEditorTerrain.TileSetEditorTerrainPanel>(nameof(UI.TileSetEditorTerrain.TileSetEditorTerrain));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 Victory, 并返回UI实例
    /// </summary>
    public static UI.Victory.VictoryPanel Open_Victory()
    {
        return OpenUi<UI.Victory.VictoryPanel>(UiName.Victory);
    }

    /// <summary>
    /// 销毁 Victory 的所有实例
    /// </summary>
    public static void Destroy_Victory()
    {
        var uiInstance = GetUiInstance<UI.Victory.VictoryPanel>(nameof(UI.Victory.Victory));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 WeaponRoulette, 并返回UI实例
    /// </summary>
    public static UI.WeaponRoulette.WeaponRoulettePanel Open_WeaponRoulette()
    {
        return OpenUi<UI.WeaponRoulette.WeaponRoulettePanel>(UiName.WeaponRoulette);
    }

    /// <summary>
    /// 销毁 WeaponRoulette 的所有实例
    /// </summary>
    public static void Destroy_WeaponRoulette()
    {
        var uiInstance = GetUiInstance<UI.WeaponRoulette.WeaponRoulettePanel>(nameof(UI.WeaponRoulette.WeaponRoulette));
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

}
