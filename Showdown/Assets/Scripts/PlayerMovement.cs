using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    //Variable to adjust speed of player
    //SerializeField - makes it adjustable from inside Unity
    [SerializeField] private float speed; 
    //Reference to the player's rigidbody - 2d physics of player
    private Rigidbody2D body; 
    private bool grounded; 
    private Animator anim; 

    //Called every time the script is being loaded
    private void Awake()
    {
        //checks player for rigidbody and animator component from object
        body = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>(); 
        grounded = true; 

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 

        //assigns velocity - speed in 2 directions
        //1st coordinate - left-right
        //2nd coordinate - no changing velocity in y 
        //multiplying input from x-axis by speed to make player go faster
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //flips player based on direction of movement
        //hor.input > 0.01f player moving right - making scale one
        //hor.input < -0.01f player moving left - making scale -1
        /*if(horizontalInput > 0.01f){
            //transform.localScale = Vector3.one; 
            transform.Rotate(0, 180, 0); 
        } else if (horizontalInput < -0.01f){
            //transform.localScale = new Vector3(-1, 1, 1); 
                //IMPORTANT: USE THE SCRIPT HERE IF BULLET IS NOT FLIPPING
            transform.Rotate(0, 180, 0); 
        }*/

        //adding jumping movement
        //checking for space key button pressed
        if(Input.GetKey(KeyCode.UpArrow) && grounded){
            //similar code to left-right, but in y direction
            //can use a diff number for speed to tweak jump
            Jump(); 
        }

        Flip(); 
        anim.SetBool("run", horizontalInput != 0);

        anim.SetBool("grounded", grounded); 
    }
    
    private void Flip(){
        if(Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame){
            transform.Rotate(0,180,0); 
        }
    }
    private void Jump(){
        //similar code to left-right, but in y direction
        //can use a diff number for speed to tweak jump
        body.velocity = new Vector2(body.velocity.x, 7);
        anim.SetTrigger("jump"); 
        grounded = false; 
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground"){
            grounded = true; 
        }

        
    }
}
