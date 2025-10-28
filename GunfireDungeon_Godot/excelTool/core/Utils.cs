
using System.Reflection;
using System.Text.Json;
using Aspose.Cells;

public static class Utils
{
    
    private static Dictionary<string, Type?> _customTypes = new Dictionary<string, Type?>();
    
    public static void InitCustomTypes()
    {
        var types = typeof(Utils).Assembly.GetTypes();
        foreach (var type in types)
        {
            var attribute = type.GetCustomAttribute<CustomNameAttribute>();
            if (attribute != null)
            {
                _customTypes.Add(attribute.Name, type);
            }
            else
            {
                _customTypes.Add(type.FullName, type);
            }
        }
    }
    
    public static string GetCellStringValue(Cell cell)
    {
        if (cell == null)
        {
            return "";
        }
        switch (cell.Type)
        {
            case CellValueType.IsNumeric:
                return cell.DoubleValue.ToString();
            case CellValueType.IsString:
                return cell.StringValue;
            case CellValueType.IsBool:
                return cell.BoolValue ? "true" : "false";
        }

        return "";
    }
    
    
    public static string TypeStrMapping(string typeName)
    {
        switch (typeName)
        {
            case "object": return  typeof(JsonElement).FullName;
            case "boolean": return "bool";
            default:
            {
                var type = GetCustomType(typeName);
                if (type != null)
                {
                    return type.FullName;
                }
            }
                break;
        }

        return typeName;
    }

    public static string TypeNameMapping(string typeName)
    {
        switch (typeName)
        {
            case "object":return typeof(JsonElement).AssemblyQualifiedName;
            case "bool":
            case "boolean": return typeof(bool).AssemblyQualifiedName;
            case "byte": return typeof(byte).AssemblyQualifiedName;
            case "sbyte": return typeof(sbyte).AssemblyQualifiedName;
            case "short": return typeof(short).AssemblyQualifiedName;
            case "ushort": return typeof(ushort).AssemblyQualifiedName;
            case "int": return typeof(int).AssemblyQualifiedName;
            case "uint": return typeof(uint).AssemblyQualifiedName;
            case "long": return typeof(long).AssemblyQualifiedName;
            case "ulong": return typeof(ulong).AssemblyQualifiedName;
            case "string": return typeof(string).AssemblyQualifiedName;
            case "float": return typeof(float).AssemblyQualifiedName;
            case "double": return typeof(double).AssemblyQualifiedName;
            default:
            {
                var type = GetCustomType(typeName);
                if (type != null)
                {
                    return type.AssemblyQualifiedName;
                }
            }
                break;
        }

        return typeName;
    }

    public static bool IsBaseType(string typeName)
    {
        switch (typeName)
        {
            case "bool":
            case "boolean":
            case "byte":
            case "sbyte":
            case "short":
            case "ushort":
            case "int":
            case "uint":
            case "long":
            case "ulong":
            case "string":
            case "float":
            case "double":
                return true;
        }

        return false;
    }
    
    public static Type GetCustomType(string typeName)
    {
        return _customTypes.GetValueOrDefault(typeName);
    }
    
    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    /// <summary>
    /// 字符串首字母小写
    /// </summary>
    public static string FirstToLower(this string str)
    {
        return str.Substring(0, 1).ToLower() + str.Substring(1);
    }
    
    /// <summary>
    /// 字符串首字母大写
    /// </summary>
    public static string FirstToUpper(this string str)
    {
        return str.Substring(0, 1).ToUpper() + str.Substring(1);
    }
}