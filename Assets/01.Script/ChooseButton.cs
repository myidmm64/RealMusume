using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseButton : MonoBehaviour
{
    private PlayerData _playerData = null;
    public PlayerData playerData
    {
        get => _playerData;
        set => _playerData = value;
    }

    private Vector3 _spawnPos = Vector3.zero;
    private GameObject _playerModelPrefab = null;
    private Texture2D _texture = null;

    public Vector3 SpawnPos
    {
        get => _spawnPos;
        set => _spawnPos = value;
    }
    public GameObject PlayerModelPrefab
    {
        get => _playerModelPrefab;
        set => _playerModelPrefab = value;
    }
    public Texture2D texture2D
    {
        get => _texture;
        set => _texture = value;
    }

    private ChooseDatas _chooseDatas = null;
    private PlayerChoose _playerChoose = null;

    private void Awake()
    {
        _chooseDatas = GameObject.FindObjectOfType<ChooseDatas>();
        _playerChoose = GameObject.FindObjectOfType<PlayerChoose>();
    }

    public void PlayerSpawn()
    {
        if (_playerChoose.Objects.Count >= 30) return;

        GameObject obj = Instantiate(_playerModelPrefab, _spawnPos, Quaternion.Euler(new Vector3(0f, 180f, 0f)));

        _chooseDatas.playerDatas.Add(_playerData);
        _playerChoose.Objects.Add(obj);
        _playerChoose.PlayerUpdate();

        obj.GetComponent<FaceChanger>().FaceChange(_texture);
        obj.GetComponent<PlayerModel>().ActionAdd(() => { _playerChoose.DeletePlayer(obj); });
        obj.GetComponent<PlayerModel>().ActionAdd(() => { _chooseDatas.playerDatas.Remove(_playerData); });
        obj.GetComponent<PlayerModel>().tex = _texture;
        obj.GetComponent<PlayerModel>().playerData = _playerData;
    }
}
