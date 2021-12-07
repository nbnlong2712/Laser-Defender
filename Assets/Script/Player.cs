using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 playerMove;
    Vector2 minBound;
    Vector2 maxBound;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float moveSpeed = 4.5f;


    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();    
    }

    void Start()
    {
        InitBounds();    
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 delta = playerMove * moveSpeed * Time.deltaTime;
        //locked transfrom.position in a frame
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingBottom, maxBound.y - paddingTop);

        transform.position = newPos;
    }

    //Create bound (frame) xung quanh man hinh, ngan khong cho object chay ra ngoai
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0.1f, 0)); //diem duoi cung ben trai cua camera
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1)); //diem tren cung ben phai cua camera
    }

    void OnMove(InputValue value)
    {
        playerMove = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
