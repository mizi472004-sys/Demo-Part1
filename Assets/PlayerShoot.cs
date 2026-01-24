using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab đạn
    public Transform firePoint;      // Nòng súng

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
