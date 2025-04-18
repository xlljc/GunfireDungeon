using System;
using Godot;

namespace DsUi.Generator;

public static class UiGeneratorUtils
{
    
    /// <summary>
    /// 检查节点是否为UI节点
    /// </summary>
    public static bool CheckIsUi(Node node)
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

}