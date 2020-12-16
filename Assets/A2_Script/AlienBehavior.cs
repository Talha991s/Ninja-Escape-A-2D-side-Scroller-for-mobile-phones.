/*
 Filename: AlienBehaviour.cs
 Author: Salick Talhah
 Student Number: 101214166
 Date last modified: 15/12/2020
 Description: This file have the Enemy control and player effects, including sfx.
 Revision History:
 07/12/2020 
 10/12/2020
 11/12/2020
 13/12/2020
 15/12/2020
*/

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
    public LOS alienlos;
    //  public LayerMask collisionWallLayer;
    // public Transform lookinfront;

    //[Header("Bullet Firing")]
    //public float fireDelay;
    //public Transform BulletSpawn;
    //public GameObject player;
    //public PlayerBehaviour player;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
       // player = GameObject.FindObjectOfType<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_hasLOS())
        {
           //_FireBullet();
            Debug.Log("SEE PLAYER");
        }


        //_LookInFront();
        _LookAhead();
        _Move();
    }

    //private void _FireBullet()
    //{
    //    if (Time.frameCount % fireDelay == 0 && BulletManager.Instance().HasBullets())
    //    {
    //        Debug.Log("mmmmmmmmmmmm");

    //        var playerPosition = player.transform.position;

    //        var firingDirection = Vector3.Normalize(playerPosition - BulletSpawn.position);

    //        BulletManager.Instance().GetBullet(BulletSpawn.position, firingDirection);
    //    }
    //}

    private bool _hasLOS()
    {
        if (alienlos.collidep.Count > 0)
        {
            if (alienlos.Collidewithp.gameObject.CompareTag("Player") && alienlos.collidep[0].gameObject.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
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
