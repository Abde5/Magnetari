using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] item;
    public Transform[] itemPos;
    public float spawnTime;

    private void Start()
    {
        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3);
        InvokeRepeating("SpawnItem", 0, spawnTime);
    }

    public void SpawnItem()
    {
        Instantiate(item[Random.Range(0, item.Length)], itemPos[Random.Range(0, itemPos.Length)].position, new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 0.99f)));
    }

}