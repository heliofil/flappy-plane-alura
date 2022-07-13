using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopPlayerController : MonoBehaviour
{

    private TextMeshProUGUI pointsToRevive;
    private Canvas canvas;

    public void StopByPlayer(Camera camera) {
        pointsToRevive.text = "0";
        gameObject.SetActive(true);
        canvas.worldCamera = camera;
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void SetPointsToRevive(int points) {
        pointsToRevive.text = points.ToString();
    }

    private void Start() {
        canvas = GetComponent<Canvas>();
        pointsToRevive = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

   

}
