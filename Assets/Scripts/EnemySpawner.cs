using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;
  

    // Use this for initialization
    void Start () {
        StartCoroutine("SpawnEnemies");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject senemy = MF_AutoPool.Spawn(enemy, spawnPoint.position, spawnPoint.rotation);
            //Destroy(senemy, 5f);
        }
    }
}
