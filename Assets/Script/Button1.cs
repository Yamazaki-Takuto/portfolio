using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    GameObject elizabeth;
    GameObject Variant;
    GameObject main;
    Animator animator;
    GameObject pane;//�p�l��
    public float moveSpeed = 1f;
    public Text textUI;
    public Text taxt1;
    public Button buttonA;
    public Button ButtonB;
    public int ElizaFlg, FatherFlg;
    int YesFlg = 0;
    float i = 0f;
    float f = 0f;
    private void Start()
    {
        elizabeth = GameObject.Find("Elizabeth");
        Variant = GameObject.Find("Scavenger Variant");
        main = GameObject.Find("GameObject");
        pane = GameObject.Find("Panel");
        buttonA = GetComponent<Button>();
        ButtonB = GetComponent<Button>();
        animator = GetComponent<Animator>();//�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
      
    }
    public void YesButtonDown()
    {
        ElizaFlg = 1;
        buttonA.gameObject.SetActive(false);
    }

    public void NoButtonDown()
    {
        FatherFlg = 1;
        ButtonB.gameObject.SetActive(false);
        
    }

    private void Update()
    {
        f += Time.deltaTime;
        if (ElizaFlg == 1 && YesFlg ==0)
        {
            i += Time.deltaTime;
            textUI.text = "�M���Ă���Ă��肪�Ƃ�";
            if (i > 3f && YesFlg ==0)
            {
                textUI.text = "�킵�����͂������Ă����ƉƑ����I";
                elizabeth.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                Variant.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
              
            }
            if(i > 7f )
            {
                YesFlg = 1;
                if(YesFlg == 1)
                elizabeth.SetActive(false);
                Variant.SetActive(false);
            }
            
        }

        if(FatherFlg == 1 )
        {
            f = 0f;
            f = Time.deltaTime;
            textUI.text = "�ӂ�����ȁI�@�ǂ����ĐM�����Ȃ���";
           
        }
        
        if(f > 2f)
        {
          
            textUI.text = "�����������Ă����܂��I";
            this.Variant.GetComponent<Animator>().SetTrigger("moveTrigger");
            Variant.GetComponent<OldScript>().moveFlg = 1;
            main.GetComponent<CameraScript>().Zopen = 1;

        }

    }
}
