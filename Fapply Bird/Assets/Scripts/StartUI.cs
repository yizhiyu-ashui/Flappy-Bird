using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour {

    public GameObject LobbyUI; //游戏大厅


    public void StartClick()
    {
        SceneManager.LoadScene("Main");
    }


}
