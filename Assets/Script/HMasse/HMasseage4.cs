using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HMasseage4 : MonoBehaviour
{
    TextMeshPro textmeshPro;
    float i = 0.0f;
    public int TextFlg4 = 0;
   


    void Start()
    {
        textmeshPro = GetComponent<TextMeshPro>();

        // 現在のカラーを取得
        Color currentColor = textmeshPro.color;



        // 設定した新しいカラーを適用
        textmeshPro.color = currentColor;
    }



    void Update()
    {
        if (TextFlg4 == 1)
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
