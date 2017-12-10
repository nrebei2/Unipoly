using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour {

	//public Toggle fullscreenToggle;
	//public Dropdown resolutionDropdown;
	public Slider musicMasterSlider;
	public Slider musicSFXSlider;
	public Slider musicMusicSlider;

	public static SettingsManager instance;

	public Button applyButton;

	//public Resolution[] resolutions;
	public GameSettings gameSettings;

	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;

	void Start()
	{
		instance = this;
	}

	void OnEnable()
	{
		gameSettings = new GameSettings();

	//	fullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
	//	resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
		musicMasterSlider.onValueChanged.AddListener(delegate { OnMusicMasterVolumeChange(); });
		musicSFXSlider.onValueChanged.AddListener(delegate { OnMusicSFXVolumeChange(); });
		musicMusicSlider.onValueChanged.AddListener(delegate { OnMusicMusicVolumeChange(); });

		musicMasterSlider.value = AudioManager.instance.masterVolumePercent;
		musicMusicSlider.value = AudioManager.instance.musicVolumePercent;
		musicSFXSlider.value = AudioManager.instance.sfxVolumePercent;

		applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

	//	resolutions = Screen.resolutions;

	//	var unique = new Dictionary<string, Resolution>();



		//foreach (Resolution resolution in resolutions)
		//{
			//unique[resolution.width + " x " + resolution.height] = resolution;
			//resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.width + " x " + resolution.height));
		//}

		if (File.Exists(Application.persistentDataPath + "/gamesettings.json") == true)
		{
			LoadSettings();
		}

		LoadSettings();
	}

	//public void OnFullScreenToggle()
	//{
		//gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn; 
	//}

	//public void OnResolutionChange()
	//{
		//Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
	//	gameSettings.resolutionIndex = resolutionDropdown.value;
	//}

	public void OnMusicMasterVolumeChange()
	{
		gameSettings.musicMasterVolume = musicMasterSlider.value;
		AudioManager.instance.SetVolume(musicMasterSlider.value, AudioManager.AudioChannel.Master);
	}

	public void OnMusicMusicVolumeChange()
	{
		gameSettings.musicMusicVolume = musicMusicSlider.value;
		AudioManager.instance.SetVolume(musicMusicSlider.value, AudioManager.AudioChannel.Music);
	}

	public void OnMusicSFXVolumeChange()
	{
		gameSettings.musicSFXVolume = musicSFXSlider.value;
		AudioManager.instance.SetVolume(musicSFXSlider.value, AudioManager.AudioChannel.Sfx);
	}


	public void OnApplyButtonClick()
	{
		SaveSettings();
	}

	// Saves Settings
	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson(gameSettings, true);
		File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
	}

	public void LoadSettings()
	{
		gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
		musicMasterSlider.value = gameSettings.musicMasterVolume;
		musicSFXSlider.value = gameSettings.musicSFXVolume;
		musicMusicSlider.value = gameSettings.musicMusicVolume;

		//resolutionDropdown.value = gameSettings.resolutionIndex;
		//fullscreenToggle.isOn = gameSettings.fullscreen;

		//resolutionDropdown.RefreshShownValue();

	}

}
