using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    float i = 0.0f;
    public int MessaFlg = 0;
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.color = new Color(255f, 255f, 255f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(MessaFlg == 1)
        {
            i += Time.deltaTime;
            textMeshPro.color = new Color(255f, 255f, 255f, i);
        }
    }
}
