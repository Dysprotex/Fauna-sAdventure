using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class FaunaController : MonoBehaviour, IInputReceiver
{
    Rigidbody rb;

    float hInput, vInput;
    public bool jumpable = true;
    float speed = 15;
    float jumpForce = 10;
    float dashForce = 200;
    bool dashAble = true;
    bool activeTimer = true;

    float timer = 0;
    float shootTimer;

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
                speed = 7;
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                jumpable = false;
            }
        }

        if (Input.GetButtonDown("Sprint"))
        {
            speed = 20;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            speed = 10;
        }

        
        
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (Time.time - doubleTapTime < 0.2f)
                {
                    speed = dashForce;
                    doubleTapTime = 0f;
                    timer = 0;
                    activeTimer = true;
                    dashAble = false;

                }
                doubleTap = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                doubleTap = true;
                doubleTapTime = Time.time;
            }
        
            if (timer >= 0.2 && activeTimer == true)
            {
                speed = 10;
                activeTimer = false;
            }
            if(timer >= 5)
            {
                dashAble = true;
            }

    }


    private void OnCollisionEnter(Collision collision)
    {
        jumpable = true;
    }

    
    public void OnFireDown() { speed = 10; }
}
