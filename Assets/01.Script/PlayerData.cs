using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDatas
{
    public List<PlayerData> playerDatas = new List<PlayerData>();
}

[System.Serializable]
public class PlayerData
{
    public string playerName = ""; // 플레이어의 이름
    public string spriteFileName = ""; // 플레이어 얼굴에 들어갈 사진 제목
    public int mapLuck = 5; // 맵 효과를 받을 확률 가중치
    public int bossLuck = 5; //보스 효과를 받을 확률 가중치
    public int speed = 10; //플레이어의 속도
}
