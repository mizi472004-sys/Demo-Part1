using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 10f;
    public int damage = 1;
    public float lifeTime = 3f;   // Thời gian tồn tại của đạn

    private void Start()
    {
        Destroy(gameObject, lifeTime); // Tự hủy sau X giây
    }

    private void Update()
    {
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Không tự va chạm với Player
        if (collision.CompareTag("Player"))
            return;

        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}