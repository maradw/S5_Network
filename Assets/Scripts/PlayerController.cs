using System;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
   
    private Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;
   
    public Transform cameraRef;

  

    public static event Action OnPlayerGather;
    public static event Action<int> OnPlayerDamage;
    public int _playerLife = 50;
    int force = 3;

   
    [SerializeField] private Vector3 direction;

   
    private bool _canJump;
    private float jumpForce = 7.5f;
 
    private RaycastHit _rayHit1;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float _rayLenght;
    [SerializeField] private Transform _refMovement;

    void Start()
    {
        _canJump = true;
        myRBD = GetComponent<Rigidbody>();
    }

    public void OnMovement(InputAction.CallbackContext move)
    {
        direction = move.ReadValue<Vector3>();

    }
    public void OnShoot(InputAction.CallbackContext shoot)
    {
        if (shoot.performed)
        {

        }
    }
    public void Interact(InputAction.CallbackContext interact)
    {
        // NPC.CallInteract();
    }
    public void Jump(InputAction.CallbackContext jump)
    {
        if (jump.performed && _canJump == true)
        {
            myRBD.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _canJump = false;

        }

    }

    public void FixedUpdate()
    {
        myRBD.velocity = new Vector3(_refMovement.TransformDirection(direction).normalized.x * velocityModifier, myRBD.velocity.y, _refMovement.TransformDirection(direction).normalized.z * velocityModifier);
        transform.rotation = Quaternion.LookRotation(_refMovement.TransformDirection(Vector3.forward));
        _refMovement.rotation = new Quaternion(0, cameraRef.rotation.y, 0, cameraRef.rotation.w);


        if (Physics.Raycast(transform.position, Vector3.down, out _rayHit1, _rayLenght, layer))
        {
            Debug.DrawRay(transform.position, Vector3.down * _rayHit1.distance, Color.magenta);
            _canJump = true;

        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * _rayLenght, Color.green);

        }
    }
}
