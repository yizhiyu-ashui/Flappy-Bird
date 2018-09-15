﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : MonoBehaviour
{
    public Vector2 force; //力度

    private Rigidbody2D rigidbody;
    private Animator animator;

	void Start ()
	{
	    rigidbody = this.GetComponent<Rigidbody2D>();
	    animator = this.GetComponent<Animator>();
	}
	
	void Update () {

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
            GameManager.Instance.isMove = false;
            animator.SetBool("isFly", false);
        }else if (collision.gameObject.tag == TAG.UpObstacle || collision.gameObject.tag == TAG.DownObstacle)
        {
            //TODO 游戏结束处理
            Debug.Log("游戏结束");
            GameManager.Instance.isOver = true;
            animator.SetBool("isFly", false);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("飞起来了");
        GameManager.Instance.isMove = true;
        animator.SetBool("isFly", true);
       
    }

}
