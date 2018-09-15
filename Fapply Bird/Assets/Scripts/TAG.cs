using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 游戏物体的标签
/// scy/2018-09-14
/// </summary>
public static class TAG
{

    public const string UpObstacle = "upObstacle"; //上障碍物
    public const string DownObstacle = "downObstacle"; //上障碍物
    public const string Bird = "bird";     //小鸟
    public const string Ground = "ground"; //地板
    public const string Point = "Pipe";  //得分板

}

public static class Sound
{
    public const string Fly = "Fly"; //飞的背景音乐
    public const string Die = "Die"; //死亡音效
    public const string Hit = "Hit"; //打的音效
    public const string Point = "Point"; //得分音效
}
