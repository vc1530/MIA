using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPatrol : MonoBehaviour
{

    public GameObject pointA; 
    public GameObject pointB; 
    private Rigidbody2D monster; 
    private Animator anim; 
    private Transform currentPoint; 
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>(); 
        currentPoint = pointB.transform; 
        speed = 2; 
        GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoint == pointB.transform) { 
            monster.velocity = new Vector2(speed, 0); 
        }
        else if (currentPoint == pointA.transform) { 
            monster.velocity = new Vector2(-speed, 0); 
        }

        if(currentPoint == pointB.transform && Vector2.Distance(transform.position, currentPoint.position) < 3.5f) 
        { 
            currentPoint = pointA.transform; 
            GetComponent<SpriteRenderer>().flipX = false;
            print("Reach the right side");
        }

       else if(currentPoint == pointA.transform && Vector2.Distance(transform.position, currentPoint.position) < 3.5f) 
        { 
            currentPoint = pointB.transform; 
            GetComponent<SpriteRenderer>().flipX = true;
            print("Reach the left side");
        }
    }

}
