using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] MazeGenerator mazeGenerator;
    [SerializeField] PlayerMovement player;
    [SerializeField] float timeLimit;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject restartPanel;

    private int score = 0;
    private float currentTime;

    public static GameManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeLimit;
        Prop.OnPropGet += AddScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeText.text = "Time left: " + ((int)currentTime).ToString();
        }
        else
        {
            finalScoreText.text= "Your Score: " + score.ToString();
            restartPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReGenerateLevel();
        }
    }

    private void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }

    private void OnDisable()
    {
        Prop.OnPropGet -= AddScore;
    }

    public void ReGenerateLevel()
    {
        mazeGenerator.RegenerateLevel();
        player.gameObject.transform.position = new Vector3(-2, 1, -2);
    }

    public void RestartGame()
    {
        restartPanel.SetActive(false);
        ReGenerateLevel();
        Time.timeScale = 1;
        score = 0;
        currentTime = timeLimit;
        scoreText.text = "Score: " + score.ToString();
    }
}
