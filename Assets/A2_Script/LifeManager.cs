/*
 Filename: LifeManager.cs
 Author: Salick Talhah
 Student Number: 101214166
 Date last modified: 15/12/2020
 Description: This file counts the life of the player. 
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
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public GameObject life1, life2, life3;
    public static int health;


    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 3 )
        {
            health = 3;
        }
        else if(health <= 0)
        {
            SceneManager.LoadScene(2);
        }

        switch (health)
        {
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                break;
            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                break;
            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                break;
            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                SceneManager.LoadScene(2);
                break;
        }
    }
}
