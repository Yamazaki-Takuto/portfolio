using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HMasseage5 : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    float i = 0.0f;
    public int TextFlg5 = 0;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.color = new Color(255f, 255f, 255f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (TextFlg5 == 1)
        {
            i += Time.deltaTime;
            textMeshPro.color = new Color(255f, 255f, 255f, i);
        }
    }
}
