using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner11 : MonoBehaviour
{

    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float u;
    GameObject  Dirt11;
    GameObject Person;

    void Start()
    {

        Dirt11 = GameObject.Find("dirt11");
        Person = GameObject.Find("person");

    }

    private void Update()
    {
        u = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += u;


            if (startTime > destroy && destroyFlg == 0)
            {
               
                Dirt11.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
