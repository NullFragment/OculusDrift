using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadeout : MonoBehaviour {

	public Image splashImage;
	public string loadLevel;

	private IEnumerator Start()
	{
		splashImage.canvasRenderer.SetAlpha(0.0f);

		fadeIn();
		yield return new WaitForSeconds(2.5f);

		fadeOut();
		yield return new WaitForSeconds(2.5f);
		SceneManager.LoadScene(loadLevel);
	}

	void fadeIn() { splashImage.CrossFadeAlpha(1.0f, 1.5f, false); }
	void fadeOut() { splashImage.CrossFadeAlpha(0.0f, 2.5f, false); }

}
