using System;
using System.Collections.Generic;
using Godot;
using Environment = System.Environment;

#if TOOLS
using Generator;
#endif

using DsUi;

namespace UI.EditorTools;

/// <summary>
/// Godot编辑器扩展工具
/// </summary>
[Tool]
public partial class EditorToolsPanel : EditorTools, ISerializationListener
{
    
#if TOOLS
    //Tips 关闭回调
    private Action _onTipsClose;

    //询问窗口关闭
    private Action<bool> _onConfirmClose;

    //存放创建房间中选择组的下拉框数据
    private Dictionary<int, string> _createRoomGroupValueMap;
    
    //存放创建房间中选择类型的下拉框数据
    private Dictionary<int, string> _createRoomTypeValueMap;

    public override void OnShowUi()
    {
        //tips
        _onTipsClose = null;
        L_Tips.Instance.OkButtonText = "确定";
        L_Tips.Instance.CloseRequested += OnTipsClose;
        L_Tips.Instance.Confirmed += OnTipsClose;
        L_Tips.Instance.Canceled += OnTipsClose;

        //confirm
        _onConfirmClose = null;
        L_Confirm.Instance.OkButtonText = "确定";
        L_Confirm.Instance.CancelButtonText = "取消";
        L_Confirm.Instance.Canceled += OnCanceled;
        L_Confirm.Instance.CloseRequested += OnCanceled;
        L_Confirm.Instance.Confirmed += OnConfirm;

        var container = L_ScrollContainer.L_MarginContainer.L_VBoxContainer;
        //重新生成 ResourcePath
        container.L_HBoxContainer.L_Button.Instance.Pressed += GenerateResourcePath;
        //生成buff属性表
        container.L_HBoxContainer6.L_Button.Instance.Pressed += GenerateBuffAttrTable;
        //导出excel表
        container.L_HBoxContainer7.L_Button.Instance.Pressed += ExportExcel;
        //打开excel表文件夹
        container.L_HBoxContainer8.L_Button.Instance.Pressed += OpenExportExcelFolder;
    }

    public override void OnHideUi()
    {
        L_Tips.Instance.CloseRequested -= OnTipsClose;
        L_Tips.Instance.Confirmed -= OnTipsClose;
        L_Tips.Instance.Canceled -= OnTipsClose;
        
        L_Confirm.Instance.Canceled -= OnCanceled;
        L_Confirm.Instance.CloseRequested -= OnCanceled;
        L_Confirm.Instance.Confirmed -= OnConfirm;
        
        var container = L_ScrollContainer.L_MarginContainer.L_VBoxContainer;
        container.L_HBoxContainer.L_Button.Instance.Pressed -= GenerateResourcePath;
        container.L_HBoxContainer6.L_Button.Instance.Pressed -= GenerateBuffAttrTable;
        container.L_HBoxContainer7.L_Button.Instance.Pressed -= ExportExcel;
        container.L_HBoxContainer8.L_Button.Instance.Pressed -= OpenExportExcelFolder;
    }
    
    public void OnBeforeSerialize()
    {
        OnHideUi();
    }
    public void OnAfterDeserialize()
    {
        OnShowUi();
    }

    /// <summary>
    /// Tips 关闭信号回调
    /// </summary>
    private void OnTipsClose()
    {
        if (_onTipsClose != null)
        {
            _onTipsClose();
            _onTipsClose = null;
        }
    }

    /// <summary>
    /// Confirm 确认信号回调
    /// </summary>
    private void OnConfirm()
    {
        if (_onConfirmClose != null)
        {
            _onConfirmClose(true);
            _onConfirmClose = null;
        }
    }

    /// <summary>
    /// Confirm 取消信号回调
    /// </summary>
    private void OnCanceled()
    {
        if (_onConfirmClose != null)
        {
            _onConfirmClose(false);
            _onConfirmClose = null;
        }
    }
    
    /// <summary>
    /// 打开提示窗口, 并设置宽高
    /// </summary>
    /// <param name="title">窗口标题</param>
    /// <param name="message">显示内容</param>
    /// <param name="width">窗口宽度</param>
    /// <param name="height">窗口高度</param>
    /// <param name="onClose">当窗口关闭时的回调</param>
    public void ShowTips(string title, string message, int width, int height, Action onClose = null)
    {
        var tips = L_Tips.Instance;
        tips.Size = new Vector2I(width, height);
        tips.Title = title;
        tips.DialogText = message;
        _onTipsClose = onClose;
        tips.Show();
    }
    
