using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HMasseage : MonoBehaviour
{
    TextMeshPro textmeshPro;
    float i = 0.0f;
    public int TextFlg = 0;
   


    void Start()
    {
         textmeshPro = GetComponent<TextMeshPro>();

        // ���݂̃J���[���擾
        Color currentColor = textmeshPro.color;

       

        // �ݒ肵���V�����J���[��K�p
        textmeshPro.color = currentColor;
    }


    
    void Update()
    {
        if (TextFlg == 1)
        {
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
