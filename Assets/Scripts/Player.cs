using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //Player Class will be used for highPlayer and newPlayer. Static private variables since one object of each.
    
    private string name = "blank";
    private int score = 0;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
}
