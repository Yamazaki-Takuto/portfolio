using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameOver : MonoBehaviour
{
    float i = 0f;
    public Image Image;
    [SerializeField] private AudioSource a1;
    [SerializeField] private AudioSource a2;

    [SerializeField] private AudioClip b1;
    [SerializeField] private AudioClip b2;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Image.enabled = false;
        // AudioSourceコンポーネントの取得
        audioSource = gameObject.AddComponent<AudioSource>();

        // AudioClipの設定
        audioSource.clip = b1;

        // 効果音1の再生
        SE1();
    }

    // Update is called once per frame
    void Update()
    {
        i += Time.deltaTime;
        if(i >= 7f)
        {
            Image.enabled = true;
            // AudioClipを効果音2に変更
        audioSource.clip = b2;

            // 効果音2の再生
            SE2();
        }
    }
    public void SE1()
    {
        a1.PlayOneShot(b1);//a1にアタッチしたAudioSourceの設定値でb1にアタッチした効果音を再生
    }

    //自作の関数2
    public void SE2()
    {
        a2.PlayOneShot(b2);//a2にアタッチしたAudioSourceの設定値でb2にアタッチした効果音を再生
    }
}
