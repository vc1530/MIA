using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseSweeperPatrol : MonoBehaviour
{

    public GameObject pointC; 
    public GameObject pointD; 
    private Rigidbody2D corpseSweeper; 
    private Animator anim; 
    private Transform currentPoint; 
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        corpseSweeper = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>(); 
        pointC = GameObject.Find("PointC"); 
        pointD = GameObject.Find("PointD"); 
        currentPoint = pointD.transform; 
        speed = 2; 
    }

    // Update is called once per frame
    void Update()

    {
        Vector2 point = currentPoint.position - transform.position; 
        
        if (currentPoint == pointD.transform) 
        { 
            //Debug.Log(Vector2.Distance(transform.position, currentPoint.position)); 
            corpseSweeper.velocity = new Vector2(speed, 0); 
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else 
        { 
            //Debug.Log(Vector2.Distance(transform.position, currentPoint.position)); 
            corpseSweeper.velocity = new Vector2(-speed, 0); 
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointD.transform) 
        { 
            currentPoint = pointC.transform; 
            corpseSweeper.velocity = new Vector2(-speed, 0); 
        }

        else if(Vector2.Distance(transform.position, currentPoint.position) < 2f && currentPoint == pointC.transform) 
        { 
            currentPoint = pointD.transform; 
            corpseSweeper.velocity = new Vector2(speed, 0); 
        }
    }

}
