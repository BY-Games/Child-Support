using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class ForceAdder : MonoBehaviour
{
    [SerializeField] float forceSize = 10f;
    [SerializeField] ForceMode2D forceMode = ForceMode2D.Force;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.AddForce(new Vector2( 0,forceSize),forceMode);
    }
}
