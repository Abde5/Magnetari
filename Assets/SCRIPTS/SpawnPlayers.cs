using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {

    private Dictionary<string, GameObject> players;
    private Dictionary<string, GameObject> spawnPoints;

    public GameObject[] playerPrefabs;
    public GameObject[] spawnPrefabs;

    static string[] tags = new string[] { "Player 1",
                                          "Player 2",
                                          "Player 3",
                                          "Player 4",
                                          "Player 5",
                                          "Player 6" };


    // Use this for initialization
    void Start () {

        players = new Dictionary<string, GameObject>();
        for (int i = 0; i < playerPrefabs.Length; ++i)
        {
            players.Add("Player " + (i + 1).ToString(), playerPrefabs[i]);
        }


        spawnPoints = new Dictionary<string, GameObject>();
        for (int i = 0; i < playerPrefabs.Length; ++i)
        {
            spawnPoints.Add("Player " + (i + 1).ToString(), spawnPrefabs[i]);
        }


        for (int i = 0; i < PlayerManager.chosenNumber; ++i)
        {
            Instantiate(players[tags[i]], spawnPoints[tags[i]].transform.position, new Quaternion(0, 0, 0, 0));
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
