using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner6 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float g;
    GameObject Dirt6;
    GameObject Person;
    void Start()
    {

        Dirt6 = GameObject.Find("dirt6");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        g = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += g;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt6.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
