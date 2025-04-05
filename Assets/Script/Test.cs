using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    GameObject quad1, quad2, quad3, quad4, quad5, quad6, quad7, quad8;
    void Start()
    {
        quad1 = GameObject.Find("abc");
      
       
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Yogore1"))
        {
            Debug.Log("ƒˆƒSƒŒ“–‚½‚Á‚½‚æI");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += Time.deltaTime;


            if (startTime > destroy)
            {
                quad1.SetActive(false);
            }
        }
    }

   
}
