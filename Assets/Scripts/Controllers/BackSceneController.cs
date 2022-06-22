using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSceneController : MonoBehaviour
{


    public bool IsBackground;

    private Vector3 initialPosition;

    private float imageSize;

    private float restartPosition;


    public static void accelerationAll() {
        float velocity;
        GameObject[] xGameObjects = GameObject.FindGameObjectsWithTag(Utils.BACKSCENE_TAG);
        foreach(GameObject xGameObject in xGameObjects) {
            velocity = Utils.BARRIERS_ACCELERATION;
            if(xGameObject.TryGetComponent<BackSceneController>(out BackSceneController backSceneController)) {
                if(backSceneController.IsBackground) {
                   velocity = Utils.BACKGROUND_ACCELERATION;
                }
            }
            if(xGameObject.TryGetComponent<MovimentController>(out MovimentController movimentController)) {
                movimentController.Accelerate(velocity);
            }
        }
    }

    public static void Renew() {
        float velocity;
        GameObject[] xGameObjects = GameObject.FindGameObjectsWithTag(Utils.BACKSCENE_TAG);
        foreach(GameObject xGameObject in xGameObjects) {
            velocity = Utils.BARRIERS_VELOCITY;
            if(xGameObject.TryGetComponent<BackSceneController>(out BackSceneController backSceneController)) {
                if(backSceneController.IsBackground) {
                    velocity = Utils.BACKGROUND_VELOCITY;
                }
            }
            if(xGameObject.TryGetComponent<MovimentController>(out MovimentController movimentController)) {
                movimentController.SetVelocity(velocity);
            }
        }
    }


    void Start() {

        initialPosition = transform.position;

        MovimentController movimentController = GetComponent<MovimentController>();

        if(IsBackground) {
            movimentController.SetVelocity(Utils.BACKGROUND_VELOCITY);
        } else {
            movimentController.SetVelocity(Utils.BARRIERS_VELOCITY);
        }


        imageSize = GetComponent<SpriteRenderer>().size.x * transform.localScale.x;

        restartPosition = initialPosition.x-imageSize;

    }


    void Update() {
        if(transform.position.x < restartPosition) {
            transform.position = initialPosition;
        }
    }



}
