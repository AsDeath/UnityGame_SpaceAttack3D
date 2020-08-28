
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    private Vector2 worldDelta;
    private Vector2 worldStartPoint;
    private Image joystick;
    private RectTransform rectTransform;

    Quaternion rotationX;
    Quaternion rotationY;

    public float sens = 1f;
    bool checkJoystick = false;

    void Start()
    {
        joystick = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Screen.width / 2, Screen.height);
        rectTransform.transform.position = new Vector2(Screen.width / 4, Screen.height/2);
    }

    public virtual void OnPointerDown(PointerEventData red)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick.rectTransform, red.position, red.pressEventCamera, out worldStartPoint);
    }

    public virtual void OnPointerUp(PointerEventData red)
    {
        checkJoystick = false;
    }

    public virtual void OnDrag(PointerEventData red)
    {
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick.rectTransform, red.position, red.pressEventCamera, out worldDelta);
        worldDelta = worldStartPoint - worldDelta;
        rotationX = Quaternion.AngleAxis(worldDelta.y * sens * Time.deltaTime, Vector3.right);
        rotationY = Quaternion.AngleAxis(-worldDelta.x * sens * Time.deltaTime, Vector3.up);
        checkJoystick = true;
    }

    public Quaternion GetRotationX()
    {
        return rotationX;
    }

    public Quaternion GetRotationY()
    {
        return rotationY;
    }
    public bool GetCheckJoystick()
    {
        return checkJoystick;
    }

    public Vector2 GetWorldDelta()
    {
        return worldDelta;
    }
}
