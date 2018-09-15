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

    private AudioSource audio;
    public List<AudioClip> clips;

    public float moveSpeed;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start ()
    {
        audio = this.GetComponent<AudioSource>();
        audio.loop = false;  //默认音效死不循环的
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
    /// 开始游戏（初始化场景等一切需要重置的）
    /// </summary>
    public void PlayGame()
    {

    }
}
