using UnityEngine;
using System.Threading;

public class CreateStar : MonoBehaviour
{
    public GameObject star;
    public Canvas canvas;

    void Start()
    {
        StarCreate();
    }

    void Update()
    {
        StarCreate();
        Thread.Sleep(2000);
    }

    void StarCreate()
    {
        GameObject newStar = Instantiate(star) as GameObject;
        newStar.transform.SetParent(canvas.transform);
    }
}