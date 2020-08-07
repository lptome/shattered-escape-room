using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SettingsMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualityDropdown;
    public TMPro.TMP_Text FOVText;
    public AudioMixer audioMixer;
    public Camera mainCamera;
    public Animator transition;
    public Slider volumeSlider;
    public Slider FOVSlider;
    public float transitionTime = 1f;

    //These are keys that serve as identifiers when saving Player Preferences.
    const string resOptions = "resolutionOptions";
    const string qualityOptions = "qualityOptions";

    Resolution[] resolutions;

    private void Update()
    {
        FOVText.text = ((int)mainCamera.fieldOfView).ToString();
    }
    private void Awake()
    {

        //Saves option settings when transitioning scenes.
        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resOptions, resolutionDropdown.value);
            PlayerPrefs.Save();
        }));

        qualityDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(qualityOptions, qualityDropdown.value);
            PlayerPrefs.Save();
        }));
    }
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("savedVolume", 1f);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("savedVolume"));

        qualityDropdown.value = PlayerPrefs.GetInt(qualityOptions, 3);

        FOVSlider.value = PlayerPrefs.GetFloat("savedFOV", 85f);
        mainCamera.fieldOfView = PlayerPrefs.GetFloat("savedFOV");

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resOptions, currentResolution);
        resolutionDropdown.RefreshShownValue();
    }

    
    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
   
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("savedVolume", volume);
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("savedVolume")); 
    }

    public void SetFOV(float fov)
    {
        PlayerPrefs.SetFloat("savedFOV", fov);
        mainCamera.fieldOfView = fov;
    }
    public void PlayGame()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //Exits the application.
    public void QuitGame()
    {
        Application.Quit();
    }
    
    //Loads the next scene in the build order.
    IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }
}
