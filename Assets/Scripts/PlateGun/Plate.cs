using System;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private void OnEnable()
    {
        AimChecker.OnDestroyPlate += DestroyPlate;
    }

    private void OnDisable()
    {
        AimChecker.OnDestroyPlate -= DestroyPlate;
    }

    private void DestroyPlate()
    {
        Destroy(this.gameObject);
    }
}
