using System;
using System.Collections;
using UnityEngine;

public class AimChecker : MonoBehaviour
{
    public static event Action OnDestroyPlate;
    
    [SerializeField] private Texture crosshair;
    [SerializeField] private float sizeMultiplyer;
    [SerializeField] private GameObject muzzleVFX;
    
    private float crosshairDiameter;
    private float crosshairPositionHorizontal;
    private float crosshairPositionVertical;
    private Vector2 screenCenter;
    private float proximity;

    private GameObject target;
    private Collider col;
    private Camera cam;

    private bool isDetecting;
    private bool isAimed;

    private void OnEnable()
    {
        InputHandler.OnInput += InputCheck;
        PlateGun.OnSpawnedPlate += SetTheTarget;
    }

    private void OnDisable()
    {
        InputHandler.OnInput -= InputCheck;
        PlateGun.OnSpawnedPlate += SetTheTarget;
    }

    void Start()
    {
        crosshairDiameter = (Screen.height * sizeMultiplyer);
        crosshairPositionHorizontal = (Screen.width - crosshairDiameter) / 2;
        crosshairPositionVertical = (Screen.height - crosshairDiameter) / 2;
        screenCenter.x = (Screen.width / 2);
        screenCenter.y = (Screen.height / 2);

        cam = Camera.main.GetComponent<Camera>();
    }

    private void Update()
    {
        CrosshairDetect();
    }
    
    private void InputCheck(bool detecting)
    {
        isDetecting = detecting;

        if (detecting)
        {
            isDetecting = true;
            print("Detecting");
        }
        else
        {
            print("Reset detecting");
        }
    }
    
    private void CrosshairDetect()
    {
        if (isDetecting && target!=null)
        {
            Vector3 targetScreenPos = cam.WorldToScreenPoint(target.transform.position);
            Vector2 targetScreenPoint = new Vector2(targetScreenPos.x, targetScreenPos.y);

            proximity = Vector2.Distance(targetScreenPoint, screenCenter);

            if (proximity < (crosshairDiameter / 2))
            {
                if (!isAimed)
                {
                    GamePlayScreen.Instance.SetBarState(true);
                    isAimed = true;
                    StartCoroutine(AimedProgress());
                }
                print("Aimed");
            }
            
            else
            {
                if (isAimed)
                {
                    GamePlayScreen.Instance.SetBarState(false);
                    isAimed = false;
                    StopAllCoroutines();
                }
            }
        }
    }

    private IEnumerator AimedProgress()
    {
        float t = 0;

        while (t<=1)
        {
            t+=0.05f;
            GamePlayScreen.Instance.SetProgressBar(t);
            yield return new WaitForSeconds(0.05f);
        }
        OnDestroyPlate?.Invoke();
        Instantiate(muzzleVFX, cam.transform.GetChild(0));
        GamePlayScreen.Instance.SetBarState(false);
    }
    
    private void SetTheTarget(GameObject plateObj)
    {
        target = plateObj;
        col = target.GetComponent<Collider>();
    }
    
    private void OnGUI()
    {
        GUI.DrawTexture(
            new Rect(crosshairPositionHorizontal, crosshairPositionVertical, crosshairDiameter, crosshairDiameter),
            crosshair, ScaleMode.ScaleToFit, true);
    }
}
