using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))         //左を向く
        {
            transform.Rotate(new Vector3(0, -2, 0));
        }
        if (Input.GetKey(KeyCode.D))         // 右を向く
        {
            transform.Rotate(new Vector3(0, 2, 0));
        }
    }
}
