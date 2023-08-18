using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed = 50;
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float jumpHeight = 3;

    private float gravityValue = 9.81f;


    private CharacterController characterController;
    public bool isGrounded;
    private CinemachineVirtualCamera virtualCamera;
    private Alteruna.Avatar avatar;
    private Vector3 moveInputXZ;
    private Vector3 playerVel;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        avatar = GetComponent<Alteruna.Avatar>();
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();

    }

    private void Start()
    {
        if (!avatar.IsMe)
        {
            enabled = false;

            Camera.main.transform.SetParent(transform);
            Camera.main.transform.position = transform.position;
        }
    }
    private void Update()
    {
        moveInputXZ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveInputXZ = Camera.main.transform.forward * moveInputXZ.z + Camera.main.transform.right * moveInputXZ.x;
        moveInputXZ.y = 0;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerVel.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVel.y += gravityValue * Time.deltaTime;
        characterController.Move(moveInputXZ * speed * Time.deltaTime);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //SpeedControl();

    }
    void SpeedControl()
    {
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //limits speed on ground
            if (isGrounded && flatVel.magnitude > maxSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * maxSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
            //limits speed in air
            else if (!isGrounded && flatVel.magnitude > maxSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * maxSpeed;
            }
        }
    }
}
