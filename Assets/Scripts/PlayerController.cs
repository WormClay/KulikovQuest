using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    public float Speed2 = 4f;
    public float JumpForce = 1f;

    public LayerMask GroundLayer = 0;

    private Transform cameraTransform;
    private Rigidbody myRigidbody;
    private CapsuleCollider myCollider;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Jump = "Jump";


    Vector3 rot = new Vector3(0, 0, 0);
    public float mouseSpeed; // Чувствительность мыши

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSpeed;
        rot.x = rot.x - MouseY;
        rot.y = rot.y + MouseX;
        rot.z = 0;
        transform.eulerAngles = new Vector3(0, rot.y, 0);
        cameraTransform.eulerAngles = rot;
    }



    private bool IsGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(myCollider.bounds.center.x, myCollider.bounds.min.y, myCollider.bounds.center.z);
            //создаем невидимую физическую капсулу и проверяем не пересекает ли она обьект который относится к полу
            //_collider.bounds.size.x / 2 * 0.9f -- эта странная конструкция берет радиус обьекта.
            // был бы обязательно сферой -- брался бы радиус напрямую, а так пишем по-универсальнее
            return Physics.CheckCapsule(myCollider.bounds.center, bottomCenterPoint, myCollider.bounds.size.x / 2 * 0.9f, GroundLayer);
            // если можно будет прыгать в воздухе, то нужно будет изменить коэфициент 0.9 на меньший.
        }
    }

    private Vector3 MovementVector
    {
        get
        {
            var horizontal = Input.GetAxis(Horizontal);
            var vertical = Input.GetAxis(Vertical);
            return new Vector3(horizontal, 0.0f, vertical);
        }
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        cameraTransform = transform.Find("Camera").transform;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        DoJump();
        Move();
    }

    private void Move()
    {
        myRigidbody.AddRelativeForce(MovementVector * Speed2, ForceMode.Impulse);
    }

    private void DoJump()
    {
        if (IsGrounded && (Input.GetAxis(Jump) > 0))
        {
            myRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
    
}
