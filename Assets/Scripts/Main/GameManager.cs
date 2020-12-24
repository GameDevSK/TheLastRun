using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("Game Over Objects")]
	public GameObject gameOverGameObject;
	public Text scoreText;
	public Text bestScoreText;
	//public RectTransform xScoreRecttransform;


	[Header("Coins")]
	public Text coinText;


	bool isPaused;
	AudioSource backgroundMusic;


	int coins = 0;
	private void Awake()
	{ 
		backgroundMusic = GetComponent<AudioSource>();
		backgroundMusic.volume=PlayerPrefs.GetFloat("Volume")/100;
	}

	private void Start()
	{
		//backgroundMusic.playOnAwake = true;
		coins = PlayerPrefs.GetInt("Coins", 0);
		coinText.text = "Coins: " + coins.ToString();
	}
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if (isPaused == false)
			{
				isPaused = true;
				Time.timeScale = 0;
				StopAudio();
			}
			else
			{
				isPaused = false;
				Time.timeScale = 1;
				PlayAudio();
			}
		}
	}

	public void UpdateCoinScore()
	{
		coins = PlayerPrefs.GetInt("Coins", 0);
		coins += 1;
		coinText.text = "Coins: " + coins.ToString();
		PlayerPrefs.SetInt("Coins", coins);
	}

	public void EnableGameOverObject()
	{
		gameOverGameObject.SetActive(true);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(1);
		Time.timeScale = 1;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}

	public void ResetAll()
	{
		PlayerPrefs.DeleteKey("Coins");
		PlayerPrefs.DeleteKey("HighScore");
		scoreText.text = "0";
		bestScoreText.text = "0";
	}


	public void PlayAudio()
	{
		if (!backgroundMusic.isPlaying)
			backgroundMusic.Play();
	}
	public void StopAudio()
	{
		if(backgroundMusic.isPlaying)
			backgroundMusic.Stop();
	}
}
