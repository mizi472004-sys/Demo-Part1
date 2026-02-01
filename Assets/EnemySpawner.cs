using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1.5f;

    private float timer;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Lấy biên camera
        float leftX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float topY = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        float randomX = Random.Range(leftX + 0.5f, rightX - 0.5f);
        Vector3 spawnPos = new Vector3(randomX, topY - 1.5f, 0);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
