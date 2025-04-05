using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("@2HomeScape"); // メインシーンに移動
    }

    public void ExitGame()
    {
        Debug.Log("ゲーム終了");
        Application.Quit(); // ゲームを終了
    }
}
