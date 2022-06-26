using UnityEngine;

[CreateAssetMenu(fileName = "Moviment Shared",menuName = "Shared / Moviment")]
    public class MovimentScriptable:ScriptableObject {

    public float Value;

    public void Accelerate(float acceletation) {
        this.Value += acceletation;
    }

    public Vector3 Move() {
        return Vector3.left * this.Value;
    }



}