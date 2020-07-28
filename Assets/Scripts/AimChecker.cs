using System;
using UnityEngine;

public class AimChecker : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        SetAimPosition();
    }

    private Vector3 CheckScreenSize()
    {
        var width = mainCamera.pixelRect.width / 2;
        var height = mainCamera.pixelRect.height / 2;
        return new Vector3(width,height,1);
    }

    private void SetAimPosition()
    {
    //    print(CheckScreenSize());
      //  transform.position = CheckScreenSize();
    }


}
