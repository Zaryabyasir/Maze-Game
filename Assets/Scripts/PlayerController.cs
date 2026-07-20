using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Input")] [SerializeField] private InputActionAsset inputActions;

    [Header("Movement Settings")] 
    [SerializeField] private float speed = 1f;
    [SerializeField] GameObject fixedButton;
    
    public LevelManager levelManager;
    
    private InputAction _moveAction;
    private Rigidbody _rb;
    private Vector2 _moveInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        if (inputActions == null)
        {
            Debug.LogError("InputActionAssets not assigned!", this);
            return;
        }

        var playerMap = inputActions.FindActionMap("Player", true);
            _moveAction = playerMap.FindAction("Move", true);
            
            PlayerJoystick();
    }
    
    private void OnEnable()
    {
        _moveAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
    }

    private void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
    }
 
    private void FixedUpdate()
    {
     
        Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
        Vector3 normalizedDirection = moveDirection.normalized;
        Vector3 finalForce = normalizedDirection * speed;
        _rb.AddForce(finalForce,ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
         
            LevelManager.Instance.WinLevel();
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }

    public void PlayerJoystick()
    {
        if (Application.isMobilePlatform)
        {
            fixedButton.SetActive(true);
        }
        else
        {
            fixedButton.SetActive(false);
        }
    }
}

