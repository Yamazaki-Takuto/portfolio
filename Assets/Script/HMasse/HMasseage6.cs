using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HMasseage6 : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    float i = 0.0f;
    public int TextFlg6 = 0;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.color = new Color(255f, 255f, 255f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (TextFlg6 == 1)
        {
            i += Time.deltaTime;
            textMeshPro.color = new Color(255f, 255f, 255f, i);
        }
    }
}
