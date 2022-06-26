using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersController :MonoBehaviour {

    public MovimentScriptable Velocity;
    
    [SerializeField]
    private float offSet;
    private bool isScore = true;


    public static void CreateInstance(Vector3 position,float offet,float betweenSize) {
        GameObject gameObject = Instantiate
            (Utils.BARRIER_LOAD,
            position,
            Quaternion.identity);

        gameObject.tag = Utils.BACKSCENE_TAG;

        BarriersController barriersController = gameObject.GetComponent<BarriersController>();
        barriersController.SetOffset(offet);
        barriersController.SetBetweenSize(betweenSize);
    }

    private void SetOffset(float offet) {
   
        this.offSet = offet;
    }

    private void SetBetweenSize(float betweenSize) {
        transform.GetChild(0).transform.Translate(Vector3.down * betweenSize);
        transform.GetChild(1).transform.Translate(Vector3.up * betweenSize);
    }

    public void SelfDestroy() {
        Destroy(gameObject);
    }

    void Start() => transform.Translate(Vector3.up * this.offSet);

    void FixedUpdate() {
        
        if(transform.position.x < Utils.BARRIERS_DESTROY_POSITION) {
            Destroy(gameObject);
        }

        transform.Translate(Velocity.Move());


        if(!isScore) {
            return;
        }
        
        if(PlaneController.GetInstance().GetFinalPostion() > transform.position.x) {
            UIController.GetInstance().AddScore();
            isScore = false;
        }

    }



    

}
