using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    public GameObject tile;

    public float minTime;
    public float maxTime;

    private float time;
    private float spawnTime;

	// Use this for initialization
	void Start () {
        Rest();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            Instantiate(tile, new Vector3(Random.Range(-9, 9), 6), Quaternion.identity);
            Rest();
        }
	}

    private void Rest()
    {
        time = 0;
        spawnTime = Random.Range(minTime, maxTime);
    }
}
