#if TOOLS

using System;
using System.IO;
using Godot;
using Array = Godot.Collections.Array;

namespace Generator;

public static class ExcelGenerator
{
    /// <summary>
    /// 执行导出Excel表
    /// </summary>
    public static bool ExportExcel()
    {
        var arr = new Array();
        var toolDir = "excelTool";
        var excelPath = "excel/";
        var jsonPath = "resource/config/";
        var codePath = "src/config/";
        
        //平台名称
        var osName = OS.GetName();
        //平台标识符
        string rid;
        string toolName;
        if (osName == "Windows")
        {
            rid = "win-x64";
            toolName = "ExcelTool.exe";
        }
        else if (osName == "macOS")
        {
            rid = "osx-x64";
            toolName = "ExcelTool";
        }
        else
        {
            GD.PrintErr($"当前平台{osName}不支持导出Excel表");
            return false;
        }

        var toolPath = $"{toolDir}/publish/{rid}";
        
        if (!Directory.Exists(toolPath)) //判断是否编译过工具
        {
            GD.Print("开始编译导出工具");
            var r = CompilerTool(toolDir, rid, toolPath);
            GD.Print("编译Excel工具返回值: " + r);
            if (r != 0)
            {
                if (osName == "macOS")
                {
                    GD.Print("在Mac上自动编译Excel表失败, 不过您可以使用以上命令手动编译, 在项目根目录打开一个终端, 并执行以上命令");
                }
                return false;
            }
        }
        else if (File.ReadAllText($"{toolDir}/version") != File.ReadAllText($"{toolPath}/version")) //版本有变化
        {
            GD.Print("工具版本有变化，执行重新编译导出工具");
            //删除编译目录
            Directory.Delete(toolPath, true);
            var r = CompilerTool(toolDir, rid, toolPath);
            GD.Print("编译Excel工具返回值: " + r);
            if (r != 0)
            {
                if (osName == "macOS")
                {
                    GD.Print("在Mac上自动编译Excel表失败, 不过您可以使用以上命令手动编译, 在项目根目录打开一个终端, 并执行以上命令");
                }
                return false;
            }
        }
        
        var result = OS.Execute($"{toolPath}/{toolName}", new[] { excelPath, jsonPath, codePath }, arr);
        foreach (var message in arr)
        {
            GD.Print(message);
        }
        
        if (result != 0)
        {
            return false;
        }
        
        try
        {
            // 生成公式配置代码
            FormulaGenerator.GeneratorFormulaConfigCode();
            // 生成 ActivityObject 初始化代码
            ActivityObjectGenerator.GeneratorActivityObjectInit();
            GD.Print("生成'src/framework/activity/ActivityObject_Init.cs'成功!");
        }
        catch (Exception e)
        {
            GD.PrintErr(e.ToString());
            return false;
        }

        return true;
    }

    //编译工具
    private static int CompilerTool(string csProjectPath, string rid, string outputPath)
    {
        //dotnet publish excelTool -c Release -r win-x64 -o ./excelTool/publish/win-x64
        //dotnet publish excelTool -c Release -r osx-x64 -o excelTool/publish/osx-x64
        //dotnet publish excelTool -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true -o excelTool/publish/osx-x64
        GD.Print("编译命令: " + $"dotnet publish {csProjectPath} -c Release -r {rid} --self-contained true -p:PublishSingleFile=true -o {outputPath}");
        var outLog = new Array();
        var result = OS.Execute("dotnet", new string[]
        {
            "publish", csProjectPath,
            "-c", "Release", "-r", rid,
            "--self-contained", "true",
            "-p:PublishSingleFile=true",
            "-o", outputPath
        }, outLog);
        //var result = OS.Execute("dotnet", new string[] { "publish", csProjectPath, "-c", "Release", "-r", rid, "-o", outputPath }, outLog);
        foreach (var variant in outLog)
        {
            GD.Print(variant);
        }

        return result;
    }
}

#endif
