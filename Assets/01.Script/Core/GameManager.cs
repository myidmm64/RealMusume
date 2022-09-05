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
    private List<MusumeData> _playerDatas = new List<MusumeData>();

    [SerializeField]
    private MusumeMove _playerPrefab = null;

    private void Awake()
    {
        _playerDatas = ChooseDatas.Instance.playerDatas;
        foreach(var a in _playerDatas)
        {
            MusumeMove musume = Instantiate(_playerPrefab);
            musume.Speed = a.playerData.speed;
            musume.BossLuck = a.playerData.bossLuck;
            musume.MapLuck = a.playerData.mapLuck;
            musume.Name = a.playerData.playerName;
            musume.GetComponent<FaceChanger>().FaceChange(FileManager.GetTexture(a.playerData.spriteFileName));
            _musumes.Add(musume);
        }
    }
}
