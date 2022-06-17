using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersController :MonoBehaviour {

    [SerializeField]
    private float offSet;


    public static void CreateInstance(Vector3 position,float offet) {
        GameObject gameObject = Instantiate
            (Resources.Load<GameObject>(Utils.BARRIER_PATH),
            position,
            Quaternion.identity);
        
        gameObject.GetComponent<BarriersController>().SetOffset(offet);
        gameObject.GetComponent<MovimentController>().SetVelocity(Utils.BARRIERS_VELOCITY);
    }

    public void SetOffset(float offet) {
   
        this.offSet = offet;
    }

    // Start is called before the first frame update
    void Start() => transform.Translate(Vector3.up * this.offSet);

    void Update() {
        if(transform.position.x < Utils.BARRIERS_DESTROY_POSITION) {
            Destroy(gameObject);
        }
    }

}
