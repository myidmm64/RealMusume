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
    public string playerName = ""; // �÷��̾��� �̸�
    public string spriteFileName = ""; // �÷��̾� �󱼿� �� ���� ����
    public int mapLuck = 5; // �� ȿ���� ���� Ȯ�� ����ġ
    public int bossLuck = 5; //���� ȿ���� ���� Ȯ�� ����ġ
    public int speed = 10; //�÷��̾��� �ӵ�
}
