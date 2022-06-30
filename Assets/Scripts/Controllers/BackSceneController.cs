using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSceneController : MonoBehaviour
{

    public MovimentScriptable Velocity;

    private Vector3 initialPosition;

    private float imageSize;

    private float restartPosition;


    private void Start() {

        initialPosition = transform.position;

        imageSize = GetComponent<SpriteRenderer>().size.x * (transform.localScale.x/2);

        restartPosition = initialPosition.x-imageSize;

    }


    private void FixedUpdate() {
        if(transform.position.x < restartPosition) {
            transform.position = initialPosition;
        }

        transform.Translate(Velocity.Move());

    }



}
