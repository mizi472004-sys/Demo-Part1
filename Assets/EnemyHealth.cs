using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );

            Destroy(gameObject);
        }
    }
}
