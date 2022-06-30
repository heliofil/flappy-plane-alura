using UnityEngine;
public static class Utils {


    public const float BACKGROUND_VELOCITY = 0.01f;
    public const float BACKGROUND_ACCELERATION = 0.01f;

    public const float BARRIERS_VELOCITY = 0.07f;
    public const float BARRIERS_ACCELERATION = 0.03f;


    public const float BARRIERS_OFFSET = 0f;
    public const float BARRIERS_DESTROY_POSITION = -44f;
    public const float BARRIERS_OFFSET_MAX = 2.1f;
    public const float BARRIERS_OFFSET_MIN = -1.7f;
    public const float BARRIERS_OFFSET_BETWEEN_REDUCE = 0.2f;
    public const float BARRIERS_OFFSET_BETWEEN_MAX = 4.8f;
    public const float BARRIERS_OFFSET_BETWEEN_MIN = 4f;
    public const float BARRIERS_TIME_TO_NEW_REDUCE = 0.6f;
    public const float BARRIERS_TIME_TO_NEW_MAX = 3.6f;
    public const float BARRIERS_TIME_TO_NEW_MIN = 0.8f;


    public const float PLANE_UP_LIMIT = 5.5f;
    public const float PLANE_JUMP_FORCE = 3f;
    public const string PLANE_TAG = "Player";
    public static string PLANE2_TAG = "Player2";
    public static string BARRIERS_GENERATOR_TAG = "Respawn";
    public static string BARRIERS_GENERATOR2_TAG = "Respawn2";

    public const string BACKSCENE_TAG = "BackScene";

    public const string UI_TAG = "GameController";

    public const string SCENE_CAVE1 = "CaveOne";

    public const string BUTTON_FIRE_ONE = "Fire1";

    public const string BUTTON_JUMP = "Jump";

    public const string PLAYER_SAVE_RECORD_SCORE = "RECORD_SCORE";

    private static readonly int[] LEVEL_PASS_LIST = new int[4] { 7,13,19,21 };

    public static readonly GameObject BARRIER_LOAD = Resources.Load<GameObject>("Prefabs/Barriers");

    public static readonly Sprite MEDAL_GOLD_LOAD = Resources.Load<Sprite>("Images/medalGold");
    public static readonly Sprite MEDAL_SILVER_LOAD = Resources.Load<Sprite>("Images/medalSilver");
    public static readonly Sprite MEDAL_BRONZE_LOAD = Resources.Load<Sprite>("Images/medalBronze");

    private static int actualLevel = 0;
    

    public static bool IsNextLevel(int score) {

        if(score < LEVEL_PASS_LIST[actualLevel]) {
            return false;
        }

        if((actualLevel + 1) < LEVEL_PASS_LIST.Length) {
            actualLevel++;
        }

        return true;


    }
    public static void InitLevel() {
        actualLevel = 0;

    }

    

}