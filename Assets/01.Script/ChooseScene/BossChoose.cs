using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BossChoose : MonoBehaviour
{
    [SerializeField]
    private List<ChooseOption> _chooseOptions = new List<ChooseOption>();
    private ChooseOption _currentChooseOption;
    [SerializeField]
    private TextMeshProUGUI _explanText = null;
    [SerializeField]
    private TextMeshProUGUI _nameText = null;
    [SerializeField]
    private RawImage _image = null;
    private int index = 0;

    private void Start()
    {
        OptionUpdate(_chooseOptions[0]);
    }

    public void OptionUp()
    {
        index++;
        index = Mathf.Clamp(index, 0, _chooseOptions.Count - 1);
        OptionUpdate(_chooseOptions[index]);
    }

    public void OptionDown()
    {
        index--;
        index = Mathf.Clamp(index, 0, _chooseOptions.Count - 1);
        OptionUpdate(_chooseOptions[index]);
    }

    private void OptionUpdate(ChooseOption option)
    {
        _currentChooseOption = option;
        _nameText.SetText(_currentChooseOption.name);
        _image.texture = _currentChooseOption.imageTexture;
        _explanText.SetText(_currentChooseOption.explan);
        _explanText.gameObject.SetActive(true);
    }
}

[System.Serializable]
public struct ChooseOption
{
    public ChooseOptionEnum chooseOptionEnum;
    public Texture2D imageTexture;
    public string name;
    public string explan;
}

[System.Serializable]
public enum ChooseOptionEnum
{
    None,
    Frog,

}
