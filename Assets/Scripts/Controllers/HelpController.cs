using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    public bool isPlayerTwo;
    
    public void StartGame() {
        if(isPlayerTwo) {
            Atomic.UI.GetInstance().StartGamePlay();
        }
    }

    public void Start() {
        TextMeshProUGUI helpText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        if(isPlayerTwo) {
            helpText.text = Utils.HELP_BUTTON_JUMP;
            return;
        }
        helpText.text = Utils.HELP_BUTTON_FIRE_ONE;
    }



}
