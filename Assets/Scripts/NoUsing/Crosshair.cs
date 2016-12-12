using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
    public Texture2D crosshairImage;
    public float CrosshairSize = 100f;
    void OnGUI()
    {
        float xMin = (Screen.width / 2) - CrosshairSize / 2;
        float yMin = (Screen.height / 2) - CrosshairSize / 2;
        GUI.DrawTexture(new Rect(xMin, yMin, CrosshairSize, CrosshairSize), crosshairImage);
    }
}
