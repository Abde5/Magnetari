using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTheGame : MonoBehaviour {

    public GameObject[] bailes;
    public GameObject[] canvas;

    public static string[] players = new string[]
             { "Player 1" ,
             "Player 2" ,
             "Player 3" ,
             "Player 4" ,
             "Player 5" ,
             "Player 6" };

    void Start () {
        int i = 0;

        int[] scores = new int[6] { 0, 0, 0, 0, 0, 0 };
        foreach (string player in players)
        {
            scores[i] = BallControl.scoreArray[player];
            i++;
        }


        int max = 0;
        int chosenMax = 0;

        int j = 0;
        foreach (int score in scores)
        {
            if (score > max)
            {
                max = score;
                chosenMax = j; 
            }
            j++;
        }

        for (int l = 0; l < 6; ++l)
        {
            if (l == chosenMax)
            {
                Debug.Log("ganador");
                GetComponent<Renderer>().enabled = false;
                bailes[chosenMax].SetActive(true);
                canvas[chosenMax].SetActive(true);
            } else
            {
                Debug.Log("perdedor");
                bailes[chosenMax].SetActive(false);
                canvas[chosenMax].SetActive(false);
            }

        }
        
    }

}
