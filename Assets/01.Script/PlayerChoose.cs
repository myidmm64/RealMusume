using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
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

    private void Awake()
    {
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
                playerSpawner.playerModelPrefab = _playerModelPrefab;
                playerSpawner.texture = tex;
                button.onClick.AddListener(playerSpawner.PlayerSpawn);
                image.texture = tex;
                _index++;
            }
            TextMeshProUGUI text = button.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            text.SetText(a.playerName);
        }
    }
}

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerModelPrefab = null;
    public Texture2D texture = null;

    public void PlayerSpawn()
    {
        Debug.Log("캐릭터 생성");
        GameObject obj = Instantiate(playerModelPrefab);
        if(texture != null)
            obj.GetComponent<FaceChanger>().FaceChange(texture);
    }
}
