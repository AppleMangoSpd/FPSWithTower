using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{


    private Rigidbody _playerRigdbody;

    private Transform _playerTransform;

    private float _playerX;
    private float _playerZ;
    [SerializeField]
    private float _playerSpeed;

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
    private float _camMaxLimitY;
    [SerializeField]
    private float _camMinLimitY;

    private float _playerRotationX;
    private float _playerRotationY;

    private Vector3 _camPosition;

    //굳이?
    public IWeapon _weapon;
    
    // Start is called before the first frame update
    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _playerRigdbody = GetComponent<Rigidbody>();
        _weapon = GetComponentInChildren<IWeapon>();
        _playerRotationX = 0;
        _playerRotationY = 0;

        Debug.Log("Current Weapon is " + _weapon.ToString());
        //_camPosition = _playerTransform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        
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

        transform.Translate(moveDir.normalized * Time.deltaTime * _playerSpeed, Space.Self);
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

}
