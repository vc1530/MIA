using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegHealth : MonoBehaviour
{

    public int maxHealth = 500; 
    public int health; 
    public Animator anim;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
        anim = gameObject.GetComponent<Animator>(); 
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    public void TakeDamage(int damage) 
    { 
        anim.Play("Hurt"); 
        anim.SetBool("isHurt", true); 
        health -= damage; 
        healthBar.SetHealth(health);
        if (health <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    public void EatFood(int food)
    {
        print("im eating him");
        if (health <= maxHealth) health += food;
        healthBar.SetHealth(health); 
    }
}

