using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;
	public GameObject audioMenuHolder;

	//public string level1Tag;
	//public string level2Tag;
	//public string level3Tag;

	IEnumerator ChangeLevel ()
	{
		float fadeTime = GameObject.Find("_MM").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene("MainGame");
	}

	IEnumerator ChangeLevelToWorldMap()
	{
		float fadeTime = GameObject.Find("_MM").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene("MainGame");
	}

	public void NewGame()
	{
		AudioManager.instance.PlaySound("ButtonEnter");
		StartCoroutine(ChangeLevel());
	}

	public void ContinueGame()
	{
		AudioManager.instance.PlaySound("ButtonEnter");
		StartCoroutine(ChangeLevelToWorldMap());
	}

	public void OptionsMenu()
	{
		AudioManager.instance.PlaySound("ButtonEnter");
		mainMenuHolder.SetActive(false);
		optionsMenuHolder.SetActive(true);
	}

	public void AudioMenu()
	{
		AudioManager.instance.PlaySound("ButtonEnter");
		optionsMenuHolder.SetActive(false);
		audioMenuHolder.SetActive(true);
	}

	public void AudioMenutoOptionsMenu()
	{
		AudioManager.instance.PlaySound("ButtonBack");
		audioMenuHolder.SetActive(false);
		optionsMenuHolder.SetActive(true);
	}

	public void ExitGame()
	{
		AudioManager.instance.PlaySound("ButtonEnter");
		Application.Quit();
	}

	public void ApplyButton()
	{
		AudioManager.instance.PlaySound("ButtonBack");
		mainMenuHolder.SetActive(true);
		optionsMenuHolder.SetActive(false);
	}

	public void OnMouseOver ()
	{
		AudioManager.instance.PlaySound("ButtonHover");
	}

}
