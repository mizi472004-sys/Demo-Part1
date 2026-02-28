using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyHealth health;   // ❌ bỏ public
    public int damage = 1;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();   // ✅ tự lấy component
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
            health.TakeDamage(999);
        }
    }
}