using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("@2HomeScape"); // ���C���V�[���Ɉړ�
    }

    public void ExitGame()
    {
        Debug.Log("�Q�[���I��");
        Application.Quit(); // �Q�[�����I��
    }
}
