using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersGeneratorController : MonoBehaviour
{

    private float timer;
    private float betweenSize;
    private float timeToNewMax;
   
    private static BarriersGeneratorController instance = null;

    public static BarriersGeneratorController GetInstance() {
        if(instance == null) {
            instance = FindObjectOfType<BarriersGeneratorController>();
        }

        return instance;

    }

    public void ReduceBetweenSize() {
        betweenSize -= Utils.BARRIERS_OFFSET_BETWEEN_REDUCE;
        betweenSize = Mathf.Max(betweenSize,Utils.BARRIERS_OFFSET_BETWEEN_MIN);
    }

    public void ReduceTimeToNewMax() {
        timeToNewMax -= Utils.BARRIERS_TIME_TO_NEW_REDUCE;
        if(timeToNewMax < Utils.BARRIERS_TIME_TO_NEW_MIN) {
            timeToNewMax = Utils.BARRIERS_TIME_TO_NEW_MIN + Utils.BARRIERS_TIME_TO_NEW_REDUCE;
        }
    }

    public void ReNew() {
        timer = 0;
        betweenSize = Utils.BARRIERS_OFFSET_BETWEEN_MAX;
        timeToNewMax = Utils.BARRIERS_TIME_TO_NEW_MAX;
        DestroyAllBarries();
    }

    private void SetNewTime() {
        timer = Random.Range(Utils.BARRIERS_TIME_TO_NEW_MIN,timeToNewMax);
    }

    private void Start() {
        timer = 0;
        betweenSize = Utils.BARRIERS_OFFSET_BETWEEN_MAX;
        timeToNewMax = Utils.BARRIERS_TIME_TO_NEW_MAX;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer < 0 ) {
            float offSet = Random.Range(Utils.BARRIERS_OFFSET_MIN,Utils.BARRIERS_OFFSET_MAX);
            BarriersController.CreateInstance(transform.position,offSet,betweenSize);
            SetNewTime();
        }
    }

    private void DestroyAllBarries() {

        BarriersController[] barriersList = FindObjectsOfType<BarriersController>();
        foreach(BarriersController barriers in barriersList) {
            barriers.SelfDestroy();
        }

    }

}
