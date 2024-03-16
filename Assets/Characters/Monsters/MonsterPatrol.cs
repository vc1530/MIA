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
        monster = this.GetComponent<Rigidbody2D>(); 
        anim = this.GetComponent<Animator>(); 
        currentPoint = pointB.transform; 
        speed = 2; 
        this.GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Silkfang") print(monster.velocity); 
        if (currentPoint == pointB.transform) { 
            monster.velocity = new Vector2(speed, 0); 
            if (this.gameObject.tag == "Silkfang")
            print("point B " + Vector2.Distance(transform.position, currentPoint.position)); 
        }
        else if (currentPoint == pointA.transform) { 
            monster.velocity = new Vector2(-speed, 0); 
            if (this.gameObject.tag == "Silkfang")
            print("point A " + Vector2.Distance(transform.position, currentPoint.position)); 
        }

        if(currentPoint == pointB.transform && Vector2.Distance(transform.position, currentPoint.position) < 4f) 
        { 
            currentPoint = pointA.transform; 
            this.GetComponent<SpriteRenderer>().flipX = false;
            //print("Reach the right side");
        }

       else if(currentPoint == pointA.transform && Vector2.Distance(transform.position, currentPoint.position) < 4f) 
        { 
            currentPoint = pointB.transform; 
            this.GetComponent<SpriteRenderer>().flipX = true;
            //print("Reach the left side");
        }
    }

}
