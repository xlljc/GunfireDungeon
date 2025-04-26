namespace DsUi;

// 该类为自动生成的, 请不要手动编辑, 以免造成代码丢失
public static partial class UiManager
{

    public static class UiName
    {
        public const string Debug_Debugger = "debug/Debugger";
        public const string Develop_EditorTools = "develop/EditorTools";
        public const string Editor_EditorColorPicker = "editor/EditorColorPicker";
        public const string Editor_EditorDungeonGroup = "editor/EditorDungeonGroup";
        public const string Editor_EditorForm = "editor/EditorForm";
        public const string Editor_EditorImportCombination = "editor/EditorImportCombination";
        public const string Editor_EditorInfo = "editor/EditorInfo";
        public const string Editor_EditorInput = "editor/EditorInput";
        public const string Editor_EditorManager = "editor/EditorManager";
        public const string Editor_EditorTileImage = "editor/EditorTileImage";
        public const string Editor_EditorTips = "editor/EditorTips";
        public const string Editor_EditorWindow = "editor/EditorWindow";
        public const string Editor_MapEditor = "editor/MapEditor";
        public const string Editor_MapEditorConfigObject = "editor/MapEditorConfigObject";
        public const string Editor_MapEditorCreateMark = "editor/MapEditorCreateMark";
        public const string Editor_MapEditorCreatePreinstall = "editor/MapEditorCreatePreinstall";
        public const string Editor_MapEditorCreateRoom = "editor/MapEditorCreateRoom";
        public const string Editor_MapEditorMapLayer = "editor/MapEditorMapLayer";
        public const string Editor_MapEditorMapMark = "editor/MapEditorMapMark";
        public const string Editor_MapEditorMapTile = "editor/MapEditorMapTile";
        public const string Editor_MapEditorObject = "editor/MapEditorObject";
        public const string Editor_MapEditorProject = "editor/MapEditorProject";
        public const string Editor_MapEditorSelectObject = "editor/MapEditorSelectObject";
        public const string Editor_MapEditorTools = "editor/MapEditorTools";
        public const string Editor_TileSetEditor = "editor/TileSetEditor";
        public const string Editor_TileSetEditorCombination = "editor/TileSetEditorCombination";
        public const string Editor_TileSetEditorImport = "editor/TileSetEditorImport";
        public const string Editor_TileSetEditorProject = "editor/TileSetEditorProject";
        public const string Editor_TileSetEditorTerrain = "editor/TileSetEditorTerrain";
        public const string Game_BottomTips = "game/BottomTips";
        public const string Game_Encyclopedia = "game/Encyclopedia";
        public const string Game_Loading = "game/Loading";
        public const string Game_Main = "game/Main";
        public const string Game_PartPackUI = "game/PartPackUI";
        public const string Game_PartTips = "game/PartTips";
        public const string Game_PauseMenu = "game/PauseMenu";
        public const string Game_RoomMap = "game/RoomMap";
        public const string Game_RoomUI = "game/RoomUI";
        public const string Game_Setting = "game/Setting";
        public const string Game_Settlement = "game/Settlement";
        public const string Game_Victory = "game/Victory";
        public const string Game_WeaponRoulette = "game/WeaponRoulette";
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
        var uiInstance = GetUiInstance<UI.debug.Debugger.DebuggerPanel>(UiName.Debug_Debugger);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 develop/EditorTools, 并返回UI实例
    /// </summary>
    public static UI.develop.EditorTools.EditorToolsPanel Open_Develop_EditorTools()
    {
        return OpenUi<UI.develop.EditorTools.EditorToolsPanel>(UiName.Develop_EditorTools);
    }

