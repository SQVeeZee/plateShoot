using System;
using UnityEngine;
using PathCreation;

public class PlateGun : MonoBehaviour
{
    public PathCreator pathCreator;
    private void Start()
    {
        transform.position = pathCreator.path.GetPoint(0);
    }
}
