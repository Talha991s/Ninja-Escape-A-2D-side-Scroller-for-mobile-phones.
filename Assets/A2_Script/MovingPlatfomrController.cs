/*
 Filename: MovingPlatformController.cs
 Author: Salick Talhah
 Student Number: 101214166
 Date last modified: 15/12/2020
 Description: This file have the fucntionality of the platform.
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

[System.Serializable]
public class MovingPlatfomrController : MonoBehaviour
{
    public Transform pos1, pos2;
    public Transform startpos;
    public float speed;

    private Vector3 nexpos;
    // Start is called before the first frame update
    void Start()
    {
        nexpos = startpos.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(transform.position == pos1.position)
        {
            nexpos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nexpos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nexpos, speed * Time.deltaTime);

        //if(isActive)
        //{
        //    _Move()  //}

    }
    //private void _Move()
    //{
    //    var distanceX = (distance.x > 0) ? start.position.x + Mathf.PingPong(Time.time, distance.x) : start.position.x;
    //    var distanceY = (distance.x > 0) ? start.position.y + Mathf.PingPong(Time.time, distance.y) : start.position.y;


    //    transform.position = new Vector3(distanceX, distanceY , 0.0f);

    //}
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    
}
