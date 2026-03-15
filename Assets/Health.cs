using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint = 3;

    public System.Action onDead;          // khi chết
    public System.Action onHealthChanged; // khi máu thay đổi

    public int healthPoint;

    protected virtual void Start()
    {
        healthPoint = defaultHealthPoint;

        onHealthChanged?.Invoke(); // cập nhật thanh máu ban đầu
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        onHealthChanged?.Invoke(); // báo thanh máu cập nhật

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

        onDead?.Invoke();

        Destroy(gameObject);
    }
}
