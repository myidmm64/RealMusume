using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _headMeshRenderer = null;

    public void FaceChange(Texture2D texture)
    {
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        _headMeshRenderer.material.mainTexture = texture;
    }
}
