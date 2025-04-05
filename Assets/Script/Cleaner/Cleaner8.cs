using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner8 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float y;
    GameObject Dirt8;
    GameObject Person;
    void Start()
    {

        Dirt8 = GameObject.Find("dirt8");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        y = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += y;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt8.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
