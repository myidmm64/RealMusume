using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseDatas : MonoBehaviour
{
    private static ChooseDatas _instance = null;
    public static ChooseDatas Instance
    {
        get
        {
            return _instance;
        }
    }
    [SerializeField]
    private List<PlayerData> _playerDatas = new List<PlayerData>();
    public List<PlayerData> playerDatas
    {
        get => _playerDatas;
        set => _playerDatas = value;
    }
    private BossChooseOptionEnum _bossChooseOptionEnum = BossChooseOptionEnum.None;
    public BossChooseOptionEnum bossChooseOptionEnum
    {
        get => _bossChooseOptionEnum;
        set => _bossChooseOptionEnum = value;
    }
    private MapChooseOptionEnum _mapChooseOptionEnum = MapChooseOptionEnum.None;
    public MapChooseOptionEnum mapChooseOptionEnum
    {
        get => _mapChooseOptionEnum;
        set => _mapChooseOptionEnum = value;
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }

}
