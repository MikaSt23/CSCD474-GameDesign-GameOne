using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndHandler : MonoBehaviour
{
	public void Restart()
	{
		SceneManager.LoadScene("Farm");
	}

	public void Quit()
	{
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
	}
}
