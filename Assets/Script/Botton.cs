using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botton : MonoBehaviour
{
    GameObject elizabeth;
    GameObject Variant;
   
    public float moveSpeed = 1f;
    public Text textUI;
    public Text taxt1;
    int ElizaFlg = 0;
    int SetFlg = 0;
    float i = 0f;
    private void Start()
    {
        elizabeth = GameObject.Find("Elizabeth");
        Variant = GameObject.Find("Scavenger Variant");
        
        
    }
    public void YesButtonDown()
    {
        ElizaFlg = 1;
    }

    private void Update()
    {

        if (ElizaFlg == 1 && SetFlg ==0)
        {
            i += Time.deltaTime;
            textUI.text = "M‚¶‚Ä‚­‚ê‚Ä‚ ‚è‚ª‚Æ‚¤";
            if (i > 3f && SetFlg ==0)
            {
                textUI.text = "‚í‚µ‚½‚¿‚Í‚¢‚Â‚¾‚Á‚Ä‚¸‚Á‚Æ‰Æ‘°‚¾I";
                elizabeth.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                Variant.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
              
            }
            if(i > 7f )
            {
                SetFlg = 1;
                if(SetFlg == 1)
                elizabeth.SetActive(false);
                Variant.SetActive(false);
            }
            
        }
    }
}
