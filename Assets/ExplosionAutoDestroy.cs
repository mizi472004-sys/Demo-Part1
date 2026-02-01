using UnityEngine;

public class ExplosionAutoDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }
}
