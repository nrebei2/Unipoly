using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
	string sceneName;

	public AudioGroup[] audioGroups;

	Dictionary<string, AudioClip[]> groupDictionary = new Dictionary<string, AudioClip[]>();

	[System.Serializable]
	public class AudioGroup
	{
		public string groupID;
		public AudioClip[] group;
	}

	public AudioClip GetMusicClipFromName(string name)
	{
		if (groupDictionary.ContainsKey(name))
		{
			AudioClip[] music = groupDictionary[name];
			return music[Random.Range(0, music.Length)];
		}
		return null;
	}

	void Start()
	{
		OnLevelWasLoaded(0);
		foreach (AudioGroup audioGroup in audioGroups)
		{
			groupDictionary.Add(audioGroup.groupID, audioGroup.group);
		}
	}

	void OnLevelWasLoaded(int sceneIndex)
	{
		string newSceneName = SceneManager.GetActiveScene().name;
		if (newSceneName != sceneName)
		{
			sceneName = newSceneName;
			Invoke("PlayMusic", .2f);
		}
	}

	void PlayMusic()
	{
		AudioClip clipToPlay = null;

		if (sceneName == "Title_Screen")
		{
			clipToPlay = GetMusicClipFromName("MainMusic");
		}
		//else if (sceneName == "Plains" || sceneName == "PlainsEndless")
		//{
			//clipToPlay = GetMusicClipFromName("PlainsTheme");
		//}
		//else if (sceneName == "WorldMap")
		//{
			//clipToPlay = GetMusicClipFromName("WorldMapTheme");
		//}

		if (clipToPlay != null)
		{
			AudioManager.instance.PlayMusic(clipToPlay, 5);
			Invoke("ChillMusic", clipToPlay.length);
		}

	}

}