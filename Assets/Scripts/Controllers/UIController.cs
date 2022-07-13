using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController: MonoBehaviour
{
    public MovimentScriptable VelocityBarriers;
    public MovimentScriptable VelocityBackgroud;
    public AudioClip SoundScore;
    public bool isPlayerTwo;

    private TextMeshProUGUI gameOverText;
    private TextMeshProUGUI scoreText;
    private GameObject gameOver;
    private int levelScore;
    private int score;
    private int lastScore;
    private Image medal;
    private PlayerController playerOne;
    private PlayerController playerTwo;
    private PlaneController planeOne;
    private PlaneController planeTwo;
    private BarriersGeneratorController barriersGeneratorControllerOne;
    private BarriersGeneratorController barriersGeneratorControllerTwo;
    public void AddScore() {
        score++;
        levelScore++;
        scoreText.text = score.ToString();
        AudioSourceController.Instance.PlayOneShot(SoundScore);
        if(Utils.IsNextLevel(levelScore)) {
            levelScore = 0;
            NextLevel();
        }
        testTwoPlayersRecovery();
    }

    public void TryGameOverOrStop(string tag) {

        if(isPlayerTwo) {
            if(tag.Equals(Utils.PLANE_TAG)) {
                playerOne.StopGame();
            } else {
                playerTwo.StopGame();
            }
            if((playerOne.IsStopped()) && (playerTwo.IsStopped())) {
                GameOver();
                return;
            }
            return;
        } 
        GameOver();
     
        
    }

    private void testTwoPlayersRecovery() {
        if(isPlayerTwo) {
            if(playerOne.IsStopped()) {
                playerOne.AddRecovery();
            }
            if(playerTwo.IsStopped()) {
                playerTwo.AddRecovery();
            }
        }
    }
    
    private void TrySaveScore() {
        lastScore = PlayerPrefs.GetInt(Utils.PLAYER_SAVE_RECORD_SCORE,0);
        if(score > lastScore) {
            PlayerPrefs.SetInt(Utils.PLAYER_SAVE_RECORD_SCORE,score);
            lastScore = score;
        }
       
    }

    private void NextLevel() {
       
        barriersGeneratorControllerOne.ReduceBetweenSize();
        barriersGeneratorControllerOne.ReduceTimeToNewMax();
        if(isPlayerTwo) {
            barriersGeneratorControllerTwo.ReduceBetweenSize();
            barriersGeneratorControllerTwo.ReduceTimeToNewMax();
        }
        VelocityBarriers.Accelerate(Utils.BARRIERS_ACCELERATION);
        VelocityBackgroud.Accelerate(Utils.BACKGROUND_ACCELERATION);
    }

    public void GameOver() {
       
        Time.timeScale = 0f;
        TrySaveScore();
        SetMedalByRecord();
        gameOverText.text = lastScore.ToString();
        if(isPlayerTwo) {
            Atomic.StopPlayer.GetInstance().Close();
        }
        gameOver.SetActive(true);

    }


    public void Restart() {
        gameOver = transform.GetChild(0).gameObject;
        score = 0;
        levelScore = 0;
        scoreText.text = score.ToString();
        gameOver.SetActive(false);
        Time.timeScale = 1;
        ReNew();
    }


    public void StartGamePlay() {
        planeOne.SetPhysics(true);
        planeOne.Jump();
       barriersGeneratorControllerOne.StartPlay();
        if(isPlayerTwo) {
            planeTwo.SetPhysics(true);
            planeTwo.Jump();
            barriersGeneratorControllerTwo.StartPlay();
        }
    }

   
    private void SetMedalByRecord() {

       
        if(score > (lastScore - 1)) {
            medal.sprite = Utils.MEDAL_GOLD_LOAD;
            return;
        }

        if(score > ((lastScore/3)*2 )) {
            medal.sprite = Utils.MEDAL_SILVER_LOAD;
            return;
        }

        medal.sprite = Utils.MEDAL_BRONZE_LOAD;

    }

    private void ReNew() {

        playerOne.Renew();
        if(isPlayerTwo) {
            playerTwo.Renew();
        }
        VelocityBarriers.Value = Utils.BARRIERS_VELOCITY;
        VelocityBackgroud.Value = Utils.BACKGROUND_VELOCITY;
        Utils.InitLevel();
    }

    private void Awake() {
        scoreText = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        gameOverText = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        medal = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>();
        gameOver = transform.GetChild(0).gameObject;
        playerOne = Atomic.PlayerOne.GetInstance();
        planeOne = Atomic.PlayerOne.Plane.GetInstance();
        barriersGeneratorControllerOne = Atomic.PlayerOne.BarriersGenerator.GetInstance();
        if(isPlayerTwo) {
            playerTwo = Atomic.PlayerTwo.GetInstance();
            planeTwo = Atomic.PlayerTwo.Plane.GetInstance();
            barriersGeneratorControllerTwo = Atomic.PlayerTwo.BarriersGenerator.GetInstance();
        }

    }

    private void Start() {
        Restart();
        planeOne.SetPhysics(false);
        if(isPlayerTwo) {
            planeTwo.SetPhysics(false);
        }
    }

}