    /// <summary>
    /// 打开提示窗口
    /// </summary>
    /// <param name="title">窗口标题</param>
    /// <param name="message">显示内容</param>
    /// <param name="onClose">当窗口关闭时的回调</param>
    public void ShowTips(string title, string message, Action onClose = null)
    {
        ShowTips(title, message, 350, 200, onClose);
    }

    /// <summary>
    /// 关闭提示窗口
    /// </summary>
    public void CloseTips()
    {
        L_Tips.Instance.Hide();
        _onTipsClose = null;
    }

    /// <summary>
    /// 打开询问窗口, 并设置宽高
    /// </summary>
    /// <param name="title">窗口标题</param>
    /// <param name="message">显示内容</param>
    /// <param name="width">窗口宽度</param>
    /// <param name="height">窗口高度</param>
    /// <param name="onClose">当窗口关闭时的回调, 参数如果为 true 表示点击了确定按钮</param>
    public void ShowConfirm(string title, string message, int width, int height, Action<bool> onClose = null)
    {
        var confirm = L_Confirm.Instance;
        confirm.Size = new Vector2I(width, height);
        confirm.Title = title;
        confirm.DialogText = message;
        _onConfirmClose = onClose;
        confirm.Show();
    }
    
    /// <summary>
    /// 打开询问窗口
    /// </summary>
    /// <param name="title">窗口标题</param>
    /// <param name="message">显示内容</param>
    /// <param name="onClose">当窗口关闭时的回调, 参数如果为 true 表示点击了确定按钮</param>
    public void ShowConfirm(string title, string message, Action<bool> onClose = null)
    {
        ShowConfirm(title, message, 350, 200, onClose);
    }

    /// <summary>
    /// 关闭询问窗口
    /// </summary>
    public void CloseConfirm()
    {
        L_Confirm.Instance.Hide();
        _onConfirmClose = null;
    }

    /// <summary>
    /// 更新 ResourcePath
    /// </summary>
    private void GenerateResourcePath()
    {
        if (ResourcePathGenerator.Generate())
        {
            ShowTips("提示", "ResourcePath.cs生成完成!");
        }
        else
        {
            ShowTips("错误", "ResourcePath.cs生成失败! 前往控制台查看错误日志!");
        }
    }

    /// <summary>
    /// 生成Buff属性表
    /// </summary>
    private void GenerateBuffAttrTable()
    {
        if (BuffGenerator.Generate())
        {
            ShowTips("提示", "Buff属性表生成完成!");
        }
        else
        {
            ShowTips("错误", "uff属性表生成失败! 前往控制台查看错误日志!");
        }
    }
    
    /// <summary>
    /// 导出excel表
    /// </summary>
    private void ExportExcel()
    {
        if (ExcelGenerator.ExportExcel())
        {
            ShowTips("提示", "导出Excel表成功！");
            ActivityInstance.ClearCacheJson();
        }
        else
        {
            ShowTips("错误", "导出Excel表失败，请查看控制台日志！");
        }
    }

    /// <summary>
    /// 使用资源管理器打开excel表文件夹
    /// </summary>
    private void OpenExportExcelFolder()
    {
        var osName = OS.GetName();
        if (osName == "Windows")
        {
            var path = Environment.CurrentDirectory + "\\excel";
            GD.Print("打开excel文件夹: " + path);
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
        else
        {
            var path = Environment.CurrentDirectory + "/excel";
            GD.Print("打开excel文件夹: " + path);
            System.Diagnostics.Process.Start("open", path);
        }
    }

    /// <summary>
    /// 在编辑器中打开一个提示窗口
    /// </summary>
    public static void ShowTipsInEditor(string title, string message, Action onClose)
    {
        var editorToolsInstance = UiManager.Get_EditorTools_Instance();
        if (editorToolsInstance.Length > 0)
        {
            editorToolsInstance[0].ShowTips(title, message, onClose);
        }
    }
    
    /// <summary>
    /// 在编辑器中打开一个询问窗口
    /// </summary>
    public static void ShowConfirmInEditor(string title, string message, Action<bool> onClose = null)
    {
        var editorToolsInstance = UiManager.Get_EditorTools_Instance();
        if (editorToolsInstance.Length > 0)
        {
            editorToolsInstance[0].ShowConfirm(title, message, onClose);
        }
    }
#else
    public override void OnShowUi()
    {
    }
    
    public override void OnHideUi()
    {
    }
    public void OnBeforeSerialize()
    {
    }
    public void OnAfterDeserialize()
    {
    }
#endif
}
