using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayer : MonoBehaviour
{
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(AutoJump());
    }



    private IEnumerator AutoJump() {

        while(true) {
            yield return new WaitForSeconds(0.59f);
            Atomic.PlayerTwo.Plane.GetInstance().Jump();
        }
        

    }

}
