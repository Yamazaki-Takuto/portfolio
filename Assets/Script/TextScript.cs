using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro�������ۂɕK�v


public class TextScript : MonoBehaviour
{
    public string[] myArray;
    public TextMeshProUGUI wordText;

    void Start()
    {
        myArray = new string[] { "��H�����", "�p�p�ƃ}�}����Ȃ���", "�悤�I�v���Ԃ肾��", "�܂��I�Ƒ��ʐ^�Ȃ�Ă݂��̉��\�N�Ԃ肩����", "�Ō�ɂ��O�ɉ�Ă悩������B", "�����ˁB����ōŌ�Ȃ̂��..." };
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