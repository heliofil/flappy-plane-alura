using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersGeneratorController : MonoBehaviour
{
    [SerializeField]
    private float timeToNew; 
    private float timer = 0;
    private static BarriersGeneratorController instance = null;

    public static BarriersGeneratorController GetInstance() {
        if(instance == null) {
            instance = FindObjectOfType<BarriersGeneratorController>();
        }

        return instance;

    }

    public void ReNew() {
        timer = 0;
        DestroyAllBarries();
    }

    private void SetNewTime() {
        timer = Random.Range(Utils.BARRIERS_TIME_TO_NEW_MIN,Utils.BARRIERS_TIME_TO_NEW_MAX);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer < 0 ) {
            float offSet = Random.Range(Utils.BARRIERS_OFFSET_MIN,Utils.BARRIERS_OFFSET_MAX);
            BarriersController.CreateInstance(transform.position,offSet);
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
