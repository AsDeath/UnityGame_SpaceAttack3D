
using UnityEngine;
using UnityEngine.EventSystems;


public class SpeedMoveDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource EngineSound;
    bool _pressed = false;
    public virtual void OnPointerDown(PointerEventData pointerEvent)
    {
        _pressed = true;
        EngineSound.Play();
    }

    public virtual void OnPointerUp(PointerEventData pointerEvent)
    {
        _pressed = false;
        EngineSound.Stop();
    }

    public bool GetPressed()
    {
        return _pressed;
    }
}
