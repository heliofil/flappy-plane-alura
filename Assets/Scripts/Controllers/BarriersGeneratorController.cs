using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersGeneratorController : MonoBehaviour
{

    private float timer;
    private float betweenSize;
    private float timeToNewMax;
    private bool generateBarries;

    public bool AutoPlayer;
   
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

    public void StartPlay() {
        timer = 0;
        betweenSize = Utils.BARRIERS_OFFSET_BETWEEN_MAX;
        timeToNewMax = Utils.BARRIERS_TIME_TO_NEW_MAX;
        generateBarries = true;
    }

    public void ReNew() {
        StartPlay();
        DestroyAllBarries();
    }

    public void StopAllBarries() {
        generateBarries = false;
        BarriersController[] barriersList = GetComponentsInChildren<BarriersController>();
        foreach(BarriersController barriers in barriersList) {
            barriers.enabled = false;
        }

    }

    private void SetNewTime() {
        timer = Random.Range(Utils.BARRIERS_TIME_TO_NEW_MIN,timeToNewMax);
    }


    private void Awake() {
        generateBarries = false;
    }

    private void Start() {
        StartCoroutine(CreateBarriers());
    }

    // Update is called once per frame
    private IEnumerator CreateBarriers()
    {
        while(true) {
            yield return new WaitForSeconds(timer);
            if(generateBarries) {
                float offSet = Random.Range(Utils.BARRIERS_OFFSET_MIN,Utils.BARRIERS_OFFSET_MAX);
                if(AutoPlayer) {
                    offSet = Utils.BARRIERS_OFFSET_MAX/2;
                }
                BarriersController.CreateInstance(transform.position,offSet,betweenSize,transform);
                SetNewTime();
            }
        }
    }

    private void DestroyAllBarries() {
        BarriersController[] barriersList = GetComponentsInChildren<BarriersController>();
        foreach(BarriersController barriers in barriersList) {
            barriers.SelfDestroy();
        }

    }

}
