using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if ( Physics.Raycast(ray, out hit) && hit.transform == transform )
            {
                isDragging = true;
                distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            }
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 MousePos = Input.mousePosition;
            MousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 WorldPos = Camera.main.ScreenToWorldPoint(MousePos);
            transform.position = WorldPos;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
