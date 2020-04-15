using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnDelay = 2.5f;

    public Transform[] spawnPnts;
    public GameObject[] prefabsToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnEnemies()
    {
        Debug.Log("start spawning");
        while (GameManager.instance.gameIsOn)
        {
            yield return new WaitForSeconds(spawnDelay);
            int index = Random.Range(0, spawnPnts.Length);
            Transform selectedPoint = spawnPnts[index];
            GameObject newEnemy = Instantiate(prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)]);
            newEnemy.transform.position = selectedPoint.position;
        }
    }
}
