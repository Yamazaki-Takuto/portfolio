using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner12 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float i;
    GameObject Dirt12;
    GameObject Person;
    void Start()
    {
        Dirt12 = GameObject.Find("dirt12");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        i = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += i;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt12.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
