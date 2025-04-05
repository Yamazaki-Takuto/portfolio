using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Password : MonoBehaviour
{
   
    [SerializeField] GameObject fieldObj;
    private InputField inputField;
    public int PassFlg = 0;
    private GameObject chest;//•ó” 
    GameObject Person;
    public int tx7Flg = 0; 
    
    void Start()
    {
        fieldObj = GameObject.Find("InputField");
        inputField = fieldObj.GetComponent<InputField>();
        inputField.gameObject.SetActive(false);
        Person = GameObject.Find("person");
        chest = GameObject.Find("Takarabako");
       
    }

    private void Update()
    {
     if(   Person.GetComponent<Person_Controller>().tFlg == 1)
        {
            inputField.gameObject.SetActive(true);
        }
    }

    public void InputText()
    {
        if (tx7Flg == 1)
        {
          
            if (inputField.text == "ILoveYou")
            {
                PassFlg = 1;
                inputField.gameObject.SetActive(false);

               
                
            }
           

        }
        else
        {
            Debug.Log("Žc”Oƒtƒ‰ƒO‚ª—§‚Á‚Ä‚Ü‚¹‚ñ");
        }
    }

    
   
}

