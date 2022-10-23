using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target; 
    public float minimumDistance; 
    public int maxHealth = 100; 
    int currentHealth; 

    public Animator anim; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > minimumDistance){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); 
        } else {
            //ATTACK CODE
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage; 
        anim.SetTrigger("hurt");
        transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime); 
        //Play hurt animation
        if(currentHealth <= 0){
            Die();
        }
    }

    void Die() {
        Debug.Log("Enemy died!"); 
        //Die animation
        anim.SetBool("isDead", true); 
        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;  
    }
}
