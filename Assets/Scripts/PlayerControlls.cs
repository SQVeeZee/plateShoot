using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    [SerializeField] private GameObject aim;
    [SerializeField] private float m_DistanceY;
    Plane m_Plane;
    Vector3 m_DistanceFromCamera;
    

    void Start()
    {
        m_DistanceFromCamera = new Vector3(Camera.main.transform.position.x,
            Camera.main.transform.position.y, Camera.main.transform.position.z + m_DistanceY);
        m_Plane = new Plane(Vector3.forward, m_DistanceFromCamera);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0.0f;

            if (m_Plane.Raycast(ray, out enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                aim.transform.position = hitPoint;
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.(m_DistanceFromCamera,Vector3.one);
    }
}
