using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreCalculator  
{
    // Start is called before the first frame update
    public static int CalculateScore(int Level, int deaths, int collectables, int time)
    {
        return 100 + Level * 10 - deaths * 20 + collectables * 5;
    }
}
