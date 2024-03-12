using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegMovement : MonoBehaviour
{

    public Animator anim; 
    public Rigidbody2D character; 
    public GameObject AttackArea; 

    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    public float moveSpeed = 10; 

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
        JumpReg(); 
        //MoveReg(); 
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
        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, 0, 0);
        tempVect = tempVect.normalized * moveSpeed * Time.deltaTime;
        character.MovePosition(character.transform.position + tempVect);
    }

    void JumpReg() { 

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Vector3 tempVect = new Vector3(h, v, 0);
        // tempVect = tempVect.normalized * moveSpeed * Time.deltaTime;
        // character.MovePosition(character.transform.position + tempVect);

        this.transform.Translate(Input.GetAxis("Horizontal")* moveSpeed * Time.deltaTime,0,0);
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("jumping"); 
            //float jumpForce = Mathf.Sqrt(5 * -2 * (Physics2D.gravity.y * character.gravityScale));
            character.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if(character.velocity.y >= 0)
        {
            character.gravityScale = gravityScale;
        }
        else if (character.velocity.y < 0)
        {
            character.gravityScale = fallingGravityScale;
        }
    }
}
