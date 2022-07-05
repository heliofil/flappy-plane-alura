using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour,IPlane
{

    public PlaneScriptable PlaneScriptable;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private float finalPosition;
    private bool isJump;
    private Vector3 initPosition;

    public void Jump() {
        isJump = true;
    }

    public float GetFinalPostion() {
        return finalPosition;
    } 

    public void ReNew() {
        transform.position = initPosition;
        SetPhysics(true);
    }

    public void SetPhysics(bool isSimulated) {
        rigidbody.simulated = isSimulated;

    }

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initPosition = transform.position;
        
        finalPosition = transform.position.x - (transform.localScale.x / 2);
        isJump = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.y > Utils.PLANE_UP_LIMIT) {
            return;
        }
        
        

     }

    private void FixedUpdate() {
        if(isJump) {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(Vector2.up * PlaneScriptable.GetJumpForce(),ForceMode2D.Impulse);
        }
        isJump = false;
        animator.SetFloat("Blend",
            rigidbody.velocity.y
            );
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        Atomic.UI.GetInstance().GameOver();

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Atomic.UI.GetInstance().AddScore();
    }

}
