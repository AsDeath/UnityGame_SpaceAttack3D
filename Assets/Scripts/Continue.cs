using UnityEngine;
using UnityEngine.EventSystems;

public class Continue : MonoBehaviour, IPointerClickHandler
{
    private PublicValues val;
    void Start()
    {
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
    }

    public virtual void OnPointerClick(PointerEventData pointerEvent)
    {
        val.isPause = false;
    }
}
