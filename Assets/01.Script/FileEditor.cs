using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FileEditor : MonoBehaviour
{

    [ContextMenu("파일 생성")]
    public void FileEdit()
    {
        PlayerDatas playerdatas = new PlayerDatas();
        for (int i = 0; i < 4; i++)
        {
            PlayerData playerData = new PlayerData();
            playerdatas.playerDatas.Add(playerData);
        }
        File.WriteAllText(Application.dataPath + "/Savefile" + "/Savefile.json", JsonUtility.ToJson(playerdatas, true));
    }

    public void SceneChange()
    {
        SceneManager.LoadScene(2);
    }
}
