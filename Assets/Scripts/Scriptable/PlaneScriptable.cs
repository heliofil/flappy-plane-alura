using UnityEngine;

[CreateAssetMenu(fileName = "Plane Shared",menuName = "Shared / Plane")]
    public class PlaneScriptable:ScriptableObject {

    [SerializeField]
    private float jumpForce = Utils.PLANE_JUMP_FORCE;

    public float GetJumpForce() {
        return jumpForce;
    }


}