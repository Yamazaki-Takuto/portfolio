using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    GameObject elizabeth;
    GameObject Variant;
    GameObject gameObj;
    GameObject gameObj2;
    GameObject main;
    Animator animator;
    public float moveSpeed = 1f;
    public Text textUI;
    public Text text2;
    public Text text3cnt;
    public Text text4;
    public GameObject Yesbutton;
    public GameObject Nobutton;
    GameObject Gameobject;
    public int ElizaFlg = 0;
   public int FatherFlg = 0;
    public int NoFlg = 0;
    int YesFlg = 0;
    int SetFlg = 0;
    float countdownTimer = 3f;
    float i = 0f;
    float f = 0f;
    GameObject gameObj3;
    float h;
    private void Start()
    {
        elizabeth = GameObject.Find("Elizabeth");
        Variant = GameObject.Find("Scavenger Variant");
        Gameobject = GameObject.Find("GameObject");//本体
        gameObj = GameObject.Find("GameObject(1)");
        gameObj2 = GameObject.Find("GameObject(2)");
        gameObj3 = GameObject.Find("GameObject(3)");
        main = GameObject.Find("GameObject");
        animator = GetComponent<Animator>();//変数animに、Animatorコンポーネントを設定する
        textUI.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3cnt.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
        Yesbutton.SetActive(false);
        Nobutton.SetActive(false);
    }
    public void YesButtonDown()
    {
        ElizaFlg = 1;
        
    }

    public void NoButtonDown()
    {
        FatherFlg = 1;
        text3cnt.gameObject.SetActive(true);
    }

    private void Update()
    {
        h += Time.deltaTime;
        if (h >= 37f)
        {
            Yesbutton.SetActive(true);
            Nobutton.SetActive(true);
            textUI.gameObject.SetActive(true);
            text2.gameObject.SetActive(true);
        }


        
        if (ElizaFlg == 1 && YesFlg ==0)
        {
            text4.gameObject.SetActive(true);
            i += Time.deltaTime;
            Yesbutton.SetActive(false);
            Nobutton.SetActive(false);
            SetFlg = 1;
            text4.text = "信じてくれてありがとう";
            if (i > 3f && YesFlg ==0)
            {
                
                text4.text = "わしたちはいつだってずっと家族だ！";
                elizabeth.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                Variant.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
              
            }
            if(i > 7f )
            {
                YesFlg = 1;
                if(YesFlg == 1)
                elizabeth.SetActive(false);
                Variant.SetActive(false);
               SceneManager.LoadScene("clear");
                
            }
          
            
        }
       
        if (FatherFlg == 1 )
        {
           
            Yesbutton.SetActive(false);
            Nobutton.SetActive(false);
          
            f += Time.deltaTime;
            NoFlg = 1;
            textUI.text = "(父)　ふざけるな！　どうして信じられないんだ";
            SetFlg = 1;

            if (f >= 3f)
            {
                textUI.gameObject.SetActive(false);
                if (f >= 5f)
                {

                    countdownTimer -= Time.deltaTime;
                    text2.text = "パパが襲ってきます!かわしてください";
                    text3cnt.text = Mathf.Ceil(countdownTimer).ToString(); ;
                    Debug.Log(countdownTimer);

                }
            }
        }
        if (f > 8f && NoFlg == 1)
        {
            textUI.gameObject.SetActive(true);
            Gameobject.GetComponent<CameraScript>().TextFlg = 1;
            text3cnt.gameObject.SetActive(false);
           
            textUI.text = "(母)　お父さんやっておしまい！";
            elizabeth.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            
            this.Variant.GetComponent<Animator>().SetTrigger("moveTrigger");
            Variant.GetComponent<OldScript>().moveFlg = 1;
            main.GetComponent<CameraScript>().Zopen = 1;

            if(f > 10f)
            {
                textUI.gameObject.SetActive(false);
            }
        }


        if(SetFlg == 1)
        {
            Yesbutton.SetActive(false);
            Nobutton.SetActive(false);
        }

    }
}
