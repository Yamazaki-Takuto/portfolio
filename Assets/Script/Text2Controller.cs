using UnityEngine;
using UnityEngine.UI;

public class Text2Controller : MonoBehaviour
{
    public Text textComponent;
    float i = 0;
    float chatFlg1, chatFlg2, chatFlg3, chatFlg4, chatFlg5, chatFlg6, chatFlg7, chatFlg8, chatFlg9, chatFlg10, chatFlg11, chatFlg12 = 0;//�t���O�ɂO������


    private void Update()
    {
        i += Time.deltaTime;


        if (i > 0f)
        {
            chatFlg1 = 1;
        }

        if (i > 6f)
        {
            chatFlg2 = 1;
        }

        if (i > 8f)
        {
            chatFlg3 = 1;
        }

        if (i > 12f)
        {
            chatFlg4 = 1;
        }
        if (i > 15f)
        {
            chatFlg5 = 1;
        }
        if (i > 19f)
        {
            chatFlg6 = 1;
        }
        if (i > 24f)
        {
            chatFlg7 = 1;
        }
        if (i > 26f)
        {
            chatFlg8 = 1;
        }
        if (i > 28f)
        {
            chatFlg9 = 1;
        }
        if (i > 30f)
        {
            chatFlg10 = 1;
        }
        if (i > 35f)
        {
            chatFlg11 = 1;
        }
        if (i > 37f)
        {
            chatFlg12 = 1;
        }




        if (chatFlg1 == 1 && chatFlg2 == 0)
            {
                SetText("(����)");
            }
            else if (chatFlg2 == 1 && chatFlg3 == 0)
            {
                SetText("(��)");
            }
            else if (chatFlg3 == 1 && chatFlg4 == 0)
            {
                SetText("(��)");
            }
            else if (chatFlg4 == 1 && chatFlg5 == 0)
            {
                SetText("(��)");
            }
            else if (chatFlg5 == 1 && chatFlg6 == 0)
            {
                SetText("(��)");
            }
            else if (chatFlg6 == 1 && chatFlg7 == 0)
            {
                SetText("(����)");
            }
            else if (chatFlg7 == 1 && chatFlg8 == 0)
            {

                SetText(" ");
            }
            else if (chatFlg8 == 1 && chatFlg9 == 0)
            {
                SetText("(��)");

            }
            else if (chatFlg9 == 1 && chatFlg10 == 0)
            {
                SetText(" ");
            }
            else if (chatFlg10 == 1 && chatFlg11 == 0)
            {
                SetText(" ");

            }
            else if (chatFlg11 == 1 && chatFlg12 == 0)
            {
                SetText("(��)");

            }
            else if (chatFlg12 == 1)
            {
                SetText(" ");
        }

            void SetText(string newText)
            {
                // Text�R���|�[�l���g��text�v���p�e�B���g�p���ăe�L�X�g��ύX
                textComponent.text = newText;
            }


        }
    }
