using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        //transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
