using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner7 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float t;
    GameObject Dirt7;
    GameObject Person;
    void Start()
    {

        Dirt7 = GameObject.Find("dirt7");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        t = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += t;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt7.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
