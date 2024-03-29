using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{

    public int maxHealth; 
    public int health; 
    public Animator anim; 
    public float animPlayInterval = 3f;
    private float animCnt = 0f;

    public MonsterHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
        anim = gameObject.GetComponent<Animator>(); 
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update(){
        animCnt += Time.deltaTime;
    }
    // Update is called once per frame
    public void TakeDamage(int damage) 
    {
        Debug.Log("taking damage"); 
        if (!anim.GetBool("isDead"))
            anim.Play("Hurt"); 
        if(animCnt > animPlayInterval)
        {
            anim.SetBool("isHurt", true);
            StartCoroutine(Hurt());
            animCnt = 0;
        }
        health -= damage; 
        healthBar.SetHealth(health);
        if (health <= 0) 
        { 
            print("monster has died"); 
            anim.SetBool("isHurt", false); 
            anim.SetBool("isDead", true); 
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); 
            StartCoroutine(Die()); 
        }
    }
    private IEnumerator Hurt(){
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isHurt",false);
    }
    private IEnumerator Die(){ 
        yield return new WaitForSeconds(1.5f); 
        Destroy(this.gameObject); 
    }
}
