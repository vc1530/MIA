using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegDamage : MonoBehaviour
{
    // Start is called before the first frame update

    public SilkfangHealth silkfangHealth; 
    int damage; 

    void Start()
    {
        damage = 1; 
    }

    private void onTriggerEnter2D(Collision2D col) 
    { 
        Debug.Log("hurt"); 
        silkfangHealth = col.gameObject.GetComponent<SilkfangHealth>(); 
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKey(KeyCode.R)) 
            silkfangHealth.TakeDamage(damage); 
    }
}
