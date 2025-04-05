using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour
{
    public GameObject game4;
    public int chestFlg = 0;
    public AudioClip ChestClip;
    public AudioSource audioSource;
    private Animator anim;
    private bool isOpen = false;
    void Start()
    {
        game4 = GameObject.Find("GameObject4");
        anim = gameObject.GetComponent<Animator>();  // Animatorコンポーネントを取得
       audioSource = GetComponent<AudioSource>();
        audioSource.clip = ChestClip;
    }

    void Update()
    {
        chestFlg = game4.GetComponent<Password>().PassFlg;
        if (chestFlg == 1 && !isOpen)
        {
            audioSource.Play();
            anim.SetTrigger("chestTrigger");
            isOpen = true;
        }
    }
}