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

    private PlayerData _playerData = null;
    public PlayerData playerData
    {
        get => _playerData;
        set => _playerData = value;
    }

    private Texture2D _tex = null;
    public Texture2D tex
    {
        get => _tex;
        set => _tex = value;
    }
    [SerializeField]
    private Transform _canvasTrm = null;

    private void Start()
    {
        PlayerInfo playerInfo = Instantiate(_playerInfo, _canvasTrm);
        playerInfo.SetPlayerInfomation(
            _tex,
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
