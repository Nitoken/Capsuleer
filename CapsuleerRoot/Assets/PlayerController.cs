using UnityEngine;

public class PlayerController : Movement
{
    Attack pa;
    Rigidbody rb;
    UpperPanelController upc;
    public LayerMask interactLayers;

    public bool isGrounded = false;

    public override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        pa = GetComponent<Attack>();
        upc = GameObject.FindGameObjectWithTag("UPC").GetComponent<UpperPanelController>();
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
                        upc.showingByPlayerAttack = true; //Is showing actual players target
                        upc.enemytoShow = pa.target; //Send actual target to show in UI 
                        break;
                }
            }
        }
        if(Input.GetButtonUp("LeftMouse"))
        {
            GetComponent<Renderer>().material.color = Color.white;
            actualStatus = Status.stay;
            if (pa.target != null)
            {
                pa.target = null;

                upc.showingByPlayerAttack = false; //No more showin player's target
                upc.enemytoShow = null; //No target
            }
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
            if(pa.target != null)
                if (Vector3.Distance(transform.position, pa.target.transform.position) > pa.actualRange)
                    Move(pa.target.transform.position);
        }
    }
    void Move(Vector3 targetPosition)
    {
        Vector3 dir = targetPosition - transform.position;

        if (isGrounded)
        {
            if (dir.magnitude > 0.1f && !Input.GetKey(KeyCode.LeftShift))
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
