using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegMovement : MonoBehaviour
{

    public Animator anim; 
    public Rigidbody2D character; 
    public GameObject AttackArea; 

    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    public float moveSpeed = 10;
    public float cooldownTime = 0f;
    public bool isCoolingDown = false; 
    
    private bool isGrounded; 

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>(); 
        character = gameObject.GetComponent<Rigidbody2D>(); 
        AttackArea = GameObject.Find("AttackArea"); 
        isGrounded = true; 
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

        if((Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.P)) && !isCoolingDown)
        {
            StartCoroutine(Cooldown());
            print("cooldown working");
            anim.SetBool("isAttacking", true); 
        } 
        if(Input.GetKeyUp(KeyCode.P))
            anim.SetBool("isAttacking", false);
       
    }

    void MoveReg() { 

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        this.transform.Translate(Input.GetAxis("Horizontal")* moveSpeed * Time.deltaTime,0,0);
        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
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

    void OnCollisionEnter2D(Collision2D col) { 
        if (col.gameObject.tag == "Floor") { 
            isGrounded = true; 
        }
    }

    void OnCollisionExit2D(Collision2D col) { 
        if (col.gameObject.tag == "Floor") { 
            isGrounded = false; 
        }
    }

    private IEnumerator Cooldown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCoolingDown = false;
        anim.SetBool("isAttacking",false);
    }

}
