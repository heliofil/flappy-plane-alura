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
    }


    public void GameOver() {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        PlaneController.GetInstance().SetPhysics(false);
    }

    private void ReNew() {
        PlaneController.GetInstance().ReNew();
        BarriersGeneratorController.GetInstance().ReNew();
    }

    public void Restart() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
