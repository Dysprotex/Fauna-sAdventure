using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class FaunaController : MonoBehaviour, IInputReceiver
{
    Rigidbody rb;
    Healthbehavior healthbehavior;
    public CameraController camController;

    float hInput, vInput;
    public bool jumpable = true;
    float speed = 15;
    float jumpForce = 10;
    float dashForce = 200;
    bool dashAble = true;
    bool activeTimer = true;
    bool dash = false;
    bool shooting = false;

    float timer = 0;
    float shootTimer;
    public float duration = 1f;

    NavMeshAgent agent;
    public FaunaData data;

    public float ForwardMovement { get { return data.Acceleration; } }
    public float SidewayRotation { get { return data.RotationForce; } }

    public float HInput { set { hInput = value; } }
    public float VInput { set { vInput = value; } }

    bool doubleTap = false;
    float doubleTapTime = 0;

    private void Awake()
    {
        healthbehavior = GetComponent<Healthbehavior>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        if (data == null)
        {
            data = new FaunaData();
        }

        data.OutputData();
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        shootTimer += Time.deltaTime;

        //PlayerMovement
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        //Player-Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpable == true)
            {
                if (Time.timeScale <= 0) { return; }
                speed = 7;
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                jumpable = false;
            }
        }

        if (Input.GetButton("Sprint"))
        {
            if(dash != true)
            {
                speed = 20;
            }
        }
        if (Input.GetButtonUp("Sprint"))
        {
            speed = 10;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(dashAble == true)
            {
                dash = true;
                speed = dashForce;
                timer = 0;
                activeTimer = true;
                dashAble = false;
            }
        }

        if (timer >= 0.2 && activeTimer == true)
        {
            speed = 10;
            activeTimer = false;
            dash = false;
        }
        if (timer >= 1)
        {
            dashAble = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        jumpable = true;
    }
    
    public void OnFireDown()
    {
        rb.AddRelativeForce(Vector3.forward * -50);
        speed = 10;
    }
}
