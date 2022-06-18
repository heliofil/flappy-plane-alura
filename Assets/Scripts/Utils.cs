using UnityEngine;
public static class Utils {


    public const float BACKGROUND_VELOCITY = 0.01f;
    
    public const float BARRIERS_VELOCITY = 0.07f;
    public const float BARRIERS_OFFSET = 0f;
    public const float BARRIERS_DESTROY_POSITION = -14f;
    public const float BARRIERS_OFFSET_MAX = 2.1f;
    public const float BARRIERS_OFFSET_MIN = -1.7f;
    public const float BARRIERS_TIME_TO_NEW_MAX = 4f;
    public const float BARRIERS_TIME_TO_NEW_MIN = 2.5f;
    public const string BARRIER_PATH = "Prefabs/Barriers";

    public const float PLANE_JUMP = 3f;
    public const string PLANE_TAG = "Player";
    
    public const string UI_TAG = "GameController";

    public const string SCENE_CAVE1 = "CaveOne";

    public readonly static Vector3 PLANE_INIT = new Vector3(-3,3);

}