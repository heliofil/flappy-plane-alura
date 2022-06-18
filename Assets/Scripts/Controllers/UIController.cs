using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController: MonoBehaviour
{

    private static UIController instance = null;

    public static UIController GetInstance() {
        if(instance == null) {
            instance = FindObjectOfType<UIController>();
        }

        return instance;

    }

    public void GameOver() {
        Time.timeScale = 0f;
        SetGameOver(true);
        PlaneController.GetInstance().SetPhysics(false);
    }

    private void ReNew() {
        PlaneController.GetInstance().ReNew();
        BarriersGeneratorController.GetInstance().ReNew();
    }

    public void Restart() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SetGameOver(false);
        
        Time.timeScale = 1;
    }

    void Start() {
        Restart();
    }

    private void SetGameOver(bool isGameOver) {
        transform.GetChild(0).gameObject.SetActive(isGameOver);
    }





}
