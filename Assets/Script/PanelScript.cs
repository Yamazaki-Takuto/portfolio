using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public GameObject PanelUIObj;
    GameObject gameObj;
    int a, b = 0;
    void Start()
    {
        gameObj = GameObject.Find("GameObject(1)");
    }

    // Update is called once per frame
    void Update()
    {
        a = gameObj.GetComponent<Button>().ElizaFlg;
        b = gameObj.GetComponent<Button>().FatherFlg;
        PanelUIObj.SetActive(false);
    }
}
