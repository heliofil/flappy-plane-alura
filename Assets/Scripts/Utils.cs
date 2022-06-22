using UnityEngine;
public static class Utils {


    public const float BACKGROUND_VELOCITY = 0.01f;
    public const float BACKGROUND_ACCELERATION = 0.01f;

    public const float BARRIERS_VELOCITY = 0.07f;
    public const float BARRIERS_ACCELERATION = 0.03f;


    public const float BARRIERS_OFFSET = 0f;
    public const float BARRIERS_DESTROY_POSITION = -14f;
    public const float BARRIERS_OFFSET_MAX = 2.1f;
    public const float BARRIERS_OFFSET_MIN = -1.7f;
    public const float BARRIERS_OFFSET_BETWEEN_REDUCE = 0.25f;
    public const float BARRIERS_OFFSET_BETWEEN_MAX = 5f;
    public const float BARRIERS_OFFSET_BETWEEN_MIN = 4f;
    public const float BARRIERS_TIME_TO_NEW_REDUCE = 0.6f;
    public const float BARRIERS_TIME_TO_NEW_MAX = 4f;
    public const float BARRIERS_TIME_TO_NEW_MIN = 1.1f;
    public const string BARRIER_PATH = "Prefabs/Barriers";

    public const int LEVEL_PASS = 7;

    public const float PLANE_JUMP = 3f;
    public const string PLANE_TAG = "Player";
    
    public const string BACKSCENE_TAG = "BackScene";

    public const string UI_TAG = "GameController";

    public const string SCENE_CAVE1 = "CaveOne";

    public const string BUTTON_FIRE_ONE = "Fire1";

    public const string PLAYER_SAVE_RECORD_SCORE = "RECORD_SCORE";


    public readonly static Vector3 PLANE_INIT = new Vector3(-3,3);

}