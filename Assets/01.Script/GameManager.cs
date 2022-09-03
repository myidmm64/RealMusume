using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<MusumeMove> _musumes = new List<MusumeMove>();
    [SerializeField]
    private List<PlayerData> _playerDa = new List<PlayerData>();

    private PlayerDatas _playerDatas;
    [SerializeField]
    private MusumeMove _playerPrefab = null;

    private void Awake()
    {
        /*PlayerDatas playerData = new PlayerDatas();
        playerData._playerDatas.Add(new PlayerData());
        playerData._playerDatas.Add(new PlayerData());
        string str = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(Application.dataPath + "/Savefile.json", str);*/
        string json = File.ReadAllText(Application.dataPath + "/Savefile.json");
        _playerDatas = JsonUtility.FromJson<PlayerDatas>(json);
        foreach(var a in _playerDatas.playerDatas)
        {
            MusumeMove musume = Instantiate(_playerPrefab);
            musume.Speed = a.speed;
            musume.BossLuck = a.bossLuck;
            musume.MapLuck = a.mapLuck;
            musume.Name = a.playerName;
            _musumes.Add(musume);
            _playerDa.Add(a);
        }
    }
}
