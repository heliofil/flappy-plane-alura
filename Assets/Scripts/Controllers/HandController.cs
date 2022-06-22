using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton(Utils.BUTTON_FIRE_ONE)) {
            Destroy(gameObject);
        }
    }
}
