using UnityEngine;
using UnityEngine.EventSystems;


public class Pause : MonoBehaviour, IPointerClickHandler
{

    private PublicValues val;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject diePanel;
    void Start()
    {
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
    }

    void Update()
    {
        if (val.isPause == true)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }

        if (val.diePlayer)
        {
            diePanel.SetActive(true);
            PlayerPrefs.SetInt("Save", Save.MaxScore);
        }
        else diePanel.SetActive(false);
    }
    public virtual void OnPointerClick(PointerEventData pointerEvent)
    {
        val.isPause = true;
    }
    
}
