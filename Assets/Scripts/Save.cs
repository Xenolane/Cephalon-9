using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class Save
{

    public static void SavePlayerData(PlayerSave pSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.savfile", FileMode.Create);

        PlayerData data = new PlayerData(pSave);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static float[] LoadPlayer()
    {
        if (File.Exists(Application.persistentDataPath + "/player.savfile"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.savfile", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();
            return data.statVal;
        }
        else
        {
            Debug.Log("file does not exits! Creating new one!");
            return new float[17];
        }
    }

}

[Serializable]
public class PlayerData
{
    public float[] statVal;
    public PlayerData(PlayerSave pSave)
    {
        //Variables

        statVal = new float[17];
        statVal[0] = pSave.statVal_love;
        statVal[1] = pSave.statVal_charisma;
        statVal[2] = pSave.statVal_intellect;
        statVal[3] = pSave.statVal_loveEXP;
        statVal[4] = pSave.statVal_charismaEXP;
        statVal[5] = pSave.statVal_intellectEXP;
        statVal[6] = pSave.statVal_paper;
        statVal[7] = pSave.gameExists;
        statVal[8] = pSave.npc_gabbi;
        statVal[9] = pSave.setting_quality;
        statVal[10] = pSave.setting_resolutionIndex;
        statVal[11] = pSave.setting_isFullscreen;
        statVal[12] = pSave.setting_masterVolume;
        statVal[13] = pSave.setting_soundVolume;
        statVal[14] = pSave.setting_musicVolume;
        statVal[15] = pSave.progressID1;
        statVal[16] = pSave.stateID1;
    }


}