using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioController : MonoBehaviour
{
	public CanvasGroup transition;
	public RectTransform displayOption;
	public RectTransform panel;
	public Vector3 startOption;
	public float time = 1.5f;
	public float startAlpha;
	public float endAlpha = 1f;
	private void Awake()
	{
		panel = GameObject.Find("Panel").GetComponent<RectTransform>();
		displayOption = GameObject.Find("DisplayOption").GetComponent<RectTransform>();
		transition = GameObject.Find("Panel").GetComponent<CanvasGroup>();
		startAlpha = transition.alpha;
		startOption = displayOption.position;
		if (PlayerPrefs.HasKey("Player1") || PlayerPrefs.HasKey("Player2"))
		{
			PlayerPrefs.DeleteKey("Player1");
			PlayerPrefs.DeleteKey("Player2");
		}
		//Debug.Log(Screen.mainWindowPosition);
	}
	public void FT_Init()
	{
		StartCoroutine(TransitionDisplay());
	}
	IEnumerator TransitionDisplay()
	{
		float i = 0;
		while (i < time)
		{
			transition.alpha = Mathf.Lerp(startAlpha, endAlpha, (i / time));
			i += Time.deltaTime;
			yield return null;
		}
		transition.alpha = endAlpha;
		//ControllerDates.instance.ChangeScene();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void FT_option()
	{
		StartCoroutine(TransitionOption(time, startOption, panel.position));
	}
	IEnumerator TransitionOption(float time, Vector3 posInit, Vector3 posFin)
	{
		float i = 0;

		while (i < time)
		{
			displayOption.position = Vector3.Lerp(posInit, posFin, i / time);
			i += Time.deltaTime;
			yield return null;
		}
		displayOption.position = new(posInit.x / 2.5f, displayOption.position.y, 0);
	}
	public void FT_exit()
	{

	}

}
