using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyColider : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "water")
        {//load sence 

            Debug.Log("lose");
        }
    }
   

    
}
