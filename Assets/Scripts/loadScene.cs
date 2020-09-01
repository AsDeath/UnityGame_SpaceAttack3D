using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
	private int pRounded;
	public GUIStyle Main;
	public GUIStyle BackGround;

	bool load = false;
	public void LoadScene()
	{
		load = true;
		StartCoroutine("launchLevel");

	}

	IEnumerator launchLevel()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(1);

		while (async.isDone == false)
		{
			pRounded = Mathf.RoundToInt(async.progress * Screen.width);

			yield return true;
		}
	}

	void OnGUI()
	{
		if (load == true)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", Main);
			GUI.Box(new Rect(0, Screen.height - (Screen.height/9), pRounded+Screen.width*0.1f, 30), "", BackGround);
		}
		
	}
}
