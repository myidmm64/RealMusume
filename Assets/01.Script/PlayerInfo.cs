using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    private RawImage _image = null;
    [SerializeField]
    private TextMeshProUGUI _nameText = null;
    [SerializeField]
    private TextMeshProUGUI _infoText = null;

    public void SetPlayerInfomation(Texture2D tex, string name, string info)
    {
        _image.texture = tex;
        _nameText.SetText(name);
        _infoText.SetText(info);
    }
}
