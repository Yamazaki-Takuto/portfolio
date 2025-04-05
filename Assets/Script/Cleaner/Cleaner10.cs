using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner10 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float j;
    GameObject Dirt10;
    GameObject Person;
    void Start()
    {
        Dirt10 = GameObject.Find("dirt10");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        j = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += j;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt10.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
