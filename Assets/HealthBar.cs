using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform mask;
    public Health health;

    float originalWidth;

    void Start()
    {
        originalWidth = mask.sizeDelta.x;

        UpdateHealth();

        health.onHealthChanged += UpdateHealth;
    }

    void UpdateHealth()
    {
        float scale = (float)health.healthPoint / health.defaultHealthPoint;

        mask.sizeDelta = new Vector2(scale * originalWidth, mask.sizeDelta.y);
    }
}