using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public float spawnRate = 1f;
    public float spawnRangeX = 8f;

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnFallingObject();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnFallingObject()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0);
        Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the current scene
    }
}
