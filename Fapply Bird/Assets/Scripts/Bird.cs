using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Bird : MonoBehaviour
{
    public Vector2 force; //力度

    private Rigidbody2D rigidbody;
    private Animator animator;
    private AudioSource audio;

	void Start ()
	{
	    rigidbody = this.GetComponent<Rigidbody2D>();
	    animator = this.GetComponent<Animator>();
	    audio = this.GetComponent<AudioSource>();

	    //force.y = GameManager.Instance.force;
	}
	
	void Update ()
	{

	    if (GameManager.Instance.isOver)
	        return;

	    if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
	    {
	        AddForce(force);
	    }
	}
    /// <summary>
    /// 添加力
    /// </summary>
    /// <param name="force"></param>
    private void AddForce(Vector2 force)
    {
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
        Vector2 velocity = rigidbody.velocity;
        velocity.y = 0;
        rigidbody.velocity = velocity;  //每次点击加力的时候先把刚体向上的速度归零，这样就不会在原有的速度上再加速度，就不会越点击升得越快了，就是每次点击都会上升等同的高度
        rigidbody.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TAG.Ground)
        {
            Debug.Log("碰到地板了");
            GameManager.Instance.SoundPause();
            GameManager.Instance.isMove = false;
            animator.SetBool("isFly", false);
        }
        else if (collision.gameObject.tag == TAG.UpObstacle || collision.gameObject.tag == TAG.DownObstacle)
        {
            //TODO 游戏结束处理
            Debug.Log("游戏结束");
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            GameManager.Instance.SoundPlay(Sound.Hit);
            GameManager.Instance.isOver = true;
            animator.SetBool("isFly", false);
            UIManager.Instance.ShowUI(UIManager.Instance.GameOverUI);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TAG.Point)
        {
            //TODO 碰到得分板，加分处理
            UIManager.Instance.SetCurrentScore(++GameManager.Instance.score);
            SoundPlay(Sound.Point);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("飞起来了");
        GameManager.Instance.isMove = true;
        animator.SetBool("isFly", true);
        GameManager.Instance.SoundPlay(Sound.Fly);
    }

    public void SoundPlay(string clipName)
    {
        AudioClip clip = Resources.Load<AudioClip>("sound/" + clipName);
        audio.clip = clip;
        audio.Play();
    }
}
