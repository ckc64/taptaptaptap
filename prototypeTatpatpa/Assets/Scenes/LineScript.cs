using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{

    private new Camera camera;
    private LineRenderer lineRender;
    public Material lineMaterial;
    public float lineWidth;
    public float lineDepth;
    private Vector3? lineStartPoint = null;
    void Start()
    {
        camera = GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse click");

            lineStartPoint = GetCameraPoint();

        } else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Release");
            if (!lineStartPoint.HasValue)
            {
                return;
            }
            var lineEndPoint = GetCameraPoint();

       
                lineRender = new GameObject("Line").AddComponent<LineRenderer>();
                addCollider(lineStartPoint.Value, lineEndPoint.Value);

                lineRender.material = lineMaterial;
                lineRender.SetPositions(new Vector3[] { lineStartPoint.Value, lineEndPoint.Value });
                lineRender.startWidth = lineWidth;
                lineRender.endWidth = lineWidth;

                lineStartPoint = null;
            

           

           
        }
      
    }


    private void addCollider(Vector3 lineStartPoint, Vector3 lineEndPoint)
    {

        if(lineStartPoint == null || lineEndPoint == null)
        {
            return;
        }
        BoxCollider2D col = lineRender.gameObject.AddComponent<BoxCollider2D>(); //add collider as compenent of line
        col.transform.parent = lineRender.transform;
        float lineLength = Vector3.Distance(lineStartPoint, lineEndPoint); //line length to fit to the colluder
        col.size = new Vector3(lineLength, 0.1f, 1f);
        Vector3 midPoint = (lineStartPoint+ lineEndPoint) / 2;
        col.transform.position = midPoint; // setting position of collider object
        // Following lines calculate the angle between lineStartPoint and lineEndPoint
        float angle = (Mathf.Abs(lineStartPoint.y - lineEndPoint.y) / Mathf.Abs(lineStartPoint.x - lineEndPoint.x));
        if ((lineStartPoint.y < lineEndPoint.y && lineStartPoint.x > lineEndPoint.x) || (lineEndPoint.y < lineStartPoint.y && lineEndPoint.x > lineStartPoint.x))
        {
            angle *= -1;
            
        
        }
      
        angle = Mathf.Rad2Deg * Mathf.Atan(angle);
       
        if (float.IsNaN(angle))
        {
            return;
        }
        else
        {
            col.transform.Rotate(0.0f, 0.0f, angle);
        }

       

    }
    private Vector3? GetCameraPoint()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction * lineDepth;
    }
}
