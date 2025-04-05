using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner1 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float a;
    GameObject Dirt1;
    GameObject Person;
    void Start()
    {

        Dirt1 = GameObject.Find("dirt1");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        a = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += a;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt1.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
