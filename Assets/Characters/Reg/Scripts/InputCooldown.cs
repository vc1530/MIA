using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class InputCooldown : MonoBehaviour
{
    public float cooldownTime = 0f;
    private bool isCooldown = false;

    public Animator anim;
    /*public float animPlayInterval = 3f;
    private float animCnt = 0f;*/

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)|| Input.GetKey(KeyCode.P) && !isCooldown)
        {
            StartCoroutine(Cooldown());
            print("cooldown working");
            //anim.SetBool("isAttacking", false);
        }
    }
 
    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
 
    
}


