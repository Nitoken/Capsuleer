using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public bool isAlive;

    public int wave, subWave, maxSubWave;
    public bool waving;
    public float timer;

    public GameObject[] enemiesList;
    public List<GameObject> enemiesOnScene;
    public Transform[] enemiesSpawn;

    public GameObject selectPanel, skillPanel, endPanel, finishPanel;

    void Awake()
    {
        wave = 0;
    }
    public void StartNewWave()
    {
        wave++;
        subWave = 0;
        waving = true;
    }
    void Update()
    {
        if(waving)
        {
            timer -= Time.deltaTime;

            if (enemiesOnScene.Count <= 0 || timer <= 0)
            {
                if (subWave < maxSubWave)
                    StartCoroutine(SpawnEnemy());
                else
                    waving = false;
            }
        }
    }
    IEnumerator SpawnEnemy()
    {
        subWave++;
        timer = 30 + wave * 5f + subWave * 3f;
        int toSpawn = wave + subWave;
        while (toSpawn > 0)
        {

            GameObject x = Instantiate(enemiesList[Random.Range(0, enemiesList.Length)], enemiesSpawn[Random.Range(0, enemiesSpawn.Length)].position, Quaternion.identity);
            enemiesOnScene.Add(x);
            yield return new WaitForSeconds(1f);
            toSpawn--;
        }
    }
}
