using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BarriersGeneratorController barriersGeneratorController;
    private BackSceneController[] backSceneControllerList;
    private PlaneController planeController;
    private StopPlayerController stopPlayerController;

    private bool stopped;
    private int recovery;

    public bool IsStopped() {
        return stopped;
    }


    public void AddRecovery() {
        recovery++;
        stopPlayerController.SetPointsToRevive(recovery);
        if(recovery >= Utils.POINTS_TO_RESTART) {
            stopPlayerController.Close();
            Renew();
        } 
    }

    public void StopGame() {
        StopCarousel();
        barriersGeneratorController.StopAllBarries();
        planeController.StopGame();
        stopPlayerController.StopByPlayer(transform.GetChild(0).GetComponent<Camera>());
        stopped = true;
    }

    public void Renew() {
        recovery = 0;
        stopped = false;
        planeController.ReNew();
        barriersGeneratorController.ReNew();
        ReStartCarousel();
    }

    private void StopCarousel() {
        foreach(BackSceneController backScene in backSceneControllerList) {
            backScene.enabled = false;
        }
    }

    private void ReStartCarousel() {
        foreach(BackSceneController backScene in backSceneControllerList) {
            backScene.enabled = true;
        }
    }


    private void Start() {
        stopped = false;

    }


    private void Awake() {
        stopPlayerController = Atomic.StopPlayer.GetInstance();
        backSceneControllerList = GetComponentsInChildren<BackSceneController>();
        if(this.CompareTag(Utils.PLAYER_TAG)) {
            barriersGeneratorController = Atomic.PlayerOne.BarriersGenerator.GetInstance();
            planeController = Atomic.PlayerOne.Plane.GetInstance();
            return;
        }
        barriersGeneratorController = Atomic.PlayerTwo.BarriersGenerator.GetInstance();
        planeController = Atomic.PlayerTwo.Plane.GetInstance();
        
    }




}
