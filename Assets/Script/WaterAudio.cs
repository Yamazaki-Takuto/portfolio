using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAudio : MonoBehaviour
{
    GameObject water;
    GameObject Person;
    void Start()
    {
        water = GameObject.Find("WaterLeak");
        Person = GameObject.Find("person");
    }

    // Update is called once per frame
    void Update()
    {
        water.GetComponent<AudioSource>().Play();

        if(Person.GetComponent<Person_Controller>().WaterFrg == 2)
        {
            water.GetComponent<AudioSource>().Stop();
        }
    }
}
