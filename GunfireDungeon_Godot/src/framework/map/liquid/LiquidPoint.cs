
using Config;
using Godot;

public partial class LiquidPoint : Sprite2D
{
    
    private ExcelConfig.LiquidBrush _brush;
    private byte _state = 0;
    private float _timer = 0;

    private static int _count = 0;
    public void Init(ExcelConfig.LiquidBrush brush)
    {
        _brush = brush;
        Debug.Log(++_count);
    }
    
    public void Refresh()
    {
        _state = 0;
        _timer = 0;
        Modulate = Colors.White;
    }


    public override void _Process(double delta)
    {
        var _delta = (float)delta;
        
        if (_state == 0)
        {
            if (_brush.Duration > 0 && _timer >= _brush.Duration)
            {
                _state = 1;
                _timer = 0;
            }
        }
        else if (_state == 1)
        {
            if (_brush.WriteOffSpeed > 0)
            {
                var modulate = Colors.White.Lerp(new Color(1, 1, 1, 0), _timer * _brush.WriteOffSpeed);
                Modulate = modulate;

                if (modulate.A <= 0)
                {
                    _state = 2;
                }
            }
        }

        _timer += _delta;
    }
}