using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner4 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float f;
    GameObject Dirt4;
    GameObject Person;
    void Start()
    {

        Dirt4 = GameObject.Find("dirt4");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        f = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += f;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt4.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
