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
    private List<PlayerData> _playerDatas = new List<PlayerData>();

    [SerializeField]
    private MusumeMove _playerPrefab = null;

    private void Awake()
    {
        _playerDatas = GameObject.FindObjectOfType<ChooseDatas>().playerDatas;

        foreach(var a in _playerDatas)
        {
            MusumeMove musume = Instantiate(_playerPrefab);
            musume.Speed = a.speed;
            musume.BossLuck = a.bossLuck;
            musume.MapLuck = a.mapLuck;
            musume.Name = a.playerName;
            musume.GetComponent<FaceChanger>().FaceChange(FileManager.GetTexture(a.spriteFileName));
            _musumes.Add(musume);
        }
    }
}
