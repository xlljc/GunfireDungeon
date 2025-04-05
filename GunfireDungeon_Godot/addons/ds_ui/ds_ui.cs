#if TOOLS
using Godot;
using System;
using System.IO;
using System.Text.RegularExpressions;
using DsUi.Generator;

namespace DsUi
{
    [Tool]
    public partial class ds_ui : EditorPlugin, ISerializationListener
    {
        /// <summary>
        /// 当前插件实例
        /// </summary>
        public static EditorInterface EditorInterface { get; private set; }

        //ui监听器
        private NodeMonitor _uiMonitor;

        private delegate void CreateUiCallback(string uiName);

        public override void _Process(double delta)
        {
#if GODOT4_2_OR_GREATER
            EditorInterface = EditorInterface.Singleton;
#else
            EditorInterface = GetEditorInterface();
#endif

            if (_uiMonitor != null)
            {
                _uiMonitor.Process((float)delta);
            }
            else
            {
                _uiMonitor = new NodeMonitor();
                _uiMonitor.SceneNodeChangeEvent += GenerateUiCode;
                OnSceneChanged(EditorInterface.GetEditedSceneRoot());
            }
        }

        public override void _EnterTree()
        {
#if GODOT4_2_OR_GREATER
            EditorInterface = EditorInterface.Singleton;
#else
            EditorInterface = GetEditorInterface();
#endif
            //场景切换事件
            SceneChanged += OnSceneChanged;

            _uiMonitor = new NodeMonitor();
            _uiMonitor.SceneNodeChangeEvent += GenerateUiCode;
            OnSceneChanged(EditorInterface.GetEditedSceneRoot());

            AddToolMenuItem("DsUi：创建Ui", new Callable(this, nameof(OnCreateUi)));
            AddToolMenuItem("DsUi：重新生成当前Ui代码", new Callable(this, nameof(OnGenerateUiCode)));
            AddToolMenuItem("DsUi：重新生成所有Ui代码", new Callable(this, nameof(OnGenerateAllUiCode)));
            AddToolMenuItem("DsUi：重新生成UiManager中的Ui函数", new Callable(this, nameof(GenerateUiManagerMethods)));
            AddAutoloadSingleton("InitUiManager", "res://addons/ds_ui/InitUiManager.cs");
        }

        public override void _ExitTree()
        {
            SceneChanged -= OnSceneChanged;

            if (_uiMonitor != null)
            {
                _uiMonitor.SceneNodeChangeEvent -= GenerateUiCode;
                _uiMonitor = null;
            }

            RemoveToolMenuItem("DsUi：创建Ui");
            RemoveToolMenuItem("DsUi：重新生成当前Ui代码");
            RemoveToolMenuItem("DsUi：重新生成所有Ui代码");
            RemoveToolMenuItem("DsUi：重新生成UiManager中的Ui函数");
            RemoveAutoloadSingleton("InitUiManager");
        }


