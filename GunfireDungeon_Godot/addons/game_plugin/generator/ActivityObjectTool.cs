#if TOOLS

using System;
using System.Collections.Generic;
using System.Reflection;
using Godot;
using UI.develop.EditorTools;

namespace Generator;

public static class ActivityObjectTool
{
    /// <summary>
    /// 根据属性初始化ActivityObject属性
    /// </summary>
    private static void OnExamineExportFillNode(string propertyName, Type type, Node node, bool isJustCreated)
    {
        switch (propertyName)
        {
            case "ShadowSprite":
            {
                var sprite = (Sprite2D)node;
                if (isJustCreated)
                {
                    sprite.ZIndex = -1;
                }

                if (sprite.Texture == null && sprite.Material == null) //没有自定义纹理的情况下自动补全阴影材质
                {
                    var material =
                        ResourceManager.Load<ShaderMaterial>(ResourcePath.resource_material_Blend_tres, false);
                    material.ResourceLocalToScene = true;
                    material.SetShaderParameter("blend", new Color(0, 0, 0, 0.47058824F));
                    material.SetShaderParameter("schedule", 1f);
                    material.SetShaderParameter("modulate", new Color(1, 1, 1, 1));
                    sprite.Material = material;
                }
            }
                break;
            case "AnimatedSprite":
            {
                var animatedSprite = (AnimatedSprite2D)node;
                if (animatedSprite.Material == null)
                {
                    var material =
                        ResourceManager.Load<ShaderMaterial>(ResourcePath.resource_material_Blend_tres, false);
                    material.ResourceLocalToScene = true;
                    material.SetShaderParameter("blend", new Color(1, 1, 1, 1));
                    material.SetShaderParameter("schedule", 0);
                    material.SetShaderParameter("modulate", new Color(1, 1, 1, 1));
                    animatedSprite.Material = material;
                }
            }
                break;
            case "Collision":
            {

            }

                break;
        }
    }

    /// <summary>
    /// 执行初始化当前ActivityObject
    /// </summary>
    public static bool InitActivityObject()
    {
        var editorInterface = EditorInterface.Singleton;
        var sceneRoot = editorInterface.GetEditedSceneRoot();
        if (sceneRoot != null && sceneRoot is CharacterBody2D node)
        {
            try
            {
                return InitNodeInEditor(node);
            }
            catch (Exception e)
            {
                Debug.LogError("执行初始化ActivityObject发生异常: \n" + e);
                return false;
            }
        }
        return true;
    }
    
    private static bool InitNodeInEditor(CharacterBody2D body)
    {
        var parent = body.GetParent();
        if (parent != null)
        {
            //寻找 owner
            Node owner;
            if (parent.Owner != null)
            {
                owner = parent.Owner;
            }
            else if (EditorInterface.Singleton.GetEditedSceneRoot() == body)
            {
                owner = body;
            }
            else
            {
                owner = parent;
            }

            var type = GetActivityObjectType(body);
            if (type == null) return false;
            var propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var propertyInfoList = new List<PropertyInfo>();
            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(typeof(ExportFillNodeAttribute), false).Length > 0)
                {
                    if (propertyInfo.GetCustomAttributes(typeof(ExportAttribute), false).Length == 0)
                    {
                        EditorToolsPanel.ShowConfirmInEditor("警告", $"'{type.FullName}'中字段'{propertyInfo.Name}'使用了[ExportAutoFill],\n但是并没有加上[Export], 请补上!");
                        return false;
                    }

                    if (propertyInfo.PropertyType.IsAssignableTo(typeof(Node)))
                    {
                        if (propertyInfo.SetMethod == null)
                        {
                            EditorToolsPanel.ShowConfirmInEditor("警告", $"请为'{type.FullName}'中的'{propertyInfo.Name}'属性设置set访问器, 或者将set服务器设置成public!");
                            return false;
                        }
                        propertyInfoList.Add(propertyInfo);
                    }
                }
            }
            
            var tempList = new List<PropertyInfo>();
            Type tempType = null;
            var index = -1;
            for (int i = propertyInfoList.Count - 1; i >= 0; i--)
            {
                var item = propertyInfoList[i];
                if (tempType != item.DeclaringType || i == 0)
                {
                    if (tempType == null)
                    {
                        index = i;
                    }
                    else
                    {
                        int j;
                        if (i == 0)
                        {
                            j = i;
                        }
                        else
                        {
                            j = i + 1;
                        }
                        for (; j <= index; j++)
                        {
                            tempList.Add(propertyInfoList[j]);
                        }

                        index = i;
                    }
                    tempType = item.DeclaringType;
                }
            }
            
            foreach (var propertyInfo in tempList)
            {
                var value = body.Get(propertyInfo.Name).Obj;
                if (value == null || (value is Node v && v.GetParent() == null))
                {
                    var node = _FindNodeInChild(body, propertyInfo.Name, propertyInfo.PropertyType);
                    if (node == null)
                    {
                        node = (Node)Activator.CreateInstance(propertyInfo.PropertyType);
                        body.AddChild(node);
                        node.Name = propertyInfo.Name;
                        node.Owner = owner;
                        
                        OnExamineExportFillNode(propertyInfo.Name, type, node, true);
                    }
                    else
                    {
                        OnExamineExportFillNode(propertyInfo.Name, type, node, false);
                    }
                    body.Set(propertyInfo.Name, node);
                }
                else
                {
                    OnExamineExportFillNode(propertyInfo.Name, type, (Node)value, false);
                }
            }
        }

        return true;
    }

    private static Node _FindNodeInChild(Node node, string name, Type type)
    {
        var childCount = node.GetChildCount();
        for (int i = 0; i < childCount; i++)
        {
            var child = node.GetChild(i);
            if (child.Name == name && child.GetType().IsAssignableTo(type))
            {
                return child;
            }
            else
            {
                var result = _FindNodeInChild(child, name, type);
                if (result != null)
                {
                    return result;
                }
            }
        }

        return null;
    }

    private static Type GetActivityObjectType(CharacterBody2D body)
    {
        var inst = body.GetScript().As<CSharpScript>()?.New();
        if (!inst.HasValue) return null;
        var go = inst.Value.Obj as GodotObject;
        if (go == null) return null;
        try
        {
            if (go is ActivityObject activityObject)
            {
                return activityObject.GetType();
            }
        }
        finally
        {
            if (go is Node node)
            {
                node.QueueFree();
            }
            else
            {
                go.Dispose();
            }
        }
        
        return null;
    }
}

#endif