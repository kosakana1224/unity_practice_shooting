using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> enemyList;
    private float timeMin = 0.1f, timeMax = 0.3f;
    public int maxEnemies = 3;
    public float startDelay = 1;
    public int waveCount = 5;
    public int currentWave = 0;
    public BoxCollider2D boxCollider;
    List<GameObject> currentEnemies = new List<GameObject>();
    void Start()
    {
        StartCoroutine(SpawnWaveWithDelay(startDelay));
    }
    private IEnumerator SpawnWaveWithDelay(float startDelay)
    {
        currentWave++;
        yield return new WaitForSeconds(startDelay);
        float minX = boxCollider.bounds.min.x;
        float maxX = boxCollider.bounds.max.x;

        for (int i = 0; i < maxEnemies; i++)
        {
            Vector3 spawnPoint = new Vector3(UnityEngine.Random.Range(minX, maxX), transform.position.y, 0);
            GameObject newEnemy = Instantiate(enemyList[UnityEngine.Random.Range(0, enemyList.Count)].gameObject, spawnPoint, Quaternion.Euler(0, 0, -90));
            currentEnemies.Add(newEnemy);
            newEnemy.GetComponent<Enemy>().enemySpawner = this;
            yield return new WaitForSeconds(UnityEngine.Random.Range(timeMin, timeMax));
        }

    }
    public void EnemyKilled(Enemy enemy, bool playerKill)
    {
        if (currentEnemies.Remove(enemy.gameObject))
        {
            if (playerKill)
            {
                //score
            }
            if (currentEnemies.Count == 0)
            {
                if (currentWave == waveCount)
                {
                    Debug.Log("You win");
                    return;
                }
                StartCoroutine(SpawnWaveWithDelay(0.5f));
            }
        }

    }
}
