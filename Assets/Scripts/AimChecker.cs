using UnityEngine;

public class AimChecker : MonoBehaviour
{
    [SerializeField] private Texture crosshair;
    [SerializeField] private float sizeMultiplyer;
    private float crosshairDiameter;
    private float crosshairPositionHorizontal;
    private float crosshairPositionVertical;
    private Vector2 screenCenter;
    private float proximity;

    public GameObject target;
    public Collider col;
    private Camera cam;

    private bool isDetecting;

    private void OnEnable()
    {
        InputHandler.OnInput += InputCheck;
    }

    private void OnDisable()
    {
        InputHandler.OnInput -= InputCheck;
    }
    
    void Start()
    {
        crosshairDiameter = (Screen.height * sizeMultiplyer);
        crosshairPositionHorizontal = (Screen.width - crosshairDiameter) / 2;
        crosshairPositionVertical = (Screen.height - crosshairDiameter) / 2;
        screenCenter.x = (Screen.width / 2);
        screenCenter.y = (Screen.height / 2);

        col = target.GetComponent<Collider>();
        cam = Camera.main.GetComponent<Camera>();
    }

    private void Update()
    {
        CrosshairDetect();
    }
    
    private void InputCheck(bool detecting)
    {
        this.isDetecting = detecting;

        if (detecting)
        {
            print("Detecting");
        }
        else
        {
            print("Reset detecting");
        }
    }
    
    private void CrosshairDetect()
    {
        if (isDetecting)
        {
            Vector3 targetScreenPos = cam.WorldToScreenPoint(target.transform.position);
            Vector2 targetScreenPoint = new Vector2(targetScreenPos.x, targetScreenPos.y);

            proximity = Vector2.Distance(targetScreenPoint, screenCenter);

            if (proximity < (crosshairDiameter / 2))
            {
                print("Aimed");
            }
        }
    }
    
    private void OnGUI()
    {
        GUI.DrawTexture(
            new Rect(crosshairPositionHorizontal, crosshairPositionVertical, crosshairDiameter, crosshairDiameter),
            crosshair, ScaleMode.ScaleToFit, true);
    }
}
