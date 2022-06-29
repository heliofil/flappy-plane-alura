using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Animator animator;

    [SerializeField]
    private float jumpForce = Utils.PLANE_JUMP_FORCE;

    private static PlaneController instance = null;

   
    private float finalPosition;
    private bool isJump;

    public static PlaneController GetInstance() {
        if(instance == null) {
            instance = GameObject.FindWithTag(Utils.PLANE_TAG).GetComponent<PlaneController>();
        }

        return instance;

    }

    public float GetFinalPostion() {
        return finalPosition;
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
        animator = GetComponent<Animator>();
        transform.position = Utils.PLANE_INIT;
        finalPosition = transform.position.x - (transform.localScale.x / 2);
        isJump = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown(Utils.BUTTON_FIRE_ONE)) {
           isJump = true;
        }

     }

    private void Jump() {
        if(isJump) {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);

        }

        isJump = false;
    }

    private void FixedUpdate() {
        Jump();
        animator.SetFloat("Blend",
            rigidbody.velocity.y
            );
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        UIController.GetInstance().GameOver();

    }


}
