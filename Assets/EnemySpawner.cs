using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int enemiesPerWave = 5;      // mỗi wave 5 con
    public float timeBetweenSpawns = 1f;
    public float timeBetweenWaves = 3f;

    private int enemiesSpawned = 0;
    private float timer = 0f;
    private int currentWave = 1;

    private bool isSpawning = true;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        StartWave();
    }

    void Update()
    {
        if (!isSpawning) return;

        timer += Time.deltaTime;

        if (timer >= timeBetweenSpawns && enemiesSpawned < enemiesPerWave)
        {
            SpawnEnemy();
            enemiesSpawned++;
            timer = 0f;
        }

        // Khi đủ 5 con → dừng và chờ wave tiếp theo
        if (enemiesSpawned >= enemiesPerWave)
        {
            isSpawning = false;
            Invoke(nameof(NextWave), timeBetweenWaves);
        }
    }

    void StartWave()
    {
        Debug.Log("Wave " + currentWave);
        enemiesSpawned = 0;
        isSpawning = true;
    }

    void NextWave()
    {
        currentWave++;
        StartWave();
    }

    void SpawnEnemy()
    {
        float leftX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float topY = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        float randomX = Random.Range(leftX + 0.5f, rightX - 0.5f);
        Vector3 spawnPos = new Vector3(randomX, topY - 1.5f, 0);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}