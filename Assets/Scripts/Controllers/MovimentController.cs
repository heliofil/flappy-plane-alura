using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentController :MonoBehaviour {


    [SerializeField]
    private float velocity;


    public void SetVelocity(float velocity) {
        this.velocity = velocity;
    }

    public void Accelerate(float acceletation) {
            velocity += acceletation;
    }


    // Update is called once per frame
    void FixedUpdate() => transform.Translate(Vector3.left * this.velocity);


}
