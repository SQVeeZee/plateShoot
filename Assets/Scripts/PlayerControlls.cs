using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    [SerializeField] private float sensitivityX = 5F;
    [SerializeField] private float sensitivityY = 5F;
    
    [SerializeField] private float minimumY = -60F;
    [SerializeField] private float maximumY = 60F;
    
    private float rotationX = 0F;
    private float rotationY = 0F;
    
    Quaternion originalRotation;
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
        originalRotation = transform.localRotation;
    }
    
    private void Update()
    {
        GetAxis();
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

    private void GetAxis()
    {
        if (IsRotating)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
    }
}