using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MapChoose : MonoBehaviour
{
    [SerializeField]
    private List<MapChooseOption> _chooseOptions = new List<MapChooseOption>();
    private MapChooseOption _currentChooseOption;
    [SerializeField]
    private TextMeshProUGUI _explanText = null;
    [SerializeField]
    private TextMeshProUGUI _nameText = null;
    [SerializeField]
    private RawImage _image = null;
    private int index = 0;

    [SerializeField]
    private ChooseDatas _chooseDataSO = null;

    private void Start()
    {
        OptionUpdate(_chooseOptions[0]);
    }

    public void OptionUp()
    {
        index++;
        index = index % _chooseOptions.Count;
        OptionUpdate(_chooseOptions[index]);
    }

    public void OptionDown()
    {
        index--;
        if (index <= -1)
            index = _chooseOptions.Count - 1;
        OptionUpdate(_chooseOptions[index]);
    }

    private void OptionUpdate(MapChooseOption option)
    {
        _currentChooseOption = option;
        _nameText.SetText(_currentChooseOption.name);
        _image.texture = _currentChooseOption.imageTexture;
        _explanText.SetText(_currentChooseOption.explan);
        _explanText.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _chooseDataSO.mapChooseOptionEnum = _currentChooseOption.chooseOptionEnum;
    }
}
[System.Serializable]
public struct MapChooseOption
{
    public MapChooseOptionEnum chooseOptionEnum;
    public Texture2D imageTexture;
    public string name;
    public string explan;
}

[System.Serializable]
public enum MapChooseOptionEnum
{
    None,
    Frog,

}
