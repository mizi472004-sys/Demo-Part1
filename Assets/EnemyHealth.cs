using UnityEngine;

public class EnemyHealth : Health
{
    public static int LivingEnemyCount;
    public static int TotalEnemyKilled;   // ⭐ số enemy đã bị tiêu diệt

    void Awake()
    {
        LivingEnemyCount++;
    }

    protected override void Die()
    {
        LivingEnemyCount--;
        TotalEnemyKilled++;   // ⭐ tăng số kill

        base.Die();
    }
    
}
