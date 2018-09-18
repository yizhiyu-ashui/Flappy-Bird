using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    public AudioSource audio;
    public List<AudioClip> clips;
    public float force;//弹跳力度
    public float moveSpeed;  //障碍物的移动速度
    public int score; //当前分数
    public int rank = 0;  //等级

    protected override void Awake()
    {
        base.Awake();
    }

    void Start ()
    {
        audio = this.GetComponent<AudioSource>();
        audio.loop = false;  //默认音效死不循环的
        audio.mute = false;
    }

    /// <summary>
    /// 音效播放
    /// </summary>
    /// <param name="clipName"></param>
    public void SoundPlay(string clipName)
    {
        AudioClip clip = Resources.Load<AudioClip>("sound/" + clipName);
        audio.clip = clip;
        audio.Play();
    }
    /// <summary>
    /// 音效暂停
    /// </summary>
    public void SoundPause()
    {
        audio.Pause();
    }

    /// <summary>
    /// 重新开始游戏（初始化场景等一切需要重置的）
    /// </summary>
    public void RePlayGame()
    {
        //TODO 重新加载一次当前场景
        Thread.Sleep(1000); //等待1s
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// 计算等级
    /// </summary>
    public void CalculatedRank(int score)
    {
        rank = score / 10; //每隔10分升1级
        if (rank == 1)
        {
            moveSpeed = Mathf.Lerp(0.5f, 1, 3);
        }
        else if (rank == 2)
        {
            moveSpeed = Mathf.Lerp(1, 1.25f, 3);
        }
        else if(rank == 3)
        {
            moveSpeed = Mathf.Lerp(1.25f, 1.5f, 3);
        }
        else if (rank == 4)
        {
            moveSpeed = Mathf.Lerp(1.5f, 1.8f, 3);
        }
        else if (rank >= 5)
        {
            moveSpeed = Mathf.Lerp(1.8f, 2.0f, 3);
        }
    }
}
