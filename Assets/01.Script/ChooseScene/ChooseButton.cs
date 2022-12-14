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
    private GameObject[] _playerModelPrefabs = null;

    public Vector3 SpawnPos
    {
        get => _spawnPos;
        set => _spawnPos = value;
    }
    public GameObject[] PlayerModelPrefab
    {
        get => _playerModelPrefabs;
        set => _playerModelPrefabs = value;
    }
    private PlayerChoose _playerChoose = null;
    private Texture2D _tex = null;

    private void Awake()
    {
        _playerChoose = GameObject.FindObjectOfType<PlayerChoose>();
    }

    private void Start()
    {
        _tex = FileManager.GetTexture(_playerData.spriteFileName);
    }

    public void PlayerSpawn()
    {
        if (_playerChoose.Objects.Count >= 30) return;

        GameObject obj = Instantiate(_playerModelPrefabs[Random.Range(0, _playerModelPrefabs.Length)], _spawnPos, Quaternion.Euler(new Vector3(0f, 180f, 0f)));

        _playerChoose.Objects.Add(obj);
        _playerChoose.PlayerUpdate();

        obj.GetComponent<PlayerModel>().ActionAdd(() => { _playerChoose.DeletePlayer(obj); });
        obj.GetComponent<PlayerModel>().playerData = _playerData;
        obj.GetComponent<PlayerModel>().Tex = _tex;
    }
}
