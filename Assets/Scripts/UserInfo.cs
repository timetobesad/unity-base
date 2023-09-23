using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public Transform target;
    Camera cam;
    public Vector3 screenPos;

    public Vector2 hpBarSize;

    public Texture2D hpBarTexture;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        screenPos = cam.WorldToScreenPoint(target.position);
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(screenPos.x - (hpBarSize.x / 2), Screen.height - screenPos.y - 70 - (hpBarSize.y / 2), hpBarSize.x, hpBarSize.y), hpBarTexture);
    }
}
