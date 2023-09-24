using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildListObject : MonoBehaviour
{
    public Texture buildTxt;

    public GUISkin skin;

    private bool isShow;

    public BuildObj[] objects;

    private void OnGUI()
    {
        GUI.skin = skin;

        if (GUI.Button(new Rect(10, 10, 100, 100), buildTxt))
        {
            isShow = !isShow;
        }

        if (isShow) showBuildObjsList();
    }

    private void showBuildObjsList()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (GUI.Button(new Rect(100 + (100 * i), 10, 100, 100), objects[i].texture))
            {
                isShow = false;
                GetComponent<BuildManager>().setBuildObj(objects[i]);
            }
        }
    }
}
