using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInFall : MonoBehaviour {


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

	public AudioSource fallSound;

	public void Start() {
		players = new Dictionary<string, GameObject>();
		for(int i = 0; i < playerPrefabs.Length; ++i) {
			players.Add("Player " + ( i + 1 ).ToString(), playerPrefabs[i]);
		}


		spawnPoints = new Dictionary<string, GameObject>();
		for (int i = 0; i < playerPrefabs.Length; ++i) {
			spawnPoints.Add("Player " + (i + 1).ToString(), spawnPrefabs[i]);
		}
	}

	private void Update() {
    }

	void OnTriggerEnter(Collider other) {
		if(Array.Exists(tags, x => x == other.transform.root.tag)) {

			if (other.gameObject.layer == LayerMask.NameToLayer("absorcion"))
				return;

			string tag = other.transform.root.tag;
			//fallSound.Play();
			Debug.Log("fallen " + tag);
			GameObject test = players[tag];
			Debug.Log(players.Count);
			GameObject test2 = spawnPoints[tag];

			// respawn this player after some moments
			GameObject fallen = Instantiate(players[tag], spawnPoints[tag].transform.position, new Quaternion(0, 0, 0, 0));
			fallen.transform.localScale = other.transform.root.localScale;
			Destroy(other.transform.root.gameObject);

		} else {
			Destroy(other.gameObject.transform.root.gameObject);
		}
	} 
}
