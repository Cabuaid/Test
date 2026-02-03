using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveIA : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnLocation;
    public Transform spawnLocation2;
    public int WaveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateEnemies();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnTimer <=0)
        {
            //spawn a enemy
            if(enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);// apawn first enemy in our list
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;// if no enemies remain,end wave
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    if(waveTimer <= 0)
        {
            GenerateWave();
        }
    }
    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = WaveDuration / enemiesToSpawn.Count;//give a fixed time between each enemies
        waveTimer = WaveDuration;// wave duration is read only
    }
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyId >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }

        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }


}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;

}