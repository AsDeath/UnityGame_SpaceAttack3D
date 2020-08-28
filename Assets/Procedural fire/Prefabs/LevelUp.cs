using UnityEngine;

public class LevelUp : MonoBehaviour
{
    private float destroyTime = 0.5f;
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
