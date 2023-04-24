using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Tooltip("Movement vector in meters per second")]
    [SerializeField]
    Vector3 velocity;



    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

   
}
