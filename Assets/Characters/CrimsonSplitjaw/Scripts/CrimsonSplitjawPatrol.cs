using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimsonSplitjawPatrol : MonoBehaviour
{

    public GameObject pointE; 
    public GameObject pointF; 
    private Rigidbody2D crimsonSplitjaw; 
    private Animator anim; 
    private Transform currentPoint; 
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        crimsonSplitjaw = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>(); 
        pointE = GameObject.Find("PointE"); 
        pointF = GameObject.Find("PointF"); 
        currentPoint = pointF.transform; 
        speed = 2; 
    }

    // Update is called once per frame
    void Update()

    {
        anim.Play("Idle"); 
        Vector2 point = currentPoint.position - transform.position; 
        
        if (currentPoint == pointF.transform) 
        { 
            Debug.Log(Vector2.Distance(transform.position, currentPoint.position)); 
            crimsonSplitjaw.velocity = new Vector2(speed, 0); 
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else 
        { 
            Debug.Log(Vector2.Distance(transform.position, currentPoint.position)); 
            crimsonSplitjaw.velocity = new Vector2(-speed, 0); 
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 4f && currentPoint == pointE.transform) 
        { 
            currentPoint = pointF.transform; 
            crimsonSplitjaw.velocity = new Vector2(-speed, 0); 
        }

        else if(Vector2.Distance(transform.position, currentPoint.position) < 4f && currentPoint == pointF.transform) 
        { 
            currentPoint = pointE.transform; 
            crimsonSplitjaw.velocity = new Vector2(speed, 0); 
        }
    }

}
