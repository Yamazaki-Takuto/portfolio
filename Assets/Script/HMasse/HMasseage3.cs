using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HMasseage3 : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    float i = 0.0f;
    public int TextFlg3 = 0;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.color = new Color(255f, 255f, 255f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (TextFlg3 == 1)
        {
            i += Time.deltaTime;
            textMeshPro.color = new Color(255f, 255f, 255f, i);
        }
    }
}
