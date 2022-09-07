using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform _firstPositionStart = null;
    [SerializeField]
    private Transform _firstPositionEnd = null;
    [SerializeField]
    private List<MusumeMove> _musumes = new List<MusumeMove>();
    [SerializeField]
    private List<MusumeData> _playerDatas = new List<MusumeData>();

    [SerializeField]
    private List<ModelData> _modelDatas = null;

    [SerializeField]
    private ChooseDatas _chooseDataSO = null;

    private List<Vector3> _musumePositions = new List<Vector3>();
    private int _positionIndex = 0;

    private void Awake()
    {
        _playerDatas = _chooseDataSO.playerDatas;
        SetPlace();
        foreach (var a in _playerDatas)
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

    private void SetPlace()
    {
        float percent = 1f / _playerDatas.Count;
        for(int i = 0; i< _playerDatas.Count; i++)
        {
            _musumePositions.Add(Vector3.Lerp(_firstPositionStart.position,
                _firstPositionEnd.position, i * percent));
        }
    }

    private GameObject GetObject(PlayerModelData playerModelData)
    {
        GameObject obj = null;
        for (int i = 0; i<_modelDatas.Count; i++)
        {
            if(playerModelData == _modelDatas[i].playerModelData)
            {
                obj = Instantiate(_modelDatas[i].prefab, _musumePositions[_positionIndex], Quaternion.identity);
                _positionIndex++;
                break;
            }
        }
        if(obj == null)
        {
            obj = Instantiate(_modelDatas[0].prefab, _musumePositions[0], Quaternion.identity);
        }
        return obj;
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
