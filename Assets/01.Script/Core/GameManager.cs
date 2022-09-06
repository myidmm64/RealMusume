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
    private List<ModelData> _modelDatas = null;

    [SerializeField]
    private ChooseDatas _chooseDataSO = null;

    private void Awake()
    {
        _playerDatas = _chooseDataSO.playerDatas;
        foreach(var a in _playerDatas)
        {
            GameObject obj = GetObject(a.playerModelData);
            MusumeMove musume = obj.GetComponent<MusumeMove>();
            musume.Speed = a.playerData.speed;
            musume.BossLuck = a.playerData.bossLuck;
            musume.MapLuck = a.playerData.mapLuck;
            musume.Name = a.playerData.playerName;
            musume.GetComponent<FaceChanger>().FaceChange(FileManager.GetTexture(a.playerData.spriteFileName));
            _musumes.Add(musume);
        }
    }

    private GameObject GetObject(PlayerModelData playerModelData)
    {
        for(int i = 0; i<_modelDatas.Count; i++)
        {
            if(playerModelData == _modelDatas[i].playerModelData)
            {
                return _modelDatas[i].prefab;
            }
        }
        return null;
    }
}

[System.Serializable]
public struct ModelData
{
    [SerializeField]
    public PlayerModelData playerModelData;
    [SerializeField]
    public GameObject prefab;
}
