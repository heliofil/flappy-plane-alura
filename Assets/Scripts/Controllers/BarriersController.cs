using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersController :MonoBehaviour {

    [SerializeField]
    private float offSet;
    private bool isScore = true;
    

    public static void CreateInstance(Vector3 position,float offet,float betweenSize,float velocity) {
        GameObject gameObject = Instantiate
            (Resources.Load<GameObject>(Utils.BARRIER_PATH),
            position,
            Quaternion.identity);

        gameObject.tag = Utils.BACKSCENE_TAG;

        BarriersController barriersController = gameObject.GetComponent<BarriersController>();
        barriersController.SetOffset(offet);
        barriersController.SetBetweenSize(betweenSize);
        gameObject.GetComponent<MovimentController>().SetVelocity(velocity);
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

    void Update() {
        
        if((PlaneController.GetInstance().GetFinalPostion() > transform.position.x) && (isScore)) {
            UIController.GetInstance().AddScore();
            isScore = false;
        }
        
        
        if(transform.position.x < Utils.BARRIERS_DESTROY_POSITION) {
            Destroy(gameObject);
        }
    }



    

}
