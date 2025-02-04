using UnityEngine;
using System.Collections.Generic;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign in Inspector
    public Transform player;
    public float spawnRate = 1.5f;
    private float nextSpawnTime = 0f;

    private List<GameObject> bullets = new List<GameObject>();

    void Update()
    {
        // 🔹 Check if bulletPrefab was accidentally set to null
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet Prefab is missing! Ensure it is assigned in the Inspector.");
            return;
        }

        // 🔹 Remove destroyed bullets from the list
        bullets.RemoveAll(item => item == null);

        // 🔹 Ensure continuous spawning
        if (Time.time >= nextSpawnTime)
        {
            SpawnBullet();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnBullet()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet Prefab is MISSING! Ensure it is assigned in the Inspector.");
            return;
        }

        Vector2 spawnPosition = GetRandomEdgePosition();
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        if (bullet != null)
        {
            bullets.Add(bullet);
            Debug.Log("Bullet Spawned at: " + spawnPosition);
        }
    }

    Vector2 GetRandomEdgePosition()
    {
        float x = Random.Range(0, 2) == 0 ? Random.Range(-8f, 8f) : (Random.Range(0, 2) == 0 ? -8f : 8f);
        float y = (x == -8f || x == 8f) ? Random.Range(-5f, 5f) : (Random.Range(0, 2) == 0 ? -5f : 5f);
        return new Vector2(x, y);
    }
}
