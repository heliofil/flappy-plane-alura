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
    PlayerController playerOne;
    PlayerController playerTwo;

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
                Atomic.PlayerOne.GetInstance().AddRecovery();
            }
            if(playerTwo.IsStopped()) {
                Atomic.PlayerTwo.GetInstance().AddRecovery();
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
        BarriersGeneratorController barriersGeneratorController = Atomic.PlayerOne.BarriersGenerator.GetInstance();
        barriersGeneratorController.ReduceBetweenSize();
        barriersGeneratorController.ReduceTimeToNewMax();
        VelocityBarriers.Accelerate(Utils.BARRIERS_ACCELERATION);
        VelocityBackgroud.Accelerate(Utils.BACKGROUND_ACCELERATION);
    }

    public void GameOver() {
       
        Time.timeScale = 0f;
        TrySaveScore();
        SetMedalByRecord();
        gameOverText.text = lastScore.ToString();
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
        if(isPlayerTwo) {
            playerTwo = Atomic.PlayerTwo.GetInstance();
        }
        


    }

    private void Start() {
        Restart();
    }

}
