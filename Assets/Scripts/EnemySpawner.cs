using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    public List<Transform> spawns = new List<Transform>();
    public int TimeBeforeSpawnIncrease;
    public int InitialTimeBetweenSpawns;

    private float timeOfLastSpawn = 0;
    private float timeBetweenSpawns;

	void Start () {
        timeBetweenSpawns = InitialTimeBetweenSpawns;
	}
	
	void Update () {
        if (Time.timeSinceLevelLoad > timeOfLastSpawn + timeBetweenSpawns) {
            timeOfLastSpawn = Time.timeSinceLevelLoad;
            Transform spawn = spawns[(int)(Random.value * spawns.Count)];
            GameObject enemy = ObjectPooler.Instance.GetPooledObject(ObjectPooler.ObjectTypes.Enemy);
            enemy.transform.position = spawn.position;
            enemy.SetActive(true);
            updateTimeBetweenSpawns();
        }
	}

    private void updateTimeBetweenSpawns() {
        timeBetweenSpawns = InitialTimeBetweenSpawns - Mathf.Min(InitialTimeBetweenSpawns - 1, (int)(Time.timeSinceLevelLoad / TimeBeforeSpawnIncrease));
    }
}
