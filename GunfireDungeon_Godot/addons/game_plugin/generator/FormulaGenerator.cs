#if TOOLS

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Config;

namespace Generator;

public static class FormulaGenerator
{
    // 生成公式配置代码
    public static void GeneratorFormulaConfigCode()
    {
        var text = File.ReadAllText($"resource/config/{nameof(ExcelConfig.FormulaConfig)}.json");
        var array = JsonSerializer.Deserialize<System.Collections.Generic.Dictionary<string, JsonElement>[]>(text);
        
        var code1 = "";

        foreach (var item in array)
        {
            string funcName = item["FuncName"].GetString();
            if (string.IsNullOrWhiteSpace(funcName)) throw new Exception("FuncName不能为空");
            if (!IsValidIdentifier(funcName)) throw new Exception($"FuncName '{funcName}' 不是有效的标识符");

            string paramDefStr = item["ParamDef"].GetString() ?? "";
            var parameters = ParseParameters(paramDefStr);

            string returnType = item["ReturnDef"].GetString() ?? "";
            if (string.IsNullOrWhiteSpace(returnType)) returnType = "float";
            if (!IsValidType(returnType)) throw new Exception($"ReturnDef '{returnType}' 不是有效的类型");

            string exprDef = item["ExprDef"].GetString();
            if (string.IsNullOrWhiteSpace(exprDef)) throw new Exception($"ExprDef不能为空 for {funcName}");

            string describe = item["Describe"].GetString() ?? "";

            // 生成body
            string body;
            if (exprDef.Contains('\n'))
            {
                body = exprDef.Replace("\n", "\n        ");
            }
            else
            {
                body = "return " + exprDef;
                if (!body.EndsWith(";")) body += ";";
            }

            // 生成参数字符串
            string paramStr = string.Join(", ", parameters.Select(p => $"{p.type} {p.name}"));

            // 生成函数代码
            code1 += $"    /// <summary>\n";
            code1 += $"    /// {describe}\n";
            code1 += $"    /// </summary>\n";
            code1 += $"    public static {returnType} {funcName}({paramStr})\n";
            code1 += $"    {{\n";
            code1 += $"        {body}\n";
            code1 += $"    }}\n\n";
        }
        
        var str = $"using System;\n";
        str += $"using Godot;\n";
        str += $"using Config;\n\n";
        str += $"// 根据配置表公式, 该类是自动生成的, 请不要手动编辑!\n";
        str += $"public partial class CommonFormula\n";
        str += $"{{\n";
        
        str += code1;
        
        str += $"}}\n";
        
        File.WriteAllText("src/game/common/CommonFormula.cs", str);
    }

    private static bool IsValidIdentifier(string id)
    {
        if (string.IsNullOrEmpty(id)) return false;
        if (!char.IsLetter(id[0]) && id[0] != '_') return false;
        for (int i = 1; i < id.Length; i++)
        {
            if (!char.IsLetterOrDigit(id[i]) && id[i] != '_') return false;
        }
        return true;
    }

    private static bool IsValidType(string type)
    {
        var validTypes = new[] { "int", "float", "double", "bool", "string", "long", "short", "byte", "char" };
        return validTypes.Contains(type);
    }

    private static List<(string name, string type)> ParseParameters(string paramDef)
    {
        var list = new List<(string, string)>();
        if (string.IsNullOrWhiteSpace(paramDef)) return list;
        var parts = paramDef.Split(',').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p));
        foreach (var part in parts)
        {
            var sub = part.Split(':').Select(s => s.Trim()).ToArray();
            string name, type;
            if (sub.Length == 1)
            {
                name = sub[0];
                type = "float";
            }
            else if (sub.Length == 2)
            {
                name = sub[0];
                type = sub[1];
            }
            else
            {
                throw new Exception($"参数定义格式错误: {part}");
            }
            if (!IsValidIdentifier(name)) throw new Exception($"参数名 '{name}' 不是有效的标识符");
            if (!IsValidType(type)) throw new Exception($"参数类型 '{type}' 不是有效的类型");
            list.Add((name, type));
        }
        return list;
    }
}

#endif
