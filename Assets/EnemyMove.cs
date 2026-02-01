using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2f;

    private float destroyY;

    void Start()
    {
        // Lấy đáy camera
        destroyY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - 2f;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
}
