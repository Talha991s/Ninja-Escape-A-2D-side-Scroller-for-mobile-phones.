using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    public float runForce;
    public Rigidbody2D rigidbody2D;
    public bool isGroundedAhead;
    public Transform lookaheadpoint;
    public LayerMask collisionGroundLayer;
  //  public LayerMask collisionWallLayer;
   // public Transform lookinfront;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //_LookInFront();
        _LookAhead();
        _Move();
    }

    //private void _LookInFront()
    //{
    //     if (Physics2D.Linecast(transform.position, lookinfront.position, collisionWallLayer))
    //    {
    //        _FlipX();
    //    }
    //    Debug.DrawLine(transform.position, lookinfront.position, Color.red);
    //}

    private void _LookAhead()
    {
       // var groundHit 
         isGroundedAhead  = Physics2D.Linecast(transform.position, lookaheadpoint.position, collisionGroundLayer);
        //if (groundHit)
        //{
        //    if (groundHit.collider.CompareTag("Platforms"))
        //    {
        //       // onRamp = false;
        //    }

        //    isGroundedAhead = true;
        //}
        //else
        //{
        //    isGroundedAhead = false;
        //}

        Debug.DrawLine(transform.position, lookaheadpoint.position, Color.green);
    }



    private void _Move()
    {
        if(isGroundedAhead)
        {
            rigidbody2D.AddForce(Vector2.right * runForce * Time.deltaTime * transform.localScale.x);
            rigidbody2D.velocity *= 0.90f;
        }
        else
        {
            _FlipX();
            //transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        }
;
    }

    private void _FlipX()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }
  
}
