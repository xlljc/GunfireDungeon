
using System;
using System.Collections;
using Godot;

public static class NodeAnimation
{
    /// <summary>
    /// 将物体渐变显示
    /// </summary>
    /// <param name="activityObject">指定对象</param>
    /// <param name="time">时间, 单位: 秒</param>
    /// <param name="finish">完成回调</param>
    public static void PlayShowAnimation(this ActivityObject activityObject, float time, Action finish = null)
    {
        activityObject.StartCoroutine(_PlayShowAnimation(activityObject, time, finish));
    }

    /// <summary>
    /// 将物体渐变隐藏
    /// </summary>
    /// <param name="activityObject">指定对象</param>
    /// <param name="time">时间, 单位: 秒</param>
    /// <param name="finish">完成回调</param>
    public static void PlayHideAnimation(this ActivityObject activityObject, float time, Action finish = null)
    {
        activityObject.StartCoroutine(_PlayAlphaAnimation(activityObject, time, finish));
    }

    private static IEnumerator _PlayShowAnimation(ActivityObject activityObject, float time, Action action)
    {
        activityObject.Visible = true;
        var modulateA = activityObject.Modulate.A;
        var speed = (1f - modulateA) / time;
        while (modulateA < 1f)
        {
            modulateA += speed * (float)activityObject.GetProcessDeltaTime();
            var color = activityObject.Modulate;
            color.A = modulateA;
            activityObject.Modulate = color;
            yield return null;
        }
        
        if (action != null)
        {
            action();
        }
    }
    
    private static IEnumerator _PlayAlphaAnimation(ActivityObject activityObject, float time, Action action)
    {
        var modulateA = activityObject.Modulate.A;
        var speed = modulateA / time;
        while (modulateA > 0f)
        {
            modulateA -= speed * (float)activityObject.GetProcessDeltaTime();
            var color = activityObject.Modulate;
            color.A = modulateA;
            activityObject.Modulate = color;
            yield return null;
        }
        activityObject.Visible = false;

        if (action != null)
        {
            action();
        }
    }

    /// <summary>
    /// 播放相机缩放动画
    /// </summary>
    /// <param name="camera">相机对象</param>
    /// <param name="targetZoom">目标缩放值</param>
    /// <param name="speed">速度</param>
    /// <param name="finish">完成回调</param>
    public static void PlayZoomAnimation(this GameCamera camera, Vector2 targetZoom, float speed, Action finish = null)
    {
        GameApplication.Instance.StartCoroutine(_StartZoomAnimation(camera, targetZoom, speed, finish));
    }
    
    private static IEnumerator _StartZoomAnimation(GameCamera camera, Vector2 targetZoom, float speed, Action finish)
    {
        var currZoom = camera.Zoom;
        
        while (targetZoom != currZoom)
        {
            currZoom = currZoom.MoveToward(targetZoom, speed * (float)camera.GetProcessDeltaTime());
            camera.Zoom = currZoom;
            yield return null;
        }
        
        if (finish != null)
        {
            finish();
        }
    }
}