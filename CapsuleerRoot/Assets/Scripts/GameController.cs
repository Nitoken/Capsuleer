using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player; //Player
    public bool isAlive; //Is player alive
    public bool setupDone = false;
    public int wave = 0, subWave = 0, maxSubWave; //Wave info
    public bool waving = false; //is in Wave mode?
    public float timer; //Time between waves

    public GameObject[] enemiesList; //list of available enemies
    public List<GameObject> enemiesOnScene; // Enemies alive
    public Transform[] enemiesSpawn; //places of enemies spawn

    public float maxDistance; //How far can we go
    public Text distanceTXT; //UI warning
    public Transform playerSpawn; //Player's spawn

    public GameObject selectPanel, skillPanel, endPanel, finishPanel; //UI panels
    float deadTimer = 3; //Just for effect

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    } 
    //called from button in Wave panel
    public void StartNewWave()
    {
        wave++;
        subWave = 0;
        waving = true;
    }
    void Update()
    {
        if (isAlive)
        {
            //How far player went?
            float dist = Vector3.Distance(player.transform.position, playerSpawn.position);
            if (dist > maxDistance * 0.7f)
                distanceTXT.color = new Color(1, 0, 0, dist / maxDistance);

            //If too far kill him slowly
            if (dist > maxDistance)
            {
                player.GetComponent<Health>().TakeDamage(Time.deltaTime * 100);
            }

            //UI end game?
            if (Input.GetKeyDown(KeyCode.Escape))
                endPanel.SetActive(!endPanel.activeSelf);

            //UI Skill section
            if (!waving)
                if (Input.GetKeyDown(KeyCode.C))
                    skillPanel.SetActive(skillPanel.activeSelf);
        }
        //Show 
        else
        {
            deadTimer -= Time.deltaTime; //Wait a bit. Just for effect

            //Show end panel
            if (!finishPanel.activeSelf && deadTimer <= 0)
                finishPanel.SetActive(true);
        }

        if(waving)
        {
            timer -= Time.deltaTime; //To next wave
            
            //If all enemies dead OR timer is zero start new wave
            if (enemiesOnScene.Count <= 0 || timer <= 0)
            {
                if (subWave < maxSubWave)
                    StartCoroutine(SpawnEnemy());

                //End of wave JUST when all enemies are dead
                else if(enemiesOnScene.Count <= 0)
                    waving = false;
            }
        }
    }
    //Spawns enemies
    IEnumerator SpawnEnemy()
    {
        subWave++;
        timer = 30 + wave * 5f + subWave * 3f; //Some poor math.
        int toSpawn = wave + subWave; //How much enemies to spawn

        while (toSpawn > 0)
        {
            GameObject x = Instantiate(enemiesList[Random.Range(0, enemiesList.Length)], enemiesSpawn[Random.Range(0, enemiesSpawn.Length)].position, Quaternion.identity);
            enemiesOnScene.Add(x); //Add enemy to enemies on scane. 
            yield return new WaitForSeconds(1f); //Wait 1s for next spawn
            toSpawn--; 
        }
    }
}
