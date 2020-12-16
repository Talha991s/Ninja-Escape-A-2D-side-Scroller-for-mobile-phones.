/*
 Filename: ScoreManager.cs
 Author: Salick Talhah
 Student Number: 101214166
 Date last modified: 15/12/2020
 Description: This file add ups the score.
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
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if( instance == null)
        {
            instance = this;
        }
    }

    public void changeScore(int coinValue)
    {
        score += coinValue;
        text.text = "x " + score.ToString();
    }
}
