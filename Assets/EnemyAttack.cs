using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyHealth health;   // ⭐ phải là EnemyHealth
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            health.TakeDamage(999);
        }
    }
}
