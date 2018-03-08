using System.Collections;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    public static PlayerSave singleton;

    [HideInInspector]
    public float gameExists;

    // Contains skill levels and experiance
    #region Stats
    [HideInInspector]
    public float statVal_love;
    [HideInInspector]
    public float statVal_intellect;
    [HideInInspector]
    public float statVal_charisma;

    [HideInInspector]
    public float statVal_loveEXP;
    [HideInInspector]
    public float statVal_charismaEXP;
    [HideInInspector]
    public float statVal_intellectEXP;
    [HideInInspector]
    public float statVal_paper;
    #endregion

    // Contains Missions States and Mission Progress variables
    #region Missions
    public float progressID1 = 8;
    public float stateID1 = 0;
    #endregion                  

    // Contains Dialog ID(s) for the NPCs
    #region Npc
    [HideInInspector]
    public float npc_gabbi;
    #endregion

    // Saves changes made in the settings menu (e.g. volume, resolution etc)
    #region Settings
    [HideInInspector]
    public float setting_quality;
    [HideInInspector]
    public float setting_resolutionIndex;
    [HideInInspector]
    public float setting_isFullscreen;
    [HideInInspector]
    public float setting_masterVolume;
    [HideInInspector]
    public float setting_musicVolume;
    [HideInInspector]
    public float setting_soundVolume;
    #endregion
    

    void Awake()
    {
        singleton = this;
    }

    public void SaveGame()
    {
        Save.SavePlayerData(this);
        print("Game Saved!");
    }

    public void LoadGame()
    {
        float[] loadedStats = Save.LoadPlayer();

        print(loadedStats.Length);

        statVal_love = loadedStats[0];
        statVal_charisma = loadedStats[1];
        statVal_intellect = loadedStats[2];
        statVal_loveEXP = loadedStats[3];
        statVal_charismaEXP = loadedStats[4];
        statVal_intellectEXP = loadedStats[5];
        statVal_paper = loadedStats[6];
        gameExists = loadedStats[7];
        npc_gabbi = loadedStats[8];
        setting_quality = loadedStats[9];
        setting_resolutionIndex = loadedStats[10];
        setting_isFullscreen = loadedStats[11];
        setting_masterVolume = loadedStats[12];
        setting_soundVolume = loadedStats[13];
        setting_musicVolume = loadedStats[14];
        progressID1 = loadedStats[15];
        stateID1 = loadedStats[16];

    }

}
