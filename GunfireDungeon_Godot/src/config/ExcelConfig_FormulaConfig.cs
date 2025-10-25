using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Config;

public static partial class ExcelConfig
{
    /// <summary>
    /// 计算公式表
    /// </summary>
    public partial class FormulaConfig
    {
        /// <summary>
        /// 计算公式名称，即C#函数名称
        /// </summary>
        [JsonInclude]
        public string FuncName;

        /// <summary>
        /// 参数定义，即函数参数声明，多个参数使用逗号分隔，使用“参数名：参数类型”声明参数数据类型，如果不使用冒号声明参数类型，则默认使用float类型
        /// </summary>
        [JsonInclude]
        public string ParamDef;

        /// <summary>
        /// 返回值类型，函数返回值类型，如果不填，则使用float类型
        /// </summary>
        [JsonInclude]
        public string ReturnDef;

        /// <summary>
        /// 公式主体，这里面的代码会被直接当成C#代码使用，如果语法有误，则无法通过C#编译，请注意参数数据类型转换，如果只有一行，则可以忽略return和最后的分号，如果是多行，则最后需要使用return返回最终的结果，并且需要分号代表行结尾 <br/>
        /// ps：因为是C#，所以可以声明变量和使用if语句，甚至可以调用函数！
        /// </summary>
        [JsonInclude]
        public string ExprDef;

        /// <summary>
        /// 公式描述
        /// </summary>
        [JsonInclude]
        public string Describe;

        /// <summary>
        /// 返回浅拷贝出的新对象
        /// </summary>
        public FormulaConfig Clone()
        {
            var inst = new FormulaConfig();
            inst.FuncName = FuncName;
            inst.ParamDef = ParamDef;
            inst.ReturnDef = ReturnDef;
            inst.ExprDef = ExprDef;
            inst.Describe = Describe;
            return inst;
        }
    }
}