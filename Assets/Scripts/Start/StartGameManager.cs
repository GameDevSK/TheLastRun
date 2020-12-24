using UnityEngine;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour
{

    //public AudioMixer mixer;
    public Slider slider;

    public GameObject loadingCanvas;

    public Text musicText;

    [Header("Menus")]
    public GameObject shopMenu;
    public GameObject scoreMenu;
    public GameObject settingsMenu;

    
    
    //bool isPressed_Settings;
    //bool isPressed_Score;

    [Header("High Score")]
    public Text highScoreText;

    [Header("Coins")]
    public Text coinText;
    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        coinText.text = PlayerPrefs.GetInt("Coins").ToString();
        slider.value = PlayerPrefs.GetFloat("Volume");
    }
    public void EnableSettingsMenu()
    {

        shopMenu.SetActive(false);
        scoreMenu.SetActive(false);

        settingsMenu.SetActive(true);
        /*
        if (!isPressed_Settings)
        {
            settingsMenu.SetActive(true);
            isPressed_Settings = true;
        }

        else if(isPressed_Settings)
        {
            settingsMenu.SetActive(false);
            isPressed_Settings = false;
        }
        */
    }

    public void EnableScoreMenu()
    {
        settingsMenu.SetActive(false);
        shopMenu.SetActive(false);

        scoreMenu.SetActive(true);
        /*
        if (!isPressed_Score)
        {
            scoreMenu.SetActive(true);
            isPressed_Score = true;
        }

        else if (isPressed_Score)
        {
            scoreMenu.SetActive(false);
            isPressed_Score = false;
        }
        */
    }

    public void EnableShopMenu()
    {
        shopMenu.SetActive(true);
    }
    public void ControlVolume(float volume)
    {
        volume = slider.value;
        musicText.text = "Music: " + slider.value.ToString("0");
        //Debug.Log(volume);
        //mixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }


    public void LoadMainScene()
    {
        loadingCanvas.SetActive(true);
    }

    
    public void ExitGame()
    {
        Application.Quit();
    }

}
