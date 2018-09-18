using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour {

    public GameObject LobbyUI; //游戏大厅
    public GameObject audioBtn;
    public Sprite[] audioImg;

    public void StartClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitClick()
    {
        Application.Quit();
    }

    public void SwitchAudio()
    {
        AudioSource audio = this.GetComponent<AudioSource>();
        if (audio.isPlaying)
        {
            audio.Pause();
            audioBtn.GetComponent<Image>().sprite = audioImg[1];
        }
        else
        {
            audio.Play();
            audioBtn.GetComponent<Image>().sprite = audioImg[0];
        }


    }
}
