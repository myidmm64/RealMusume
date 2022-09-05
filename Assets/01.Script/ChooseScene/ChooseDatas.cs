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
    private List<MusumeData> _playerDatas = new List<MusumeData>();
    public List<MusumeData> playerDatas
    {
        get => _playerDatas;
        set => _playerDatas = value;
    }
    [SerializeField]
    private BossChooseOptionEnum _bossChooseOptionEnum = BossChooseOptionEnum.NONE;
    public BossChooseOptionEnum bossChooseOptionEnum
    {
        get => _bossChooseOptionEnum;
        set => _bossChooseOptionEnum = value;
    }
    [SerializeField]
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
