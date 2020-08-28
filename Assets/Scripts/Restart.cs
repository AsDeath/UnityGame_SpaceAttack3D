using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour 
{ 
    public void RestartOwnScene()
    {
        SceneManager.LoadScene(1);
    }
}
