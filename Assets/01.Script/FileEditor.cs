using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FileEditor : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FileEdit();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void FileEdit()
    {
        PlayerDatas playerdatas = new PlayerDatas();
        for (int i = 0; i < 4; i++)
        {
            PlayerData playerData = new PlayerData();
            playerdatas.playerDatas.Add(playerData);
        }
        File.WriteAllText(Application.dataPath + "/Savefile" + "/Savefile.json", JsonUtility.ToJson(playerdatas, true));
    }
}
