using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    [SerializeField]
    private float jump = Utils.PLANE_JUMP;

    private static PlaneController instance = null;

    public static PlaneController GetInstance() {
        if(instance == null) {
            instance = GameObject.FindWithTag(Utils.PLANE_TAG).GetComponent<PlaneController>();
        }

        return instance;

    }

    public void ReNew() {
        transform.position = Utils.PLANE_INIT;
        SetPhysics(true);
    }

    public void SetPhysics(bool isSimulated) {
        rigidbody.simulated = isSimulated;

    }

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * jump,ForceMode2D.Impulse);
        }

     }

    private void OnCollisionEnter2D(Collision2D collision) {
        UIController.GetInstance().GameOver();
    }


}
