using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    public float CharacterSpeed = 20.0f;
    public float AutoMoveSpeed = 20.0f;
    public float RotateSpeed = 5.0f;
    public bool isMove = true;

    public bool canMove = true;
    public bool canMouseMove = true;

    public bool isAutoMove = false;
    Rigidbody rb;


    #region Singleton
    /// <summary>
    /// CharcterMoveController Scriptini static olarak diðer scriptlerimde kullanabilmeme yaran bir kod parçasý
    /// </summary>
    
    private static CharacterMoveController _cMove;
    public static CharacterMoveController cMove
    {
        get
        {
            if (_cMove == null)
                _cMove = FindObjectOfType<CharacterMoveController>();
            return _cMove;
        }
    }
    #endregion
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0)) isMove = true;
            if (Input.GetMouseButtonUp(0)) isMove = false;
        }
        else
        {
            isMove = false;
        }
    }
    private void FixedUpdate()
    {
        if (isMove)
        {
            CharacterMove();
        }
        if (isAutoMove)
        {
            autoMove();
        }
    }
    public void CharacterMove()
    {
        transform.position += transform.forward * CharacterSpeed * Time.deltaTime;
    }
    public void autoMove()
    {
        transform.position += transform.forward * AutoMoveSpeed * Time.deltaTime;
    }
    #region Mouse Moves

    public void LeftMove(float speed)
    {
        rb.velocity += (transform.right * speed) * -RotateSpeed * Time.deltaTime;
    }
    public void RightMove(float speed)
    {
        rb.velocity += (transform.right * speed) * RotateSpeed * Time.deltaTime;
    }

    #endregion
}
