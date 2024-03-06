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
        Debug.Log("taking damage"); 
        anim.Play("Hurt"); 
       if(animCnt > animPlayInterval)
        {
            anim.SetBool("isHurt", true);
            StartCoroutine(Hurt());
            animCnt = 0;
        }
        //anim.SetBool("isHurt", true); 
        health -= damage; 
        //anim.SetBool("isHurt", false); 
        
        if (health <= 0) 
        { 
            print("monster has died"); 
            anim.Play("Die"); 
            Destroy(gameObject); 
        }
    }
    private IEnumerator Hurt(){
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isHurt",false);
    }
}
