using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner5 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float h;
    GameObject Dirt5;
    GameObject Person;
    void Start()
    {

        Dirt5 = GameObject.Find("dirt5");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        h = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += h;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt5.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
