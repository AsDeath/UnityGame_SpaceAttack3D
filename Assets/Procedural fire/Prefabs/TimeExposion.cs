using UnityEngine;

public class TimeExposion : MonoBehaviour
{
    private float explosionTime = 1.5f;
    void Update()
    {
        Destroy(gameObject, explosionTime);
    }
}
