using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GUISkin scoreSkin;

    int PlayerScore = 0;
    int EnemyScore = 0;

    public void IncreaseScore (int playerType)
    {
        if (playerType == 1)
        {
            PlayerScore++;
        }
        else if (playerType == 2)
        {
            EnemyScore++;
        }
        else
        {
            print("Increasing score of random object");
        }
    }

    void OnGUI()
    {
        if(GUI.skin != scoreSkin)
        {
            GUI.skin = scoreSkin;
        }

        GUI.Label(new Rect(645, 10, 300, 30), "Player Score " + PlayerScore.ToString());
        GUI.Label(new Rect(20, 10, 300, 30), "Enemy Score " + EnemyScore.ToString());
    }

}
