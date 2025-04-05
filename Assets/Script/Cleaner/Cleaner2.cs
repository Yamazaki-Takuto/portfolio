using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner2 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float s;
    GameObject Dirt2;
    GameObject Person;
    void Start()
    {

        Dirt2 = GameObject.Find("dirt2");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        s = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += s;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt2.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
