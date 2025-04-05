using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner9 : MonoBehaviour
{
    float startTime;
    public float destroy = 1f;
    float destroyFlg = 0f;
    float k;
    GameObject Dirt9;
    GameObject Person;
    void Start()
    {

        Dirt9 = GameObject.Find("dirt9");
        Person = GameObject.Find("person");
    }

    private void Update()
    {
        k = Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Yogore1"))
        {
            startTime += k;


            if (startTime > destroy && destroyFlg == 0)
            {
                Dirt9.SetActive(false);
                Person.GetComponent<Person_Controller>().YogoreCnt--;
                destroyFlg = 1;
            }
        }
    }
}
