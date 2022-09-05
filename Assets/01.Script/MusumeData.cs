using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusumeData : MonoBehaviour
{
    private PlayerData _playerData = null;
    public PlayerData playerData
    {
        get => _playerData;
        set => _playerData = value;
    }
    private PlayerSkillData _playerSkillData = PlayerSkillData.NONE;
    private PlayerModelData _playerModelData = PlayerModelData.NONE;
}



