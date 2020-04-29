using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{

    private LineRenderer lineRender;
    void Start()
    {
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            lineRender = new GameObject("Line").AddComponent<LineRenderer>();
            Debug.Log(Input.mousePosition);
        }

    }

}
