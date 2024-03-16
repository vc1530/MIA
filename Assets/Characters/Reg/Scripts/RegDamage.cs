using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegDamage : MonoBehaviour
{
    // Start is called before the first frame update

    
    public MonsterHealth monsterHealth; 
    int damage; 

    
    void Start()
    {
        damage = 1; 
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Monster") { 
            Debug.Log("collided into Monster"); 
            monsterHealth = col.gameObject.GetComponent<MonsterHealth>(); 
            if(Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.P)) 
                monsterHealth.TakeDamage(damage); 
        }
        
        
        
    }
}
