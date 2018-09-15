using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Threading;
using Random = UnityEngine.Random;


/// <summary>
/// 障碍物
/// scy/2018-09-14
/// </summary>
public class Pipe : MonoBehaviour
{
    /*
     * 管道的控制：
     * 状态分为：静止 、上下移动 、旋转
     * 1、随机初始化两个管道间隔距离，最小距离时4.54f,最大距离时9.0f，即间隔范围（0~4.46）
     * 2、初始化移动的速度，间隔：0.96-2.44速度为0.5，间隔：2.44-3.92 速度为1，间隔：3.92-4.46速度为2
     */

    public List<GameObject> obstacles; //两个管道，最高位置5.0f,最小位置-4f，至少相隔5.3f
    /// <summary>
    /// 管道的状态类型
    /// </summary>
    public enum PipeType
    {
        Static = 0,
        Rise = 1,
        Rotate = 2,
    }

    public PipeType pipeType;

    private float riseSpeed; //上下升的速度
    private float rotateSpeed; //旋转速度

    private float randomNum;
    private float initDistance;//初始间隔距离

    
    void Start ()
	{
	    InitPipe();

    }
	
	void Update ()
	{

	    Rise();
	    Rotate();
   
	}

    /// <summary>
    /// 初始化管道
    /// </summary>
    private void InitPipe()
    {
        if (obstacles == null || obstacles.Count <= 0)
            return;
        float y_up = Random.Range(1.8f, 5);
        float y_down = Random.Range(-4, (y_up - 4.54f - 0.9f));
        initDistance = y_up - y_down;
        obstacles[0].transform.localPosition = new Vector3(0, y_up, 0);
        obstacles[1].transform.localPosition = new Vector3(0, y_down, 0);
        randomNum = Random.Range(0, 10);
        float temp = initDistance - 4.54f;
        if (temp <= 2.5f)
        {
            riseSpeed = 0.5f;
            rotateSpeed = 30;

        }
        else if (temp > 2.5 && temp <= 3.5f)
        {
            riseSpeed = 1.0f;
            rotateSpeed = 60;
        }
        else if (temp > 3.5)
        {
            riseSpeed = 2.0f;
            rotateSpeed = 90;
        }
    }

    /// <summary>
    /// 上下移动
    /// </summary>
    private void Rise()
    {
        if (obstacles == null || obstacles.Count <= 0)
            return;
        if (pipeType != PipeType.Rise)
            return;
         
        // 2/5概率上面的管道移动，2/5概率下面的管道移动，1/5概率上下管道都移动
        if (randomNum < 4) 
        {
            obstacles[0].transform.Translate(Vector3.down * Time.deltaTime * riseSpeed);
        }
        else if (randomNum > 6)
        {
            obstacles[1].transform.Translate(Vector3.up * Time.deltaTime * riseSpeed);
        }
        else
        {
            obstacles[0].transform.Translate(Vector3.down * Time.deltaTime * riseSpeed);
            obstacles[1].transform.Translate(Vector3.up * Time.deltaTime * riseSpeed);
        }

        float distance = obstacles[0].transform.localPosition.y - obstacles[1].transform.localPosition.y;
        if (distance <= 4.6f || distance >= initDistance)
        {
            riseSpeed = -riseSpeed;
            Thread.Sleep(50);//休眠50毫秒，防止转变太快容易卡顿
        }
    }
    /// <summary>
    /// 旋转
    /// </summary>
    private void Rotate()
    {
        if (obstacles == null || obstacles.Count <= 0)
            return;
        if (pipeType != PipeType.Rotate)
            return;   
        // 2/5概率上面的管道旋转，2/5概率下面的管道旋转，1/5概率上下管道都旋转
        if (randomNum < 4)
        {
            obstacles[0].transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        }
        else if (randomNum > 6)
        {
            obstacles[1].transform.Rotate(Vector3.back * Time.deltaTime * rotateSpeed);
        }
        else
        {
            obstacles[0].transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
            obstacles[1].transform.Rotate(Vector3.back * Time.deltaTime * rotateSpeed);
        }
    }

}
