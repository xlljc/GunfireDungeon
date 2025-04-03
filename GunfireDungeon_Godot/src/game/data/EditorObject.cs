using Godot;

namespace Config;

public partial class ExcelConfig
{
    public partial class EditorObject
    {
        private bool _initFlag;
        private bool _isActivity;
        
        /// <summary>
        /// 判断是否是 ActivityObject 物体
        /// </summary>
        public bool IsActivity()
        {
            if (!_initFlag)
            {
                _initFlag = true;
                _isActivity = !Prefab.StartsWith("res://");
            }
            
            return  _isActivity;
        }

        /// <summary>
        /// 获取物体真实名称
        /// </summary>
        public string GetRealName()
        {
            if (IsActivity())
            {
                var activityBase = ActivityBase_Map[Prefab];
                return activityBase.Name;
            }

            return Name;
        }
        
        /// <summary>
        /// 加载地牢编辑器中自定义对象的图标
        /// </summary>
        public Texture2D GetIcon()
        {
            if (IsActivity())
            {
                var activityBase = ActivityBase_Map[Prefab];
                return ResourceManager.LoadTexture2D(activityBase.Icon);
            }

            if (string.IsNullOrEmpty(Icon))
            {
                return null;
            }
            return ResourceManager.LoadTexture2D(Icon);
        }
    }
}