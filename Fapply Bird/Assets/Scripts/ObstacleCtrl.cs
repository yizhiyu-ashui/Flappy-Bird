using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : MonoBehaviour {

    private GameObject pipePrefab;

    private int spawnNum;//新生的数量
	void Start ()
	{
	    pipePrefab = Resources.Load<GameObject>("Prefab/Pipe");
	}
	
	void Update () {
        if (GameManager.Instance.isOver)
            return;
        if (GameManager.Instance.isMove)
	    {
	        HorizontalMove();
	    }

	    SpawnAndDestroy();
	}

    /// <summary>
    /// 水平向左移动
    /// </summary>
    private void HorizontalMove()
    {
        if (this.transform.childCount <= 0)
            return;
        float moveSpeed = GameManager.Instance.moveSpeed;
        foreach (Transform child in this.transform)
        {
            child.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
    }
    /// <summary>
    /// 生成和销毁
    /// </summary>
    private void SpawnAndDestroy()
    {
        foreach (Transform child in this.transform)
        {
            if (child.localPosition.x <= -7.6f)
            {
                Destroy(child.gameObject);
                spawnNum++;
            }
        }
        GameObject pipe;
        int x = Random.Range(2,7);//每个管道之间的间隔，默认是2个单位（最近能过间隔），应该由等级决定，等级越高间隔越近
        while (spawnNum > 0)
        {
            pipe = Instantiate(pipePrefab, this.transform);
            pipe.transform.localPosition = new Vector3(transform.GetChild(transform.childCount - 2).localPosition.x + x, 0, 0);
            spawnNum--;
            switch (GameManager.Instance.rank)
            {
                case 1:
                    float num = Random.Range(0.0f, 10.0f);
                    if (num < 8.0f)
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Static;
                        break;
                    }
                    else
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Rise;
                        break;
                    }
                case 2:
                case 3:
                    num = Random.Range(0.0f, 10.0f);
                    if (num < 5.0f)
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Static;
                        break;
                    }
                    else
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Rise;
                        break;
                    }           
                case 4:
                     num = Random.Range(0.0f, 10.0f);
                    if (num < 4.0f)
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Static;
                        break;
                    }
                    else if (num < 8 && num >= 4)
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Rise;
                        break;
                    }
                    else
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Rotate;
                        break;
                    }
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    num = Random.Range(0.0f, 10.0f);
                    if (num < 3.0f)
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Static;
                        break;
                    }
                    else if (num < 6 && num >= 3)
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Rise;
                        break;
                    }
                    else
                    {
                        pipe.GetComponent<Pipe>().pipeType = Pipe.PipeType.Rotate;
                        break;
                    }
                    break;
                default:
                    break;
            }
           
        }

    }

}
