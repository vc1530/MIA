using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    public int damage; 
    public RegHealth regHealth; 
    // Start is called before the first frame update

    void Start () 
    { 
        damage = 1; 
    }

    private void OnCollisionStay2D(Collision2D collision) 
    { 
        if (collision.gameObject.tag == "Reg") 
        { 
            regHealth = collision.gameObject.GetComponent<RegHealth>();
            Debug.Log("collided"); 
            regHealth.TakeDamage(damage); 
        }
    }
}
