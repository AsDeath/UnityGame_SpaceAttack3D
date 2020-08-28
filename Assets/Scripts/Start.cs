using UnityEngine.SceneManagement;
using UnityEngine;

public class Start : MonoBehaviour
{
    public void StartOwnScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
