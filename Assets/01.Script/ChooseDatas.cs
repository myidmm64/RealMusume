using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDatas : MonoBehaviour
{
    [SerializeField]
    private List<PlayerData> _playerDatas = new List<PlayerData>();
    public List<PlayerData> playerDatas
    {
        get => _playerDatas;
        set => _playerDatas = value;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
