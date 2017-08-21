using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Definición de zona")]
    public Vector2 punto1;
    public Vector2 punto2;

    public GameObject[] items;

    [TooltipAttribute("Probabilidad de que salga objeto")]
    public float probabilidad = 0.3f;

    // Update is called once per frame
    void Update() {
        if (Random.value < probabilidad) {
            spawnRandom();
        }
    }

    void spawnRandom() {
      int size = items.Length;
      int chosen = (int)Mathf.Round(Random.value * (size-1));

			Vector3 randomPos = new Vector3(0,1,0);
      randomPos.x = Random.value * (punto2.x - punto1.x) + punto1.x;
      randomPos.z = Random.value * (punto2.y - punto1.y) + punto1.y;
      Instantiate(items[chosen],randomPos,new Quaternion(0,0,0,0));
		}

}
