using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
#if UNITY_EDITOR

    [SerializeField] private float sensitivityX = 5F;
    [SerializeField] private float sensitivityY = 5F;

    [SerializeField] private float minimumY = -60F;
    [SerializeField] private float maximumY = 60F;

    private float rotationX = 0F;
    private float rotationY = 0F;

    Quaternion originalRotation;
#endif

    #region MobileInput

    private Vector3 firstpoint;
    private Vector3 secondpoint;
    private float xAngle = 0;
    private float yAngle = 0;
    private float xAngTemp = 0;
    private float yAngTemp = 0;

    #endregion

    public bool IsRotating { get; private set; }

    private void OnEnable()
    {
        InputHandler.OnInput += InputCheck;
    }

    private void OnDisable()
    {
        InputHandler.OnInput -= InputCheck;
    }

    private void Start()
    {
#if UNITY_EDITOR
        originalRotation = transform.localRotation;
#endif

        xAngle = 0;
        yAngle = 0;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }

    private void Update()
    {
        EditorGetAxis();
        MobileInput();
    }

    private void MobileInput()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
                xAngTemp = xAngle;
                yAngTemp = yAngle;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondpoint = Input.GetTouch(0).position;

                xAngle = (float) (xAngTemp + (secondpoint.x - firstpoint.x) * 180.0 / Screen.width);
                yAngle = (float) (yAngTemp - (secondpoint.y - firstpoint.y) * 90.0 / Screen.height);

                transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
            }
        }
    }

    private void InputCheck(bool rotating)
    {
        this.IsRotating = rotating;

        if (rotating)
        {
            print("Rotating");
        }
        else
        {
            print("Reset rotating");
        }
    }

    private void EditorGetAxis()
    {
#if UNITY_EDITOR

        if (IsRotating)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
#endif
    }
}