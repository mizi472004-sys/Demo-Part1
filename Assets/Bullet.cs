using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 8f;

    void Update()
    {
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
    }

    void Start()
    {
        Destroy(gameObject, 3f);
    }
}
