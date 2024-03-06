using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegMovement : MonoBehaviour
{

    public Animator anim; 
    public Rigidbody2D character; 
    public GameObject AttackArea; 

    float moveSpeed = 10; 
    float horizontal; 

    // Start is called before the first frame update
    void Start()
    {
        //damage = 1; 
        anim = gameObject.GetComponent<Animator>(); 
        character = gameObject.GetComponent<Rigidbody2D>(); 
        AttackArea = GameObject.Find("AttackArea"); 
    }

    // Update is called once per frame
    void Update()
    {
        MoveReg(); 
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))  
        { 
            GetComponent<SpriteRenderer>().flipX = true;
            AttackArea.GetComponent<CircleCollider2D>().offset = new Vector2(-1.6f, 0); 
            anim.SetBool("isWalking", true); 
            anim.SetBool("isHurt", false); 
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            AttackArea.GetComponent<CircleCollider2D>().offset = new Vector2(0, 0); 
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

    void MoveReg() { 
        horizontal = Input.GetAxis("Horizontal"); 
        character.velocity = new Vector2(horizontal * moveSpeed, 0); 
    }
}
