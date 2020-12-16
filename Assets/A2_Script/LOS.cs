/*
 Filename: LOS.cs
 Author: Salick Talhah
 Student Number: 101214166
 Date last modified: 15/12/2020
 Description: This file have the Enemy Patrolling.
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
public class LOS : MonoBehaviour
{
    public Collider2D Collidewithp;
    public ContactFilter2D Contactfilterp;
    public List<Collider2D> collidep;

    private BoxCollider2D LosColliderp;


    // Start is called before the first frame update
    void Start()
    {
        LosColliderp = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics2D.GetContacts(LosColliderp, Contactfilterp, collidep);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collidewithp = other;
    }
}
