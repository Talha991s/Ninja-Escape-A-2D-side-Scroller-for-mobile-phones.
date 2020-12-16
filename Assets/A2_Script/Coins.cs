/*
 Filename: Coin.cs
 Author: Salick Talhah
 Student Number: 101214166
 Date last modified: 15/12/2020
 Description: This file have the functionality of the coins
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

public class Coins : MonoBehaviour
{
    public int coinValue =1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.changeScore(coinValue);
        }
    }
}
