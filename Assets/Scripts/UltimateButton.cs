using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class UltimateButton : MonoBehaviour, IPointerDownHandler
{
    Image ultButton;
    PublicValues val;
    void Start()
    {
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
        ultButton = GetComponent<Image>();
    }
    
    void FixedUpdate()
    {
        if (val.button_ultimate == true) ultButton.color = new Color32(122, 237, 255, 150);
        else ultButton.color = new Color32(255, 130, 130, 150);
    }
    public virtual void OnPointerDown(PointerEventData ultPointEvent)
    {
        if (val.button_ultimate == true)
        {
            val.pressedUltButton = true;
        }
        else
        {
            val.pressedUltButton = false;
        }
    }

}

