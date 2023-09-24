using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTransEditor : MonoBehaviour
{
    public Transform obj;

    public float speed = 3;

    public rangeAngle[] ranges;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Keypad4)) obj.Rotate(0, speed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.Keypad6)) obj.Rotate(0, -speed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            foreach (rangeAngle range in ranges)
            {
                if (isRange(obj.transform.rotation.y, range))
                {
                    obj.Rotate(new Vector3(0, (range.max - obj.transform.eulerAngles.y), 0));
                }
            }
        }
    }

    private void OnGUI()
    {

    }

    private bool isRange(float val, rangeAngle range)
    {
        if (val >= range.min && val < range.max)
            return true;
        else
            return false;
    }
}

[System.Serializable]
public struct rangeAngle
{
    public int min;
    public int max;
}