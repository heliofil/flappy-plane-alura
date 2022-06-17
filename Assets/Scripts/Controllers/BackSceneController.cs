using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSceneController : MonoBehaviour
{


    public bool IsBackGround;

    private Vector3 initialPosition;

    private float imageSize;

    private float restartPosition;


    void Start() {

        initialPosition = transform.position;

        float velocity = Utils.BARRIERS_VELOCITY;

        if(IsBackGround) {
            velocity = Utils.BACKGROUND_VELOCITY;
        }

        GetComponent<MovimentController>().SetVelocity(velocity);

        imageSize = GetComponent<SpriteRenderer>().size.x * transform.localScale.x;

        restartPosition = initialPosition.x-imageSize;

    }


    void Update() {
        if(transform.position.x < restartPosition) {
            transform.position = initialPosition;
        }
    }



}
