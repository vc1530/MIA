using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steak : MonoBehaviour
{

    public int maxHealth; 
    public int health; 
    public Animator anim; 
    public float animPlayInterval = 3f;
    private float animCnt = 0f;
    public RegHealth regHealth; 

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
        anim = gameObject.GetComponent<Animator>();
    }


    void Update(){
        animCnt += Time.deltaTime;
    }
    // Update is called once per frame
    public void TakeDamage(int damage) 
    {
        Debug.Log("steak burning"); 
        if (anim.GetBool("isDead"))
            anim.Play("dead"); 
        health -= damage; 
        if (health <= 0) 
        { 
            print("steak has died & reg is eating"); 
            regHealth.EatFood(10); 
            anim.SetBool("isDead", true);
            StartCoroutine(Die()); 
        }
    }
    
    private IEnumerator Die(){ 
        yield return new WaitForSeconds(1.5f); 
        Destroy(this.gameObject); 
    } 
   
}
