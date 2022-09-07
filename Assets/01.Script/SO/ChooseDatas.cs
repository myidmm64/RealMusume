using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/ChooseDatas")]
public class ChooseDatas : ScriptableObject
{
    public void ResetSO()
    {
        _playerDatas.Clear();
        _bossChooseOptionEnum = BossChooseOptionEnum.NONE;
        _mapChooseOptionEnum = MapChooseOptionEnum.None;
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
}
