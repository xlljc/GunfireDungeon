#if TOOLS

using System;
using System.IO;
using Godot;

namespace DsUi.Generator
{
    /// <summary>
    /// 生成 UiManager 中打开Ui相关的函数代码
    /// </summary>
    public static class UiManagerMethodsGenerator
    {
        /// <summary>
        /// 执行生成操作, 并返回执行结果
        /// </summary>
        public static bool Generate()
        {
            //扫描所有ui
            if (!Directory.Exists(DsUiConfig.UiPrefabDir))
            {
                return true;
            }

            try
            {

                var code = $"namespace DsUi;\n\n// 该类为自动生成的, 请不要手动编辑, 以免造成代码丢失\n" +
                           $"public static partial class UiManager\n" +
                           $"{{\n" +
                           $"\n";

                var uiNameClass = $"    public static class UiName\n" +
                                  $"    {{\n";
                var methodClass = "";

                GenEachPrefab(new DirectoryInfo(DsUiConfig.UiPrefabDir), ref uiNameClass, ref methodClass);

                uiNameClass += $"    }}\n\n";
                code += uiNameClass;
                code += methodClass;
                code += $"}}\n";

                File.WriteAllText(DsUiConfig.UiManagerMethodsCodePath, code);
            }
            catch (Exception e)
            {
                GD.PrintErr(e.ToString());
                return false;
            }

            return true;
        }

        private static void GenEachPrefab(DirectoryInfo directoryInfo, ref string uiNameClass,
            ref string methodClass)
        {
            var directoryInfos = directoryInfo.GetDirectories();
            foreach (var dir in directoryInfos)
            {
                GenEachPrefab(dir, ref uiNameClass, ref methodClass);
            }

            var fileInfos = directoryInfo.GetFiles();
            foreach (var fileInfo in fileInfos)
            {
                if (fileInfo.Extension == ".tscn") //文件
                {
                    var fullName = fileInfo.FullName.Replace("\\", "/");
                    var index = fullName.IndexOf(DsUiConfig.UiPrefabDir, StringComparison.Ordinal);
                    if (index == -1) continue;

                    var index2 = index + DsUiConfig.UiPrefabDir.Length;
                    // path/Name
                    var pathName = fullName.Substring(index2, fullName.Length - index2 - 5);
                    // [path,Name]
                    var names = pathName.Split('/');
                    // Name
                    var uiName = names[names.Length - 1];
                    
                    // cs脚本路径
                    var csCodePath = "";
                    for (var i = 0; i < names.Length; i++)
                    {
                        if (i < names.Length - 1)
                        {
                            csCodePath += names[i] + "/";
                        }
                        else
                        {
                            csCodePath += UiGeneratorUtils.FirstToLower(names[i]) + "/";
                        }
                    }

                    csCodePath += uiName + ".cs";
                    // 判断文件是否是ui
                    if (!File.Exists(DsUiConfig.UiCodeDir + csCodePath))
                    {
                        GD.Print($"----------- 检测到非ui文件: {fullName}，找不到对应Ui代码：{DsUiConfig.UiCodeDir + csCodePath}");
                        continue;
                    }
                    GD.Print($"检测到ui文件: {fullName}");
                    
                    // Path_Name
                    var pathName2 = UiGeneratorUtils.FirstToUpper(pathName.Replace('/', '_'));
                    // UI.path.Name
                    var csNamespace = DsUiConfig.UiNamespace + "." + names.Join(".");
                    // UI.path.Name.NamePanel
                    var csFullName = csNamespace + "." + uiName + "Panel";
                    
                    uiNameClass += $"        public const string {pathName2} = \"{pathName}\";\n";
                    methodClass += $"    /// <summary>\n" +
                                   $"    /// 打开 {pathName}, 并返回UI实例\n" +
                                   $"    /// </summary>\n" +
                                   $"    public static {csFullName} Open_{pathName2}()\n" +
                                   $"    {{\n" +
                                   $"        return OpenUi<{csFullName}>(UiName.{pathName2});\n" +
                                   $"    }}\n" +
                                   $"\n" +
                                   $"    /// <summary>\n" +
                                   $"    /// 销毁 {pathName} 的所有实例\n" +
                                   $"    /// </summary>\n" +
                                   $"    public static void Destroy_{pathName2}()\n" +
                                   $"    {{\n" +
                                   $"        var uiInstance = GetUiInstance<{csFullName}>(UiName.{pathName2});\n" + 
                                   $"        foreach (var uiPanel in uiInstance)\n" +
                                   $"        {{\n" +
                                   $"            uiPanel.Destroy();\n" +
                                   $"        }}\n" +
                                   $"    }}\n" +
                                   $"\n";
                }
            }
        }


    }

}

#endif