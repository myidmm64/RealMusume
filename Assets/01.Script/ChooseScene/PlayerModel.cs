using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerModel : MonoBehaviour
{
    private Action _deleteAction = null;
    [SerializeField]
    private PlayerInfo _playerInfo = null;
    [SerializeField]
    private PlayerModelData _playerModelData = PlayerModelData.NONE;
    [SerializeField]
    private PlayerSkillData _playerSkillData = PlayerSkillData.NONE;

    private PlayerData _playerData = null;
    public PlayerData playerData
    {
        get => _playerData;
        set => _playerData = value;
    }
    [SerializeField]
    private Transform _canvasTrm = null;

    private MusumeData _musumeData = null;

    private void Start()
    {
        _musumeData = GetComponent<MusumeData>();
        _musumeData.playerData = _playerData;
        _musumeData.playerModelData = _playerModelData;
        _musumeData.playerSkillData = _playerSkillData;

        PlayerInfo playerInfo = Instantiate(_playerInfo, _canvasTrm);
        playerInfo.SetPlayerInfomation(
            FileManager.GetTexture(_playerData.spriteFileName),
            $"{_playerData.playerName}",
            $"맵 억까 가중치 : {_playerData.mapLuck}\n보스 억까 가중치 : {_playerData.bossLuck}\n스피드 : {_playerData.speed}"
            );
        playerInfo.gameObject.SetActive(false);
        _playerInfo = playerInfo;

        GetComponent<Animator>().SetInteger("Idle", Random.Range(0, 4));
    }

    public void ActionAdd(Action action)
    {
        _deleteAction += action;
    }

    private void Update()
    {
        if(_playerInfo.gameObject.activeSelf == true)
        {
            _playerInfo.transform.position = Input.mousePosition;
        }
    }

    private void OnMouseDown()
    {
        _deleteAction?.Invoke();
    }

    private void OnMouseEnter()
    {
        _playerInfo.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        _playerInfo.gameObject.SetActive(false);
    }
}
