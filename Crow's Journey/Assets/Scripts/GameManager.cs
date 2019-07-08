using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    public static int score;
    private int scoreHasGottenTo;
    [SerializeField] TextMeshProUGUI scoreText;
    public Interact spikeTrap;
    public Interact axeTrap;
    public Interact arrowTrap;

    [Header("Stats")]
    public int jumpsDone;
    public int dashesDone;
    public int trapsEncountered;

    [Header("TrapAttributes")]
    public static int axeGravityScale = 2;
    public static int arrowSpeed = 30;
    public static float spikeWaitTime = 1;
    public static float trapSpawnChance = 0.4f;


    public CharacterController2d player;
    public CameraMovement2d camera;

    private void Awake()
    {
        Instance = null;
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != null)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        score = CalculateScore();
        SetScoreText(score);
        CheckIfScore();
    }

    private void SetScoreText(int score)
    {
        scoreText.SetText("Score: " + score);
    }

    private int CalculateScore()
    {
        return (int)Vector2.Distance(player.transform.position, Vector3.zero);
    }

    private void SpeedUp(float speedUpValuePlayer, float speedUpValueCamera)
    {
        camera.movementSpeed += speedUpValueCamera;
        player.movementSpeed += speedUpValuePlayer;
    }

    private void CheckIfScore()
    {
        if (score > 50 && scoreHasGottenTo < 50)
        {
            scoreHasGottenTo = 50;
            SpeedUp(1, 2);
        } else if(score > 100 && scoreHasGottenTo < 100)
        {
            scoreHasGottenTo = 100;
            SpeedUp(1, 1.5f);
        } else if(score > 250 && scoreHasGottenTo < 250)
        {
            scoreHasGottenTo = 250;
            SpeedUp(1, 1.5f);
        }
    }

    public void KillPlayer()
    {
        player.Die();
        player.enabled = false;
        camera.enabled = false;
        UiManager.Instance.DragStatsDown();
    }

    public void RestartGame()
    {
        axeGravityScale = 2;
        arrowSpeed = 30;
        spikeWaitTime = 1;
        trapSpawnChance = 0.4f;
        jumpsDone = 0;
        dashesDone = 0;
        trapsEncountered = 0;

        SceneManager.LoadScene(1);

    }
}

