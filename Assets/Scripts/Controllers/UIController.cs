using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController: MonoBehaviour
{

    

    public MovimentScriptable VelocityBarriers;
    public MovimentScriptable VelocityBackgroud;

    private TextMeshProUGUI scoreText;
    private GameObject gameOver;
    private int levelScore;
    private int score;
    private int lastScore;
    public AudioClip SoundScore;
    public bool isPlayerTwo;


    public void AddScore() {
        score++;
        levelScore++;
        scoreText.text = score.ToString();
        AudioSourceController.Instance.PlayOneShot(SoundScore);
        if(Utils.IsNextLevel(levelScore)) {
            levelScore = 0;
            NextLevel();
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
        Atomic.PlayerOne.Plane.GetInstance().SetPhysics(false);
        TrySaveScore();
        SetMedalByRecord();
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = lastScore.ToString();
        gameOver.SetActive(true);
    }

    public void Restart() {
        gameOver = transform.GetChild(0).gameObject;
        scoreText = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        score = 0;
        levelScore = 0;
        scoreText.text = score.ToString();
        gameOver.SetActive(false);
        Time.timeScale = 1;

        ReNew();
    }

    private void SetMedalByRecord() {

        Image medal = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>();
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
        Atomic.PlayerOne.Plane.GetInstance().ReNew();
        Atomic.PlayerOne.BarriersGenerator.GetInstance().ReNew();
        if(isPlayerTwo) {
            Atomic.PlayerTwo.Plane.GetInstance().ReNew();
            Atomic.PlayerTwo.BarriersGenerator.GetInstance().ReNew();
        }
        VelocityBarriers.Value = Utils.BARRIERS_VELOCITY;
        VelocityBackgroud.Value = Utils.BACKGROUND_VELOCITY;
        Utils.InitLevel();
    }

    private void Start() {
        Restart();
    }

}
