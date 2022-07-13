using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private string sceneStart;

    public void OnePlayer() {
        sceneStart = Utils.SCENE_CAVE1;
        StartCoroutine(DelayNewGame());
    }

    public void TwoPlayers() {
        sceneStart = Utils.SCENE_CAVE2;
        StartCoroutine(DelayNewGame());
    }

    IEnumerator DelayNewGame() {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(sceneStart);
    }

}
