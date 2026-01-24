using UnityEngine;

public class ShowLog : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello World! (Start called)");
    }

    void Update()
    {
        // Log mỗi 1 giây (≈ 60 frame)
        if (Time.frameCount % 60 == 0)
        {
            Debug.Log("Update running - frame: " + Time.frameCount);
        }
    }
}
