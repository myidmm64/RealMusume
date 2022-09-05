using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public static Texture2D GetTexture(string dataName)
    {
        Texture2D texture = new Texture2D(0, 0);
        byte[] byteTexture = null;
        try
        {
            byteTexture = File.ReadAllBytes(Application.dataPath + $"/Sprites/{dataName}.jpg");
        }
        catch
        {
            byteTexture = File.ReadAllBytes(Application.dataPath + $"/Sprites/{dataName}.png");
        }

        if (byteTexture.Length > 0)
        {
            texture.LoadImage(byteTexture);
        }
        return texture;
    }
}
