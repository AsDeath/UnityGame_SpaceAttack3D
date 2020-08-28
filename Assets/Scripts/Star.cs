using UnityEngine;

public class Star : MonoBehaviour
{
    float time = 0, time1 = 0;
    void Start()
    {
        transform.position = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
        transform.rotation = Random.rotation;
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.down * Time.deltaTime * 2);
        if (time < 1f) transform.localScale = new Vector3(transform.localScale.x + time, transform.localScale.y + time, 0);
        else
        {
            time1 += Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x - time1, transform.localScale.y - time1, 0);
        }
        if (time > 2)
        {
            Destroy(gameObject);
            time = 0;
            time1 = 0;
        }
    }
}