    /// <summary>
    /// 销毁 develop/EditorTools 的所有实例
    /// </summary>
    public static void Destroy_Develop_EditorTools()
    {
        var uiInstance = GetUiInstance<UI.develop.EditorTools.EditorToolsPanel>(UiName.Develop_EditorTools);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorColorPicker, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorColorPicker.EditorColorPickerPanel Open_Editor_EditorColorPicker()
    {
        return OpenUi<UI.editor.EditorColorPicker.EditorColorPickerPanel>(UiName.Editor_EditorColorPicker);
    }

    /// <summary>
    /// 销毁 editor/EditorColorPicker 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorColorPicker()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorColorPicker.EditorColorPickerPanel>(UiName.Editor_EditorColorPicker);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorDungeonGroup, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorDungeonGroup.EditorDungeonGroupPanel Open_Editor_EditorDungeonGroup()
    {
        return OpenUi<UI.editor.EditorDungeonGroup.EditorDungeonGroupPanel>(UiName.Editor_EditorDungeonGroup);
    }

    /// <summary>
    /// 销毁 editor/EditorDungeonGroup 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorDungeonGroup()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorDungeonGroup.EditorDungeonGroupPanel>(UiName.Editor_EditorDungeonGroup);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorForm, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorForm.EditorFormPanel Open_Editor_EditorForm()
    {
        return OpenUi<UI.editor.EditorForm.EditorFormPanel>(UiName.Editor_EditorForm);
    }

    /// <summary>
    /// 销毁 editor/EditorForm 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorForm()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorForm.EditorFormPanel>(UiName.Editor_EditorForm);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorImportCombination, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorImportCombination.EditorImportCombinationPanel Open_Editor_EditorImportCombination()
    {
        return OpenUi<UI.editor.EditorImportCombination.EditorImportCombinationPanel>(UiName.Editor_EditorImportCombination);
    }

    /// <summary>
    /// 销毁 editor/EditorImportCombination 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorImportCombination()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorImportCombination.EditorImportCombinationPanel>(UiName.Editor_EditorImportCombination);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorInfo, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorInfo.EditorInfoPanel Open_Editor_EditorInfo()
    {
        return OpenUi<UI.editor.EditorInfo.EditorInfoPanel>(UiName.Editor_EditorInfo);
    }

    /// <summary>
    /// 销毁 editor/EditorInfo 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorInfo()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorInfo.EditorInfoPanel>(UiName.Editor_EditorInfo);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorInput, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorInput.EditorInputPanel Open_Editor_EditorInput()
    {
        return OpenUi<UI.editor.EditorInput.EditorInputPanel>(UiName.Editor_EditorInput);
    }

    /// <summary>
    /// 销毁 editor/EditorInput 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorInput()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorInput.EditorInputPanel>(UiName.Editor_EditorInput);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorManager, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorManager.EditorManagerPanel Open_Editor_EditorManager()
    {
        return OpenUi<UI.editor.EditorManager.EditorManagerPanel>(UiName.Editor_EditorManager);
    }

    /// <summary>
    /// 销毁 editor/EditorManager 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorManager()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorManager.EditorManagerPanel>(UiName.Editor_EditorManager);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorTileImage, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorTileImage.EditorTileImagePanel Open_Editor_EditorTileImage()
    {
        return OpenUi<UI.editor.EditorTileImage.EditorTileImagePanel>(UiName.Editor_EditorTileImage);
    }

    /// <summary>
    /// 销毁 editor/EditorTileImage 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorTileImage()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorTileImage.EditorTileImagePanel>(UiName.Editor_EditorTileImage);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorTips, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorTips.EditorTipsPanel Open_Editor_EditorTips()
    {
        return OpenUi<UI.editor.EditorTips.EditorTipsPanel>(UiName.Editor_EditorTips);
    }

    /// <summary>
    /// 销毁 editor/EditorTips 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorTips()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorTips.EditorTipsPanel>(UiName.Editor_EditorTips);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/EditorWindow, 并返回UI实例
    /// </summary>
    public static UI.editor.EditorWindow.EditorWindowPanel Open_Editor_EditorWindow()
    {
        return OpenUi<UI.editor.EditorWindow.EditorWindowPanel>(UiName.Editor_EditorWindow);
    }

    /// <summary>
    /// 销毁 editor/EditorWindow 的所有实例
    /// </summary>
    public static void Destroy_Editor_EditorWindow()
    {
        var uiInstance = GetUiInstance<UI.editor.EditorWindow.EditorWindowPanel>(UiName.Editor_EditorWindow);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditor, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditor.MapEditorPanel Open_Editor_MapEditor()
    {
        return OpenUi<UI.editor.MapEditor.MapEditorPanel>(UiName.Editor_MapEditor);
    }

    /// <summary>
    /// 销毁 editor/MapEditor 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditor()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditor.MapEditorPanel>(UiName.Editor_MapEditor);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorConfigObject, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorConfigObject.MapEditorConfigObjectPanel Open_Editor_MapEditorConfigObject()
    {
        return OpenUi<UI.editor.MapEditorConfigObject.MapEditorConfigObjectPanel>(UiName.Editor_MapEditorConfigObject);
    }

    /// <summary>
    /// 销毁 editor/MapEditorConfigObject 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorConfigObject()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorConfigObject.MapEditorConfigObjectPanel>(UiName.Editor_MapEditorConfigObject);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorCreateMark, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorCreateMark.MapEditorCreateMarkPanel Open_Editor_MapEditorCreateMark()
    {
        return OpenUi<UI.editor.MapEditorCreateMark.MapEditorCreateMarkPanel>(UiName.Editor_MapEditorCreateMark);
    }

    /// <summary>
    /// 销毁 editor/MapEditorCreateMark 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorCreateMark()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorCreateMark.MapEditorCreateMarkPanel>(UiName.Editor_MapEditorCreateMark);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorCreatePreinstall, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorCreatePreinstall.MapEditorCreatePreinstallPanel Open_Editor_MapEditorCreatePreinstall()
    {
        return OpenUi<UI.editor.MapEditorCreatePreinstall.MapEditorCreatePreinstallPanel>(UiName.Editor_MapEditorCreatePreinstall);
    }

    /// <summary>
    /// 销毁 editor/MapEditorCreatePreinstall 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorCreatePreinstall()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorCreatePreinstall.MapEditorCreatePreinstallPanel>(UiName.Editor_MapEditorCreatePreinstall);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorCreateRoom, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorCreateRoom.MapEditorCreateRoomPanel Open_Editor_MapEditorCreateRoom()
    {
        return OpenUi<UI.editor.MapEditorCreateRoom.MapEditorCreateRoomPanel>(UiName.Editor_MapEditorCreateRoom);
    }

    /// <summary>
    /// 销毁 editor/MapEditorCreateRoom 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorCreateRoom()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorCreateRoom.MapEditorCreateRoomPanel>(UiName.Editor_MapEditorCreateRoom);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorMapLayer, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorMapLayer.MapEditorMapLayerPanel Open_Editor_MapEditorMapLayer()
    {
        return OpenUi<UI.editor.MapEditorMapLayer.MapEditorMapLayerPanel>(UiName.Editor_MapEditorMapLayer);
    }

    /// <summary>
    /// 销毁 editor/MapEditorMapLayer 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorMapLayer()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorMapLayer.MapEditorMapLayerPanel>(UiName.Editor_MapEditorMapLayer);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorMapMark, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorMapMark.MapEditorMapMarkPanel Open_Editor_MapEditorMapMark()
    {
        return OpenUi<UI.editor.MapEditorMapMark.MapEditorMapMarkPanel>(UiName.Editor_MapEditorMapMark);
    }

    /// <summary>
    /// 销毁 editor/MapEditorMapMark 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorMapMark()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorMapMark.MapEditorMapMarkPanel>(UiName.Editor_MapEditorMapMark);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorMapTile, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorMapTile.MapEditorMapTilePanel Open_Editor_MapEditorMapTile()
    {
        return OpenUi<UI.editor.MapEditorMapTile.MapEditorMapTilePanel>(UiName.Editor_MapEditorMapTile);
    }

    /// <summary>
    /// 销毁 editor/MapEditorMapTile 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorMapTile()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorMapTile.MapEditorMapTilePanel>(UiName.Editor_MapEditorMapTile);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorObject, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorObject.MapEditorObjectPanel Open_Editor_MapEditorObject()
    {
        return OpenUi<UI.editor.MapEditorObject.MapEditorObjectPanel>(UiName.Editor_MapEditorObject);
    }

    /// <summary>
    /// 销毁 editor/MapEditorObject 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorObject()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorObject.MapEditorObjectPanel>(UiName.Editor_MapEditorObject);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorProject, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorProject.MapEditorProjectPanel Open_Editor_MapEditorProject()
    {
        return OpenUi<UI.editor.MapEditorProject.MapEditorProjectPanel>(UiName.Editor_MapEditorProject);
    }

    /// <summary>
    /// 销毁 editor/MapEditorProject 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorProject()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorProject.MapEditorProjectPanel>(UiName.Editor_MapEditorProject);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorSelectObject, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorSelectObject.MapEditorSelectObjectPanel Open_Editor_MapEditorSelectObject()
    {
        return OpenUi<UI.editor.MapEditorSelectObject.MapEditorSelectObjectPanel>(UiName.Editor_MapEditorSelectObject);
    }

    /// <summary>
    /// 销毁 editor/MapEditorSelectObject 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorSelectObject()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorSelectObject.MapEditorSelectObjectPanel>(UiName.Editor_MapEditorSelectObject);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/MapEditorTools, 并返回UI实例
    /// </summary>
    public static UI.editor.MapEditorTools.MapEditorToolsPanel Open_Editor_MapEditorTools()
    {
        return OpenUi<UI.editor.MapEditorTools.MapEditorToolsPanel>(UiName.Editor_MapEditorTools);
    }

    /// <summary>
    /// 销毁 editor/MapEditorTools 的所有实例
    /// </summary>
    public static void Destroy_Editor_MapEditorTools()
    {
        var uiInstance = GetUiInstance<UI.editor.MapEditorTools.MapEditorToolsPanel>(UiName.Editor_MapEditorTools);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/TileSetEditor, 并返回UI实例
    /// </summary>
    public static UI.editor.TileSetEditor.TileSetEditorPanel Open_Editor_TileSetEditor()
    {
        return OpenUi<UI.editor.TileSetEditor.TileSetEditorPanel>(UiName.Editor_TileSetEditor);
    }

    /// <summary>
    /// 销毁 editor/TileSetEditor 的所有实例
    /// </summary>
    public static void Destroy_Editor_TileSetEditor()
    {
        var uiInstance = GetUiInstance<UI.editor.TileSetEditor.TileSetEditorPanel>(UiName.Editor_TileSetEditor);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/TileSetEditorCombination, 并返回UI实例
    /// </summary>
    public static UI.editor.TileSetEditorCombination.TileSetEditorCombinationPanel Open_Editor_TileSetEditorCombination()
    {
        return OpenUi<UI.editor.TileSetEditorCombination.TileSetEditorCombinationPanel>(UiName.Editor_TileSetEditorCombination);
    }

    /// <summary>
    /// 销毁 editor/TileSetEditorCombination 的所有实例
    /// </summary>
    public static void Destroy_Editor_TileSetEditorCombination()
    {
        var uiInstance = GetUiInstance<UI.editor.TileSetEditorCombination.TileSetEditorCombinationPanel>(UiName.Editor_TileSetEditorCombination);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/TileSetEditorImport, 并返回UI实例
    /// </summary>
    public static UI.editor.TileSetEditorImport.TileSetEditorImportPanel Open_Editor_TileSetEditorImport()
    {
        return OpenUi<UI.editor.TileSetEditorImport.TileSetEditorImportPanel>(UiName.Editor_TileSetEditorImport);
    }

    /// <summary>
    /// 销毁 editor/TileSetEditorImport 的所有实例
    /// </summary>
    public static void Destroy_Editor_TileSetEditorImport()
    {
        var uiInstance = GetUiInstance<UI.editor.TileSetEditorImport.TileSetEditorImportPanel>(UiName.Editor_TileSetEditorImport);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/TileSetEditorProject, 并返回UI实例
    /// </summary>
    public static UI.editor.TileSetEditorProject.TileSetEditorProjectPanel Open_Editor_TileSetEditorProject()
    {
        return OpenUi<UI.editor.TileSetEditorProject.TileSetEditorProjectPanel>(UiName.Editor_TileSetEditorProject);
    }

    /// <summary>
    /// 销毁 editor/TileSetEditorProject 的所有实例
    /// </summary>
    public static void Destroy_Editor_TileSetEditorProject()
    {
        var uiInstance = GetUiInstance<UI.editor.TileSetEditorProject.TileSetEditorProjectPanel>(UiName.Editor_TileSetEditorProject);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 editor/TileSetEditorTerrain, 并返回UI实例
    /// </summary>
    public static UI.editor.TileSetEditorTerrain.TileSetEditorTerrainPanel Open_Editor_TileSetEditorTerrain()
    {
        return OpenUi<UI.editor.TileSetEditorTerrain.TileSetEditorTerrainPanel>(UiName.Editor_TileSetEditorTerrain);
    }

    /// <summary>
    /// 销毁 editor/TileSetEditorTerrain 的所有实例
    /// </summary>
    public static void Destroy_Editor_TileSetEditorTerrain()
    {
        var uiInstance = GetUiInstance<UI.editor.TileSetEditorTerrain.TileSetEditorTerrainPanel>(UiName.Editor_TileSetEditorTerrain);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/BottomTips, 并返回UI实例
    /// </summary>
    public static UI.game.BottomTips.BottomTipsPanel Open_Game_BottomTips()
    {
        return OpenUi<UI.game.BottomTips.BottomTipsPanel>(UiName.Game_BottomTips);
    }

    /// <summary>
    /// 销毁 game/BottomTips 的所有实例
    /// </summary>
    public static void Destroy_Game_BottomTips()
    {
        var uiInstance = GetUiInstance<UI.game.BottomTips.BottomTipsPanel>(UiName.Game_BottomTips);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/Encyclopedia, 并返回UI实例
    /// </summary>
    public static UI.game.Encyclopedia.EncyclopediaPanel Open_Game_Encyclopedia()
    {
        return OpenUi<UI.game.Encyclopedia.EncyclopediaPanel>(UiName.Game_Encyclopedia);
    }

    /// <summary>
    /// 销毁 game/Encyclopedia 的所有实例
    /// </summary>
    public static void Destroy_Game_Encyclopedia()
    {
        var uiInstance = GetUiInstance<UI.game.Encyclopedia.EncyclopediaPanel>(UiName.Game_Encyclopedia);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/Loading, 并返回UI实例
    /// </summary>
    public static UI.game.Loading.LoadingPanel Open_Game_Loading()
    {
        return OpenUi<UI.game.Loading.LoadingPanel>(UiName.Game_Loading);
    }

    /// <summary>
    /// 销毁 game/Loading 的所有实例
    /// </summary>
    public static void Destroy_Game_Loading()
    {
        var uiInstance = GetUiInstance<UI.game.Loading.LoadingPanel>(UiName.Game_Loading);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/Main, 并返回UI实例
    /// </summary>
    public static UI.game.Main.MainPanel Open_Game_Main()
    {
        return OpenUi<UI.game.Main.MainPanel>(UiName.Game_Main);
    }

    /// <summary>
    /// 销毁 game/Main 的所有实例
    /// </summary>
    public static void Destroy_Game_Main()
    {
        var uiInstance = GetUiInstance<UI.game.Main.MainPanel>(UiName.Game_Main);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/PartPackUI, 并返回UI实例
    /// </summary>
    public static UI.game.PartPackUI.PartPackUIPanel Open_Game_PartPackUI()
    {
        return OpenUi<UI.game.PartPackUI.PartPackUIPanel>(UiName.Game_PartPackUI);
    }

    /// <summary>
    /// 销毁 game/PartPackUI 的所有实例
    /// </summary>
    public static void Destroy_Game_PartPackUI()
    {
        var uiInstance = GetUiInstance<UI.game.PartPackUI.PartPackUIPanel>(UiName.Game_PartPackUI);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/PartTips, 并返回UI实例
    /// </summary>
    public static UI.game.PartTips.PartTipsPanel Open_Game_PartTips()
    {
        return OpenUi<UI.game.PartTips.PartTipsPanel>(UiName.Game_PartTips);
    }

    /// <summary>
    /// 销毁 game/PartTips 的所有实例
    /// </summary>
    public static void Destroy_Game_PartTips()
    {
        var uiInstance = GetUiInstance<UI.game.PartTips.PartTipsPanel>(UiName.Game_PartTips);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/PauseMenu, 并返回UI实例
    /// </summary>
    public static UI.game.PauseMenu.PauseMenuPanel Open_Game_PauseMenu()
    {
        return OpenUi<UI.game.PauseMenu.PauseMenuPanel>(UiName.Game_PauseMenu);
    }

    /// <summary>
    /// 销毁 game/PauseMenu 的所有实例
    /// </summary>
    public static void Destroy_Game_PauseMenu()
    {
        var uiInstance = GetUiInstance<UI.game.PauseMenu.PauseMenuPanel>(UiName.Game_PauseMenu);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/RoomMap, 并返回UI实例
    /// </summary>
    public static UI.game.RoomMap.RoomMapPanel Open_Game_RoomMap()
    {
        return OpenUi<UI.game.RoomMap.RoomMapPanel>(UiName.Game_RoomMap);
    }

    /// <summary>
    /// 销毁 game/RoomMap 的所有实例
    /// </summary>
    public static void Destroy_Game_RoomMap()
    {
        var uiInstance = GetUiInstance<UI.game.RoomMap.RoomMapPanel>(UiName.Game_RoomMap);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/RoomUI, 并返回UI实例
    /// </summary>
    public static UI.game.RoomUI.RoomUIPanel Open_Game_RoomUI()
    {
        return OpenUi<UI.game.RoomUI.RoomUIPanel>(UiName.Game_RoomUI);
    }

    /// <summary>
    /// 销毁 game/RoomUI 的所有实例
    /// </summary>
    public static void Destroy_Game_RoomUI()
    {
        var uiInstance = GetUiInstance<UI.game.RoomUI.RoomUIPanel>(UiName.Game_RoomUI);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/Setting, 并返回UI实例
    /// </summary>
    public static UI.game.Setting.SettingPanel Open_Game_Setting()
    {
        return OpenUi<UI.game.Setting.SettingPanel>(UiName.Game_Setting);
    }

    /// <summary>
    /// 销毁 game/Setting 的所有实例
    /// </summary>
    public static void Destroy_Game_Setting()
    {
        var uiInstance = GetUiInstance<UI.game.Setting.SettingPanel>(UiName.Game_Setting);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/Settlement, 并返回UI实例
    /// </summary>
    public static UI.game.Settlement.SettlementPanel Open_Game_Settlement()
    {
        return OpenUi<UI.game.Settlement.SettlementPanel>(UiName.Game_Settlement);
    }

    /// <summary>
    /// 销毁 game/Settlement 的所有实例
    /// </summary>
    public static void Destroy_Game_Settlement()
    {
        var uiInstance = GetUiInstance<UI.game.Settlement.SettlementPanel>(UiName.Game_Settlement);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/Victory, 并返回UI实例
    /// </summary>
    public static UI.game.Victory.VictoryPanel Open_Game_Victory()
    {
        return OpenUi<UI.game.Victory.VictoryPanel>(UiName.Game_Victory);
    }

    /// <summary>
    /// 销毁 game/Victory 的所有实例
    /// </summary>
    public static void Destroy_Game_Victory()
    {
        var uiInstance = GetUiInstance<UI.game.Victory.VictoryPanel>(UiName.Game_Victory);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 打开 game/WeaponRoulette, 并返回UI实例
    /// </summary>
    public static UI.game.WeaponRoulette.WeaponRoulettePanel Open_Game_WeaponRoulette()
    {
        return OpenUi<UI.game.WeaponRoulette.WeaponRoulettePanel>(UiName.Game_WeaponRoulette);
    }

    /// <summary>
    /// 销毁 game/WeaponRoulette 的所有实例
    /// </summary>
    public static void Destroy_Game_WeaponRoulette()
    {
        var uiInstance = GetUiInstance<UI.game.WeaponRoulette.WeaponRoulettePanel>(UiName.Game_WeaponRoulette);
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

}
