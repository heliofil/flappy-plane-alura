using UnityEngine;
public static class Utils {


    public const int POINTS_TO_RESTART = 3;

    public const float BACKGROUND_VELOCITY = 0.01f;
    public const float BACKGROUND_ACCELERATION = 0.01f;
    public const float BARRIERS_VELOCITY = 0.07f;
    public const float BARRIERS_ACCELERATION = 0.03f;
    public const float BARRIERS_OFFSET = 0f;
    public const float BARRIERS_DESTROY_POSITION = -44f;
    public const float BARRIERS_OFFSET_MAX = 2f;
    public const float BARRIERS_OFFSET_MIN = -1f;
    public const float BARRIERS_OFFSET_BETWEEN_REDUCE = 0.2f;
    public const float BARRIERS_OFFSET_BETWEEN_MAX = 4.8f;
    public const float BARRIERS_OFFSET_BETWEEN_MIN = 4f;
    public const float BARRIERS_TIME_TO_NEW_REDUCE = 0.6f;
    public const float BARRIERS_TIME_TO_NEW_MAX = 3.2f;
    public const float BARRIERS_TIME_TO_NEW_MIN = 1.2f;
    public const float PLANE_UP_LIMIT = 5.5f;
    public const float PLANE_JUMP_FORCE = 3f;
    public const float DELAY_START = 0.3f;

    public const string PLANE_TAG = "Plane";
    public const string PLANE2_TAG = "Plane2";
    public const string BARRIERS_GENERATOR_TAG = "Respawn";
    public const string BARRIERS_GENERATOR2_TAG = "Respawn2";
    public const string PLAYER_TAG = "Player";
    public const string PLAYER2_TAG = "Player2";
    public const string BLEND_ANIMATOR = "Blend";
    public const string FLY_ANIMATOR = "Fly";
    public const string BACKSCENE_TAG = "BackScene";
    public const string UI_TAG = "GameController";
    public const string SCENE_CAVE1 = "CaveOne";
    public const string SCENE_CAVE2 = "CaveCoop";
    public const string BUTTON_FIRE_ONE = "Fire1";
    public const string BUTTON_JUMP = "Jump";
    public const string PLAYER_SAVE_RECORD_SCORE = "RECORD_SCORE";
    public const string HELP_BUTTON_JUMP = "Player One Use Space bar";
    public const string HELP_BUTTON_FIRE_ONE = "Player One Use Mouse";

    private static readonly int[] LEVEL_PASS_LIST = new int[4] { 14,26,38,42 };
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