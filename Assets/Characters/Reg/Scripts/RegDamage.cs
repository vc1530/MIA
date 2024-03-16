using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegDamage : MonoBehaviour
{
    // Start is called before the first frame update

    public MonsterHealth monsterHealth;
    public Steak steak;
    public HealthBar regHealthbar;
    public RegHealth regHealth;
    int damage;
    int currentHealth;
    /*public float abilityCooldown = 5f;
    private float lastAbilityTime;*/
    

    void Start()
    {
        damage = 1;
        currentHealth += 10;
        /*
        lastAbilityTime = -abilityCooldown;
        */

    }

    void Update()
    {
        /*if (Time.time - lastAbilityTime >= abilityCooldown)
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.P))
            {
                lastAbilityTime = Time.time;
                Debug.Log("Working!!!");
            }*/
            /*else if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.P))
            {
                Debug.Log("Disabled!!!!!");
            }*/
        }
        
    

    public void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Monster") { 
            Debug.Log("collided into Monster"); 
            monsterHealth = col.gameObject.GetComponent<MonsterHealth>();
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.P))
            
                monsterHealth.TakeDamage(damage);
                /*
                lastAbilityTime = Time.time;
                */
        }

        if (col.gameObject.tag == "Food")
        {
            Debug.Log("food eaten");
            steak = col.gameObject.GetComponent<Steak>();
            if(Input.GetKeyDown(KeyCode.P)||Input.GetKey(KeyCode.P))
                steak.TakeDamage(damage);

        }

        /*if (steak.health==0)
        {
            regHealth = GameObject.FindWithTag("Reg").GetComponent<RegHealth>();
            print(regHealth); 
            print("steak died");
            regHealth.EatFood(10); 
            
        }*/
    }
    
    
    
    
}
