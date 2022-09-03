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

    private int _playerPositionIndex = 0;
    private int _playerPositionLeft = 1;
    private Vector3 _startPos = new Vector3(0, -1.63f, 3.1f);

    [SerializeField]
    private List<GameObject> _objects = new List<GameObject>();
    public List<GameObject> Objects
    {
        get => _objects;
        set => _objects = value;
    }

    [field: SerializeField]
    private UnityEvent OnPlayerChange = null;

    private void Awake()
    {
        string json = File.ReadAllText(Application.dataPath + "/Savefile/Savefile.json");
        _playerDatas = JsonUtility.FromJson<PlayerDatas>(json);
        foreach (var a in _playerDatas.playerDatas)
        {
            Button button = Instantiate(_playerChooseButtonPrefab, _trm);
            RawImage image = button.GetComponent<RawImage>();
            Texture2D tex = GetTexture(a.spriteFileName);
            image.texture = tex;
            ChooseButton chooseButton = button.GetComponent<ChooseButton>();
            chooseButton.playerData = a;
            chooseButton.PlayerModelPrefab = _playerModelPrefab;
            chooseButton.texture2D = tex;
            TextMeshProUGUI text = button.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            text.SetText(a.playerName);
        }
    }

    public Texture2D GetTexture(string dataName)
    {
        Texture2D texture = new Texture2D(0, 0);
        byte[] byteTexture = null;
        try
        {
            byteTexture = File.ReadAllBytes(Application.dataPath + $"/Sprites/{dataName}.jpg");
        }
        catch
        {
            byteTexture = File.ReadAllBytes(Application.dataPath + $"/Sprites/{dataName}.png");
        }

        if (byteTexture.Length > 0)
        {
            texture.LoadImage(byteTexture);
        }
        return texture;
    }

    public void PlayerUpdate()
    {
        OnPlayerChange?.Invoke();

        _playerPositionIndex = 0;
        _playerPositionLeft = 1;
        for(int i = 0; i<_objects.Count; i++)
        {
            _objects[i].transform.position = NextPosition();
        }
    }

    public void DeletePlayer(GameObject obj)
    {
        Objects.Remove(obj);
        Destroy(obj);
        PlayerUpdate();
    }

    private Vector3 NextPosition()
    {
        Vector3 nextPos = Vector3.zero;
        if (_playerPositionIndex == 0)
            nextPos = _startPos;
        else
        {
            nextPos = _startPos + Vector3.right *_playerPositionLeft;
            nextPos.z += 0.3f * _playerPositionLeft;
            if (_playerPositionIndex % 2 == 0)
            {
                nextPos.x *= -1f;
                _playerPositionLeft++;
            }
        }
        _playerPositionIndex++;
        return nextPos;
    }
}