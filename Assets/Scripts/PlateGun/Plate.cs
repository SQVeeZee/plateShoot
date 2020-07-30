using System.Collections;
using PathCreation;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private void OnEnable()
    {
        VertexPath.OnFinished += DestroyPlate;
        AimChecker.OnDestroyPlate += DestroyPlate;
    }

    private void OnDisable()
    {
        VertexPath.OnFinished -= DestroyPlate;
        AimChecker.OnDestroyPlate -= DestroyPlate;
    }

    private void DestroyPlate()
    {
        StartCoroutine(DestroyPlateC());
    }

    private IEnumerator DestroyPlateC()
    {
        var vfx = gameObject.transform.GetChild(0).transform;
        vfx.SetParent(null);
        
        GamePlayScreen.Instance.EnableThrowButton();
        
        Destroy(this.gameObject);
        yield return new WaitForSeconds(3);
        Destroy(vfx);
    }
}
