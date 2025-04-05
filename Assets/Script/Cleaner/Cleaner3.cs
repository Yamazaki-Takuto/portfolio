using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner3 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float d;
    GameObject Dirt3;
    GameObject Person;
    void Start()
    {

        Dirt3 = GameObject.Find("dirt3");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        d = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += d;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt3.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
