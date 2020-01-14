using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static private int scoreInt = 0;
    static public int ScoreInt
    {
        get
        {
            return scoreInt;
        }
        set 
        {
            scoreInt = value;
        }
    }
    
}
