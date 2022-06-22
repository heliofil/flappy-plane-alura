using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController: MonoBehaviour
{

    private static UIController instance = null;

    private TextMeshProUGUI scoreText;
    private GameObject gameOver;
    private int score;
    public AudioClip SoundScore;

    public static UIController GetInstance() {
        if(instance == null) {
            instance = FindObjectOfType<UIController>();
        }

        return instance;

    }


    public void AddScore() {
        score++;
        scoreText.text = score.ToString();
        AudioSourceController.Instance.PlayOneShot(SoundScore);
        if((score%Utils.LEVEL_PASS)==0) {
            NextLevel();
        }
    }

    private float TrySaveScore() {
        int lastScore = PlayerPrefs.GetInt(Utils.PLAYER_SAVE_RECORD_SCORE,0);
        if(score > lastScore) {
            PlayerPrefs.SetInt(Utils.PLAYER_SAVE_RECORD_SCORE,score);
            return score;
        }
        return lastScore;

    }

    private void NextLevel() {
        BarriersGeneratorController.GetInstance().ReduceBetweenSize();
        BarriersGeneratorController.GetInstance().ReduceTimeToNewMax();
        BarriersGeneratorController.GetInstance().Acelerate();
        BackSceneController.accelerationAll();
    }

    public void GameOver() {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        PlaneController.GetInstance().SetPhysics(false);
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = TrySaveScore().ToString();
        
    }

    private void ReNew() {
        PlaneController.GetInstance().ReNew();
        BarriersGeneratorController.GetInstance().ReNew();
        BackSceneController.Renew();
    }

    public void Restart() {
        gameOver = transform.GetChild(0).gameObject;
        scoreText = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        score = 0;
        scoreText.text = score.ToString();
        gameOver.SetActive(false);
        Time.timeScale = 1;
        ReNew();
    }

    void Start() {
        Restart();
    }

}
