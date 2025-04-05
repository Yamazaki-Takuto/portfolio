using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProを扱う際に必要


public class TextScript : MonoBehaviour
{
    public string[] myArray;
    public TextMeshProUGUI wordText;

    void Start()
    {
        myArray = new string[] { "ん？あれは", "パパとママじゃないか", "よう！久しぶりだな", "まあ！家族写真なんてみたの何十年ぶりかしら", "最後にお前に会えてよかったよ。", "そうね。これで最後なのよね..." };
        StartCoroutine("SetText");
    }

    IEnumerator SetText()
    {
        foreach (string word in myArray)
        {
            wordText.text = word.ToString();
            yield return new WaitForSeconds(1.0f);
        }
    }
}