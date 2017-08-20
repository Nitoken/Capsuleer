using UnityEngine;

public class PlayerController : Movement
{
    PlayerAttack pa;

    Rigidbody rb;
    public LayerMask interactLayers;

    public bool isGrounded = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pa = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (Input.GetButtonDown("LeftMouse"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, byte.MaxValue, interactLayers))
            {
                switch (hit.collider.tag)
                {
                    case "Ground":
                        actualStatus = Status.move;
                        break;

                    case "Enemy":
                        actualStatus = Status.attack;
                        break;
                }
            }
        }
        if(Input.GetButtonUp("LeftMouse"))
        {
            actualStatus = Status.stay;
        }
    }
    void FixedUpdate()
    {
        //When player hitted ground
        if(actualStatus == Status.move)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, byte.MaxValue, interactLayers))
            {
                Vector3 target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                Vector3 dir = target - transform.position;

                if (isGrounded)
                {
                    if (dir.magnitude > 0.1f)
                        rb.velocity = dir.normalized * actualSpeed; //simple. Move
                    else
                        rb.velocity = Vector3.zero; //stay
                }
                else
                {
                    Vector3 fallVector = -Vector3.up * fallSpeed;

                    if (dir.magnitude > 0.1f)
                        rb.velocity = fallVector + dir.normalized * actualSpeed; //fall and move
                    else
                        rb.velocity = fallVector; // just fall
                }
            }
        }
        if(actualStatus == Status.attack)
        {

        }
    }

    //For isGrounded
    void OnTriggerEnter()
    {
        isGrounded = true;
    }
    void OnTriggerExit()
    {
        isGrounded = false;
    }
}
