using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{
    [SerializeField]
    private List<SpriteRenderer> _faceSprites = null;

    public void FaceChange(Texture2D texture)
    {
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        for (int i = 0; i< _faceSprites.Count; i++)
        {
            _faceSprites[i].sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        }
    }
}
