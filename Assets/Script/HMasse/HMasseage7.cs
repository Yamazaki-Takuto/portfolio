using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HMasseage7 : MonoBehaviour
{
    TextMeshPro textmeshPro;
    float i = 0.0f;
    public int TextFlg7 = 0;
    GameObject password;
    


    void Start()
    {

        password = GameObject.Find("GameObject4");
        textmeshPro = GetComponent<TextMeshPro>();

        // ���݂̃J���[���擾
        Color currentColor = textmeshPro.color;



        // �ݒ肵���V�����J���[��K�p
        textmeshPro.color = currentColor;
    }



    void Update()
    {
        if (TextFlg7 == 1)
        {
            password.GetComponent<Password>().tx7Flg = 1;
            i += Time.deltaTime;

            ChangeAlpha(i);
           

        }
    }

    void ChangeAlpha(float newAlpha)
    {
        Color currentColor = textmeshPro.color;
        textmeshPro.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
    }
}
