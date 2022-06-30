using System.Collections;
using UnityEngine;
public class InputController:MonoBehaviour {

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown(Utils.BUTTON_FIRE_ONE)) {
            Atomic.PlayerOne.Plane.GetInstance().Jump();
        }
        if(Input.GetButtonDown(Utils.BUTTON_JUMP)) {
            Atomic.PlayerTwo.Plane.GetInstance().Jump();
        }
    }
}