using UnityEngine;

public class PlayerController : Movement
{
    Attack pa;

    Rigidbody rb;
    public LayerMask interactLayers;

    public bool isGrounded = false;

    public override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        pa = GetComponent<Attack>();
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
                        pa.target = hit.collider.gameObject;
                        break;
                }
            }
        }
        if(Input.GetButtonUp("LeftMouse"))
        {
            GetComponent<Renderer>().material.color = Color.white;
            actualStatus = Status.stay;
            if (pa.target != null)
                pa.target = null;
        }
    }
    void FixedUpdate()
    {
        //When player hitted ground just go there
        if(actualStatus == Status.move)
        {
            GetComponent<Renderer>().material.color = Color.green;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, byte.MaxValue, interactLayers))
                Move(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
        //When player hitted enemy and he is NOT in range then get closer
        if(actualStatus == Status.attack)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            if (Vector3.Distance(transform.position, pa.target.transform.position) > pa.actualRange)
                Move(pa.target.transform.position);
        }
    }
    void Move(Vector3 targetPosition)
    {
        Vector3 dir = targetPosition - transform.position;

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
