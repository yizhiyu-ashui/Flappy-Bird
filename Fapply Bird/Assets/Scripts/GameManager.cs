using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 整个游戏的管理者
/// scy/2018-9-14
/// </summary>
public class GameManager : MonoSingle<GameManager>
{
    [HideInInspector]
    public bool isOver = false; //判断游戏结束
    [HideInInspector]
    public bool isMove = true; //判断管道平移

    public float moveSpeed;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
