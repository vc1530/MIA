using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegMovement : MonoBehaviour
{

    public Animator anim; 
    public Rigidbody2D character; 
    public SilkfangHealth silkfangHealth; 
    public CorpseSweeperHealth corpseSweeperHealth; 
    public CrimsonSplitjawHealth crimsonSplitjawHealth; 

    float moveSpeed = 10; 
    float horizontal; 
    int damage; 

    // Start is called before the first frame update
    void Start()
    {
        damage = 1; 
        anim = gameObject.GetComponent<Animator>(); 
        character = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        MoveReg(); 
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))  
        { 
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("isWalking", true); 
            anim.SetBool("isHurt", false); 
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("isWalking", true);
            anim.SetBool("isHurt", false); 
        } 
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            anim.SetBool("isWalking", false);

        if(Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.P)) 
        { 
            anim.SetBool("isAttacking", true); 
        } 
        if(Input.GetKeyUp(KeyCode.P))
            anim.SetBool("isAttacking", false);
       
    }

    private void OnCollisionStay2D(Collision2D col) 
    { 
        if (col.gameObject.tag == "Silkfang") { 
            Debug.Log(col.gameObject.GetComponent<SilkfangHealth>()); 
            silkfangHealth = col.gameObject.GetComponent<SilkfangHealth>(); 
            if(Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.P)) 
                silkfangHealth.TakeDamage(damage); 
        }
        if (col.gameObject.tag == "CorpseSweeper") { 
            Debug.Log(col.gameObject); 
            Debug.Log(col.gameObject.GetComponent<CorpseSweeperHealth>()); 
            corpseSweeperHealth = col.gameObject.GetComponent<CorpseSweeperHealth>(); 
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.P)) 
                corpseSweeperHealth.TakeDamage(damage); 
        }
        if (col.gameObject.tag == "CrimsonSplitjaw") { 
            Debug.Log(col.gameObject); 
            Debug.Log(col.gameObject.GetComponent<CrimsonSplitjawHealth>()); 
            crimsonSplitjawHealth = col.gameObject.GetComponent<CrimsonSplitjawHealth>(); 
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.P)) 
                crimsonSplitjawHealth.TakeDamage(damage); 
        }
    }

    void MoveReg() { 
        horizontal = Input.GetAxis("Horizontal"); 
        character.velocity = new Vector2(horizontal * moveSpeed, 0); 
    }
}
