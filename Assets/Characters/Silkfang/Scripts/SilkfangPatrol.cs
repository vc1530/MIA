using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilkfangPatrol : MonoBehaviour
{

    public GameObject pointA; 
    public GameObject pointB; 
    private Rigidbody2D silkfang; 
    private Animator anim; 
    private Transform currentPoint; 
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        silkfang = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>(); 
        pointA = GameObject.Find("PointA"); 
        pointB = GameObject.Find("PointB"); 
        currentPoint = pointB.transform; 
        speed = 2; 
    }

    // Update is called once per frame
    void Update()

    {
        //print("Silkfang's target is B: " + currentPoint == pointB.transform + "DISTANCE: " + Vector2.Distance(transform.position, currentPoint.position) );
        Vector2 point = currentPoint.position - transform.position; 
        
        if (currentPoint == pointB.transform) 
        { 
            // Debug.Log("Bside "+Vector2.Distance(transform.position, currentPoint.position)); 
            silkfang.velocity = new Vector2(speed, 0); 
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else 
        { 
            // Debug.Log("Aside "+Vector2.Distance(transform.position, currentPoint.position)); 
            silkfang.velocity = new Vector2(-speed, 0); 
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 2.5f && currentPoint == pointB.transform) 
        { 
            currentPoint = pointA.transform; 
            silkfang.velocity = new Vector2(-speed, 0); 
            print("Reach the right side");
        }

        else if(Vector2.Distance(transform.position, currentPoint.position) < 4f && currentPoint == pointA.transform) 
        { 
            currentPoint = pointB.transform; 
            silkfang.velocity = new Vector2(speed, 0); 
            print("Reach the left side");
        }
        else{
            print("else");
        }
    }

}
