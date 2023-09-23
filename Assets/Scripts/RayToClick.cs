using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToClick : MonoBehaviour
{
    Camera cam;
    Vector3 pos = new Vector3(200, 200, 0);


    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(pos);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(200, 200, 0)), out hit, 200))
        {

            Debug.Log(hit.distance);
        }
    }
}
