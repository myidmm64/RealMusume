using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerChoose : MonoBehaviour
{
    private PlayerDatas _playerDatas;
    [SerializeField]
    private Button _playerChooseButtonPrefab = null;
    [SerializeField]
    private Transform _trm = null;


    [SerializeField]
    private GameObject _playerModelPrefab = null;

    private int _index = 0;
    private int _playerPositionIndex = 0;

    [field: SerializeField]
    private UnityEvent OnPlayerChange = null;
    private Camera _mainCam = null;

    private void Awake()
    {
        _mainCam = Camera.main;

        string json = File.ReadAllText(Application.dataPath + "/Savefile.json");
        _playerDatas = JsonUtility.FromJson<PlayerDatas>(json);
        foreach (var a in _playerDatas.playerDatas)
        {
            Button button = Instantiate(_playerChooseButtonPrefab, _trm);
            RawImage image = button.GetComponent<RawImage>();
            if (a.spriteFileName != "")
            {
                Texture2D tex = Resources.Load($"Sprites/{a.spriteFileName}") as Texture2D;
                PlayerSpawner playerSpawner = button.gameObject.AddComponent<PlayerSpawner>();
                button.onClick.AddListener(() => PlayerUpdate(playerSpawner));
                button.onClick.AddListener(playerSpawner.PlayerSpawn);
                playerSpawner.PlayerModelPrefab = _playerModelPrefab;
                playerSpawner.texture2D = tex;
                image.texture = tex;
                _index++;
            }
            TextMeshProUGUI text = button.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            text.SetText(a.playerName);
        }
    }

    public void PlayerUpdate(PlayerSpawner playerSpawner)
    {
        OnPlayerChange?.Invoke();
        _playerPositionIndex++;
        NextPosition(playerSpawner);
    }

    private Vector3 NextPosition(PlayerSpawner playerSpawner)
    {
        Vector3 d = new Vector3(Screen.currentResolution.width * -1f, 0f, 0f);
        Vector3 leftLimit = _mainCam.ScreenToWorldPoint(d);
        Vector3 nextPos = leftLimit * _playerPositionIndex;
        playerSpawner.SpawnPos = nextPos;
        return nextPos;
    }
}

public class PlayerSpawner : MonoBehaviour
{
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

    public void PlayerSpawn()
    {
        Debug.Log("캐릭터 생성");
        GameObject obj = Instantiate(_playerModelPrefab, _spawnPos, Quaternion.identity);
        if(_texture != null)
            obj.GetComponent<FaceChanger>().FaceChange(_texture);
    }
}
