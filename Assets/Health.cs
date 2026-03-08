using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint = 3;

    public System.Action onDead;   // ✅ Sự kiện báo chết

    protected int healthPoint;

    protected virtual void Start()
    {
        healthPoint = defaultHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        if (healthPoint <= 0)
            Die();
    }

    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation
            );
            Destroy(explosion, 1f);
        }

        onDead?.Invoke();   // ✅ Báo cho BattleFlow biết đã chết

        Destroy(gameObject);
    }
}

