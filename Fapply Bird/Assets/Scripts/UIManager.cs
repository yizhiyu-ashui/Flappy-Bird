using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoSingle<UIManager>
{
    public GameObject tapUI;
    public GameObject GameOverUI; //游戏结束UI界面
    public Text scoreTxt;       //本场分数
    public Text bestScoreTxt;   //最佳分数
    public Text currentSocreTxt; //当前分数

	void Start ()
	{
	    HideUI(GameOverUI);
	    SetScore(0);
	    SetCurrentScore(0);

	}
    /// <summary>
    /// 显示对应UI界面
    /// </summary>
    /// <param name="ui"></param>
    public void ShowUI(GameObject ui)
    {
        if (!ui.activeSelf)
            ui.SetActive(true);
        SetScore(GameManager.Instance.score);
    }
    /// <summary>
    /// 隐藏对应UI界面
    /// </summary>
    /// <param name="ui"></param>
    public void HideUI(GameObject ui)
    {
        if(ui)
        if (ui.activeSelf)
            ui.SetActive(false);
    }
    /// <summary>
    /// 重玩点击
    /// </summary>
    public void RePlayClick()
    {
        HideUI(GameOverUI);
        GameManager.Instance.RePlayGame();
    }
    /// <summary>
    /// 返回点击
    /// </summary>
    public void ReturnClick()
    {
        //TODO 返回开始场景
        Debug.Log("return start scene");
        SceneManager.LoadScene("Start");
    }

    public void SetScore(int score)
    {
        
        int bestScore = 0;
        if (PlayerPrefs.HasKey("BEST"))
        {
            bestScore = PlayerPrefs.GetInt("BEST");
        }

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BEST", bestScore);
        }
        scoreTxt.text = score.ToString();
        bestScoreTxt.text = bestScore.ToString();
    }

    public void SetCurrentScore(int score)
    {
        currentSocreTxt.text = "得分:"+score.ToString();
    }

    public void SetForce(int force)
    {

        SceneManager.LoadScene("Main");
        GameManager.Instance.force = force;
    }
}
