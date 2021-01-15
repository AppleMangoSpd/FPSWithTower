using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    //player information
    //inventory
    //equipment
    [SerializeField]
    private float _playerSpeed;
    public float playerSpeed
    {
        get { return _playerSpeed; }
        set { _playerSpeed = value; }
    }

    [SerializeField]
    private float _playerJumpHeight;
    public float playerJumpHeight
    {
        get { return _playerJumpHeight; }
        set { _playerJumpHeight = value; }
    }

    [SerializeField]
    private float _playerHp;
    public float playerHp
    {
        get { return _playerHp; }
        set { _playerHp = value; }
    }

    //equipment
    public BaseWeapon _playerWeapon;
    public BaseWeapon playerWepapon
    {
        get { return _playerWeapon; }
        set { _playerWeapon = value; }
    }

    private void Start()
    {
        //For test
        //_playerWeapon = new TestWeapon();
    }

}
