using UnityEngine;
using PathCreation;
using Random = UnityEngine.Random;

public class PlateGun : MonoBehaviour
{
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

    public PathCreator pathCreator;
    private void Start()
    {
        //transform.position = pathCreator.path.GetPoint(0);
    }

    private void SpawnPlate()
    {
        var gunId = Random.Range(0,plateGuns.Length);
        Instantiate(plate, plateGuns[gunId].transform);
    }
}
