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

    [SerializeField]
    private MusumeData _musumeData = null;
    [SerializeField]
    private FaceChanger _faceChanger = null;
    [SerializeField]
    private Animator _animator = null;
    private Texture2D _tex = null;
    public Texture2D Tex
    {
        get => _tex;
        set => _tex = value;
    }
    private bool _viewing = false;

    private void Start()
    {
        _musumeData.playerData = _playerData;
        _musumeData.playerModelData = _playerModelData;
        _musumeData.playerSkillData = _playerSkillData;
        ChooseDatas.Instance.playerDatas.Add(_musumeData);

        PlayerInfo playerInfo = Instantiate(_playerInfo, _canvasTrm);
        playerInfo.SetPlayerInfomation(
            _tex,
            $"{_playerData.playerName}",
            $"맵 억까 가중치 : {_playerData.mapLuck}\n보스 억까 가중치 : {_playerData.bossLuck}\n스피드 : {_playerData.speed}"
            );
        playerInfo.gameObject.SetActive(false);
        _playerInfo = playerInfo;

        _faceChanger.FaceChange(_tex);
        _animator.SetInteger("Idle", Random.Range(0, 4));
    }

    public void SkillDataChange(PlayerSkillData playerSkillData)
    {
        ChooseDatas.Instance.playerDatas.Remove(_musumeData);
        _musumeData.playerSkillData = playerSkillData;
        ChooseDatas.Instance.playerDatas.Add(_musumeData);
    }

    public void ActionAdd(Action action)
    {
        _deleteAction += action;
    }

    private void Update()
    {
        if(_viewing)
        {
            _playerInfo.transform.position = Input.mousePosition;
        }
    }

    private void OnMouseDown()
    {
        _deleteAction?.Invoke();
        ChooseDatas.Instance.playerDatas.Remove(_musumeData);
    }

    private void OnMouseEnter()
    {
        _playerInfo.gameObject.SetActive(true);
        _viewing = true;
    }

    private void OnMouseExit()
    {
        _playerInfo.gameObject.SetActive(false);
        _viewing = false;
    }
}
