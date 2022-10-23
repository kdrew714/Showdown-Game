using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform target; 
    public float minimumDistance; 
    public int maxHealth = 100; 
    int currentHealth; 

    public Transform attackPoint; 
    public float attackRange = 0.5f; 
    public LayerMask playerLayers; 
    public int attackDamage = 10; 

    public float attackRate = 1.5f; 
    float nextAttackTime = 0f; 

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
            if(Time.time >= nextAttackTime){
                anim.SetTrigger("attack"); 
                nextAttackTime = Time.time + 1f / attackRate; 

            }
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
        
        
        SceneManager.LoadScene(2);
        
        this.enabled = false;  
    }


}