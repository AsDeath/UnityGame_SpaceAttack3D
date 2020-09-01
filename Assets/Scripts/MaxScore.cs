using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
    private Text maxScore;
    void Start()
    {
        maxScore = GetComponent<Text>();
        maxScore.text = "Max Score: " + Save.MaxScore;
    }
}
