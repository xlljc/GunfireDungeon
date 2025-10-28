using Godot;
using System;
using System.Collections.Generic;
using DsUi;

/// <summary>
/// 用于显示纹理数字
/// </summary>
public partial class NumberSprite : Node2D, IDestroy
{
    
    public enum SpriteDirection
    {
        Left,
        Right,
        Center
    }
    
    /// <summary>
    /// 用于显示精灵的模板实例
    /// </summary>
    [Export]
    public Sprite2D Templdate;
    
    /// <summary>
    /// 精灵纹理方向
    /// </summary>
    [Export]
    public SpriteDirection Direction;

    public bool IsDestroyed { get; private set; }
    
    private uint _value;
    private List<Sprite2D> _useList = new List<Sprite2D>();
    private Stack<Sprite2D> _stackInsts = new Stack<Sprite2D>();

    public override void _Ready()
    {
        _stackInsts.Push(Templdate);
        Templdate.Visible = false;
    }

    /// <summary>
    /// 设置显示的值
    /// </summary>
    public void SetNumber(uint value)
    {
        _value = value;
        //把数字拆成数组
        var list = new List<uint>();
        while (value > 0)
        {
            list.Add(value % 10);
            value /= 10;
        }

        if (list.Count > _useList.Count)
        {
            var c = _useList.Count;
            for (var i = 0; i < list.Count - c; i++)
            {
                var sprite2D = GetInstance();
                sprite2D.Visible = true;
                _useList.Add(sprite2D);
            }
        }
        else if (list.Count < _useList.Count)
        {
            var c = _useList.Count;
            for (var i = 0; i < c - list.Count; i++)
            {
                var sprite2D = _useList[i];
                sprite2D.Visible = false;
                _stackInsts.Push(sprite2D);
                _useList.RemoveAt(i);
            }
        }
        
        for (var i = list.Count - 1; i >= 0; i--)
        {
            var index = list.Count - i - 1;
            var sprite2D = _useList[i];
            sprite2D.Frame = (int)list[i];
            switch (Direction)
            {
                case SpriteDirection.Center:
                    sprite2D.Position = new Vector2(index * 4 - 4 * (list.Count - 1) / 2f, 0);
                    break;
                case SpriteDirection.Left:
                    sprite2D.Position = new Vector2(index * 4, 0);
                    break;
                default:
                    sprite2D.Position = new Vector2(index * 4 - 4 * (list.Count - 1), 0);
                    break;
            }
        }
    }

    /// <summary>
    /// 设置显示颜色
    /// </summary>
    public void SetColor(Color color)
    {
        foreach (var sprite in _useList)
        {
            sprite.Modulate = color;
        }
    }
    
    /// <summary>
    /// 获取当前显示的数字值
    /// </summary>
    public uint GetNumber()
    {
        return _value;
    }
    
    public void Destroy()
    {
        if (IsDestroyed)
        {
            return;
        }
        
        IsDestroyed = true;
        
        foreach (var sprite2D in _stackInsts)
        {
            sprite2D.QueueFree();
        }
        _stackInsts.Clear();
    }

    private Sprite2D GetInstance()
    {
        if (_stackInsts.Count > 0)
        {
            return _stackInsts.Pop();
        }

        var sprite2D = (Sprite2D)Templdate.Duplicate();
        AddChild(sprite2D);
        return sprite2D;
    }
}
