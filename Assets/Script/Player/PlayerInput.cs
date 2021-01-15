using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInfo _playerInfo;

    private Rigidbody _playerRigdbody;

    private Transform _playerTransform;

    private float _playerX;
    private float _playerZ;

    private bool isGrounded;

    //First person camera setting
    [SerializeField]
    private Camera _fpsCam;

    private float _mouseX;
    private float _mouseY;
    //[SerializeField]
    //private float _cameraSpeed;
    [SerializeField]
    private float _camSpeedX;
    [SerializeField]
    private float _camSpeedY;
    [SerializeField]
    private float _camMaxLimitX = 60f;
    [SerializeField]
    private float _camMinLimitX = -60f;
    [SerializeField]
    private float _camMaxLimitY = 360f;
    [SerializeField]
    private float _camMinLimitY = -360f;

    private float _playerRotationX;
    private float _playerRotationY;

    //GetComponentInChild
    private IWeapon _weapon;
    
    // Start is called before the first frame update
    private void Start()
    {
        _playerInfo = GetComponent<PlayerInfo>();
        _playerTransform = GetComponent<Transform>();
        _playerRigdbody = GetComponent<Rigidbody>();
        _fpsCam = GetComponentInChildren<Camera>();
        _weapon = _playerInfo.playerWepapon;
        _playerRotationX = 0;
        _playerRotationY = 0;

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
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _playerRotationX = _mouseX * _camSpeedX * Time.deltaTime;
        _playerRotationY = _mouseY * _camSpeedY * Time.deltaTime;

        _playerTransform.Rotate(Vector3.up * _playerRotationX);

        //_fpsCam.transform.localEulerAngles = new Vector3(_playerRotationX, _playerRotationY, 0);
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
    private void PlayerDetectItem()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
