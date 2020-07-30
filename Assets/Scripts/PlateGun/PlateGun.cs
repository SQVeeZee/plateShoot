using System;
using UnityEngine;
using PathCreation;
using Random = UnityEngine.Random;

public class PlateGun : MonoBehaviour
{
    public static event Action<GameObject> OnSpawnedPlate;
    [SerializeField] private GameObject[] plateGuns;
    [SerializeField] private GameObject plate;
    private void OnEnable()
    {
        GamePlayScreen.OnThrow += SpawnPlate;
    }

    private void OnDisable()
    {
        GamePlayScreen.OnThrow -= SpawnPlate;
    }

    private void SpawnPlate()
    {
        var gunId = Random.Range(0,plateGuns.Length);
        GameObject plateObj = Instantiate(plate, plateGuns[gunId].transform.GetChild(0));

        OnSpawnedPlate?.Invoke(plateObj);
    }
}
