using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperCntroller : MonoBehaviour
{

    float i = 0f;
   
    private void Update()
    {
        i += Time.deltaTime;
        if(i > 21f)
        {
            Shoot(new Vector3(0,150,150));
            
        }
    }




    public void Shoot(Vector3 dir)
    {
     
            GetComponent<Rigidbody>().AddForce(dir);
        

    }

}
            
   

