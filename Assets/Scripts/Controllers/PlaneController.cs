using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    [SerializeField]
    private float jump = Utils.PLANE_JUMP;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * jump,ForceMode2D.Impulse);
        }

    }
}
