using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    //Game Manager Script
    private GameManager gameManager;

    //Targer Follower Script
    //private TargetFollower targetFollower;

    public float boundX;

    //public float jumpForce;
    public float movingSpeed;
    public float smoothness = 2.5f;
    public float speed;

    //UI elements
    public Text scoreTextMain;


    AudioSource audioSource;
    float lastUpdate = 0f;
    Rigidbody rb;

    int score = 0;
    //To Store speed variable
    float constSpeed;
    private void Awake()
    {
        //targetFollower = Camera.main.GetComponent<TargetFollower>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        scoreTextMain.text = "0";
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager.bestScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
     
        
        if (movingSpeed != 0 && Time.time - lastUpdate>=1f)
        {
            lastUpdate = Time.time;
            ScoreUpdate();
        }
            
        transform.Translate(Vector3.forward * Time.deltaTime * movingSpeed, Space.World);
        PlayerMovement();
    }
    
    //To clamp player position
    public void ClampPosition()
    {
        Mathf.Clamp(transform.position.x, -boundX, boundX);
    }


    //To update score in Game
    private void ScoreUpdate()
    {
        score += 1;
        scoreTextMain.text = score.ToString();
    }

    //movements of player
    private void PlayerMovement()
    {
        //Move player left and right 

        Vector3 input = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, 0f);
        Vector3 newPosition = transform.position + input;
        transform.position = newPosition;

        if (transform.position.x > boundX)
            transform.position = new Vector3(boundX, transform.position.y, transform.position.z);
        if(transform.position.x < -boundX)
            transform.position = new Vector3(-boundX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Obstacle")
        {
            gameManager.StopAudio();
            movingSpeed = 0;
            speed = 0;
            //Time.timeScale = 0;
            gameManager.scoreText.text = score.ToString();
            gameManager.EnableGameOverObject();

            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                gameManager.bestScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Coin")
        {
            audioSource.Play();
            gameManager.UpdateCoinScore();
        }
    }
}
