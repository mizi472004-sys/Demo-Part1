using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 0.2f; // thời gian giữa mỗi viên đạn

    bool isAutoFire = false;
    float fireTimer;

    void Update()
    {
        // === DI CHUYỂN THEO CHUỘT ===
        var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;
        transform.position = worldPoint;

        // === BẬT / TẮT AUTO FIRE (bấm 1 lần) ===
        if (Input.GetMouseButtonDown(0)) // click chuột trái
        {
            isAutoFire = !isAutoFire;
        }

        // === BẮN TỰ ĐỘNG ===
        if (isAutoFire)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireRate)
            {
                Shoot();
                fireTimer = 0f;
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
