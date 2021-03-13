using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInfo _playerInfo;

    [SerializeField]
    private Rigidbody _playerRigdbody;

    private Transform _playerTransform;

    private float _playerX;
    private float _playerZ;

    [SerializeField]
    private bool isGrounded;

    //First person camera setting
    [SerializeField]
    private Camera _fpsCam;

    private float _mouse_X;
    private float _mouse_Y;

    [SerializeField]
    private float _camSpeed_X;
    [SerializeField]
    private float _camSpeed_Y;
    [SerializeField]
    private float _camMaxLimit_X = 60f;
    [SerializeField]
    private float _camMinLimit_X = -60f;
    [SerializeField]
    private float _camMaxLimit_Y = 360f;
    [SerializeField]
    private float _camMinLimit_Y = -360f;
    [SerializeField]
    private float _mouseSensitivity;
    
    private float _playerRotation_X;
    private float _playerRotation_Y;

    //테스트에서만 사용
    [SerializeField]
    private float _playerBuildRange = 0.4f;

    //GetComponentInChild?
    private IWeapon _weapon;
    
    // Start is called before the first frame update
    private void Start()
    {
        _playerInfo = GetComponent<PlayerInfo>();
        _playerTransform = GetComponent<Transform>();
        _playerRigdbody = GetComponent<Rigidbody>();
        _fpsCam = GetComponentInChildren<Camera>();
        _weapon = _playerInfo.playerWepapon;
        _playerRotation_X = 0;
        _playerRotation_Y = 0;

        Debug.Log("Current Weapon is " + _weapon.ToString());
        //_camPosition = _playerTransform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("player pressed jump");
            PlayerJump();
        }
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("player pressed Attck (left mouse)");
            PlayerAttack();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("player pressed E");
            PlayerBuild();
        }
        
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerRotate();
    }

    private void PlayerMove()
    {
        _playerX = Input.GetAxis("Horizontal");
        _playerZ = Input.GetAxis("Vertical");
        Vector3 moveDir = (Vector3.right * _playerX) + (Vector3.forward * _playerZ);

        transform.Translate(moveDir.normalized * Time.deltaTime * _playerInfo.playerSpeed, Space.Self);
    }

    private void PlayerRotate()
    {
        //좌우로만 가능
        _playerTransform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * _mouseSensitivity);
    }

    private void PlayerJump()
    {
        if (!isGrounded)
        {
            return;
        }

        //Send parameters to animator
        _playerRigdbody.AddForce(Vector3.up * _playerInfo.playerJumpHeight, ForceMode.Impulse);
    }

    private void PlayerAttack()
    {
        _weapon.UseWeapon();
    }
    private void PlayerBuild()
    {
        Debug.Log(GetPlayerViewPoint(_playerBuildRange));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public Vector3 GetPlayerViewPoint(float range)
    {
        RaycastHit hit;
        //Vector3 position = _fpsCam.WorldToScreenPoint()
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            return hit.collider.gameObject.transform.position;
        }
        return Vector3.zero;
    }
}
