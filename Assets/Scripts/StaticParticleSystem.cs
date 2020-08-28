using UnityEngine;

public class StaticParticleSystem : MonoBehaviour
{
    Quaternion originalRotation;
    void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = originalRotation;
    }
}
