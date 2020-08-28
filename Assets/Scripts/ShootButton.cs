using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour, IPointerDownHandler
{
    private Image shootImage;
    int shootOn = -1;

    void Start()
    {
        shootImage = GetComponent<Image>();
    }
    public virtual void OnPointerDown(PointerEventData pointerEvent)
    {
        shootOn = -shootOn;
        if (shootOn == 1) shootImage.color = new Color32(255, 50, 50, 150);
        else shootImage.color = new Color32(255, 255, 255, 150);
    }
    public int GetShootOn()
    {
        return shootOn;
    }
}
