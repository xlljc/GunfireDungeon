using Godot;
using System;
using System.Collections.Generic;
using DsUi;

public partial class NumberSprite : Node2D, IDestroy
{
    [Export]
    public Sprite2D Templdate;

    public bool IsDestroyed { get; private set; }
    
    private int _value;
    private List<Sprite2D> _useList = new List<Sprite2D>();
    private Stack<Sprite2D> _stackInsts = new Stack<Sprite2D>();
    
    public void SetNumber(int value)
    {
        _value = value;
    }
    
    public int GetNumber()
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

        return (Sprite2D)Templdate.Duplicate();
    }
}