        /// <summary>
        /// 检查节点是否为UI节点
        /// </summary>
        public bool CheckIsUi(Node node)
        {
            var resourcePath = node.GetScript().As<CSharpScript>()?.ResourcePath;
            if (resourcePath == null)
            {
                return false;
            }

            var temp = "res://" + DsUiConfig.UiCodeDir;
            if (resourcePath.StartsWith(temp) && resourcePath.EndsWith("Panel.cs"))
            {
                var index = resourcePath.LastIndexOf("/", StringComparison.Ordinal);
                var uiName = resourcePath.Substring(index + 1, resourcePath.Length - index - 8 - 1);
                
                
                // 规则： uiName/UiNamePanel.cs，存在两个"uiName"，并且多出"/"和"Panel.cs"，所以最后要 * 2 并且 - 9
                var subPath = resourcePath.Substring(temp.Length, resourcePath.Length - temp.Length - uiName.Length * 2 - 9);
                //var nameSpace = subPath.Length > 0 ? subPath.Substring(0, subPath.Length - 1).Replace("/", ".") : "";
                //var codePath = "res://" + DsUiConfig.UiCodeDir + FirstToLower(uiName) + "/" + uiName + "Panel.cs";
                var codePath = "res://" + DsUiConfig.UiCodeDir + subPath + FirstToLower(uiName) + "/" + uiName + "Panel.cs";

                if (ResourceLoader.Exists(codePath))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 执行生成ui代码操作
        /// </summary>
        public void GenerateUiCode(Node node)
        {
            UiGenerator.GenerateUiCodeFromEditor(node);
        }

        /// <summary>
        /// 切换场景
        /// </summary>
        private void OnSceneChanged(Node node)
        {
            if (_uiMonitor != null)
            {
                _uiMonitor.ChangeCurrentNode(null);
                if (node != null)
                {
                    if (CheckIsUi(node))
                    {
                        _uiMonitor.ChangeCurrentNode(node);
                    }
                }
            }
        }

        /// <summary>
        /// 字符串首字母小写
        /// </summary>
        public static string FirstToLower(string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }
        
        /// <summary>
        /// 字符串首字母大写
        /// </summary>
        public static string FirstToUpper(string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }

        private void OnCreateUi()
        {
            ShowInput("创建Ui", (result) =>
            {
                if (result != null)
                {
                    //检查名称是否合规
                    if (!Regex.IsMatch(result, "^([a-zA-z][\\w]*/)*[A-Z][\\w]*$")) // ^[A-Z][a-zA-Z0-9]*$
                    {
                        ShowTips("错误", "UI名称'" + result + "'不符合名称约束, UI名称只允许大写字母开头, 且名称中只允许出现大小字母和数字!");
                        return;
                    }

                    //检查是否有同名的Ui
                    var path = DsUiConfig.UiPrefabDir + result + ".tscn";
                    if (File.Exists(path))
                    {
                        ShowTips("错误", "已经存在相同名称'" + result + "'的UI了, 不能重复创建!");
                        return;
                    }

                    //执行创建操作
                    if (UiGenerator.CreateUi(result, true))
                    {
                        ShowTips("提示", "创建UI成功!");
                    }
                    else
                    {
                        ShowTips("错误", "创建UI失败! 前往控制台查看错误日志!");
                    }

                }
            });
        }

        private void OnGenerateUiCode()
        {
            if (EditorInterface != null)
            {
                var root = EditorInterface.GetEditedSceneRoot();
                if (root != null && CheckIsUi(root))
                {
                    if (UiGenerator.GenerateUiCodeFromEditor(root))
                    {
                        ShowTips("提示", "生成UI代码执行成功!");
                    }
                    else
                    {
                        ShowTips("错误", "生成UI代码执行失败! 前往控制台查看错误日志!");
                    }
                }
                else
                {
                    ShowTips("错误", "当前的场景不是受管束的UI场景!");
                }
            }
        }

        private void OnGenerateAllUiCode()
        {
            if (EditorInterface != null)
            {
                if (UiGenerator.GenerateAllUiCode())
                {
                    ShowTips("提示", "生成所有UI代码执行成功!");
                }
                else
                {
                    ShowTips("错误", "生成所有UI代码执行失败! 前往控制台查看错误日志!");
                }
            }
        }
        
        private void GenerateUiManagerMethods()
        {
            if (UiManagerMethodsGenerator.Generate())
            {
                ShowTips("提示", "生成UiManager_Methods.cs代码执行完成!");
            }
            else
            {
                ShowTips("错误", "生成UiManager_Methods.cs代码执行失败! 前往控制台查看错误日志!");
            }
        }

        private void ShowTips(string title, string message)
        {
            var tips = (AcceptDialog)ResourceLoader.Load<PackedScene>("res://addons/ds_ui/ui/Tips.tscn").Instantiate();
            EditorInterface.GetEditorMainScreen().AddChild(tips);
            tips.Confirmed += () => { tips.QueueFree(); };
            tips.Canceled += () => { tips.QueueFree(); };
            tips.Title = title;
            tips.DialogText = message;
            tips.Popup();
        }

        private void ShowInput(string title, CreateUiCallback callback)
        {
            var confirm = (ConfirmationDialog)ResourceLoader.Load<PackedScene>("res://addons/ds_ui/ui/Confirm.tscn")
                .Instantiate();
            EditorInterface.GetEditorMainScreen().AddChild(confirm);
            confirm.Confirmed += () =>
            {
                confirm.QueueFree();
                var result = confirm.GetNode<LineEdit>("Control/VBoxContainer/LineEdit").Text;
                if (string.IsNullOrEmpty(result))
                {
                    result = "";
                }

                callback(result);
            };
            confirm.Canceled += () =>
            {
                confirm.QueueFree();
                callback(null);
            };
            confirm.Title = title;
            confirm.Popup();
        }

        public void OnBeforeSerialize()
        {
            SceneChanged -= OnSceneChanged;
        }
        
        public void OnAfterDeserialize()
        {
            SceneChanged += OnSceneChanged;
        }
    }
}
#endif
