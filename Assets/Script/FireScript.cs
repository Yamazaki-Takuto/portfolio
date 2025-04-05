using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{

    private float collisionStartTime;
    public float collisionDuration = 5f;//コリジョンデュレーション
   
    public GameObject flame;   // 炎オブジェクト
    GameObject Person;
    GameObject text;
    
    void Start()
    {
        Person = GameObject.Find("person");
        text = GameObject.Find("FireText");
    }

   

    private void OnTriggerEnter(Collider collider)
    {
       
        if (collider.gameObject.CompareTag("Fire"))
        {
            Debug.Log("炎に当たったよ！");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            collisionStartTime += Time.deltaTime;
        }
        
        if(collisionStartTime > collisionDuration)
        {
            Person.GetComponent<Person_Controller>().flameFlg = 1;
            Person.GetComponent<Person_Controller>().flame.SetActive(false);
            text.GetComponent<Message>().MessaFlg = 1;
            Person.GetComponent<Person_Controller>().PreFlg = 1;
            Debug.Log("炎が消えたよ");
            
        }
    }

   

}
