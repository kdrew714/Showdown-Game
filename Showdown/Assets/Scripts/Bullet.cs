using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        //transform.right - right axis in scene, will change when player is rotated
        rb.velocity = transform.right * speed; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
