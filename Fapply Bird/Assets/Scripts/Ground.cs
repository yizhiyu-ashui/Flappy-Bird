using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地板的平移控制
/// scy/2018-09-14
/// </summary>
public class Ground : MonoBehaviour {

    public GameObject[] ground;

    void Update () {
        //if (GameManager.Instance.isOver)
        //    return;
        if (GameManager.Instance.isMove)
	    {
	        HorizontalMove();

	    }
    }

    /// <summary>
    /// 水平移动
    /// </summary>
    private void HorizontalMove()
    {
        if (ground == null || ground.Length <= 0)
            return;
        float moveSpeed = GameManager.Instance.moveSpeed; //平移速度
        foreach (Transform child in this.transform)
        {
            child.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        //地板循环
        for (int i = 0; i < 2; i++)
        {
            if (ground[i].transform.localPosition.x <= -10.8f)
                ground[i].transform.localPosition = new Vector3(10.8f, ground[i].transform.localPosition.y, ground[i].transform.localPosition.z);
        }
        //背景循环
        for (int i = 2; i < 6; i++)
        {
            if (ground[i].transform.localPosition.x <= -7.3f)
                ground[i].transform.localPosition = new Vector3(7.3f, ground[i].transform.localPosition.y, ground[i].transform.localPosition.z);
        }
        
            
    }
}
