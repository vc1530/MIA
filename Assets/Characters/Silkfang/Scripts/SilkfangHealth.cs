using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilkfangHealth : MonoBehaviour
{

    public int maxHealth = 200; 
    public int health; 
    public Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
        anim = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    public void TakeDamage(int damage) 
    {
        Debug.Log("taking damage"); 
        anim.Play("Hurt"); 
        //anim.SetBool("isHurt", true); 
        health -= damage; 
        if (health <= 0) 
        { 
            anim.Play("Die"); 
            Destroy(gameObject); 
        }
    }
}
