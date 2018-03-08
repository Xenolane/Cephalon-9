using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMenu : MonoBehaviour {

    public void SaveGame()
    {
        PlayerSave.singleton.SaveGame();
    }

    public void LoadGame()
    {
        PlayerSave.singleton.LoadGame();
    }
}
