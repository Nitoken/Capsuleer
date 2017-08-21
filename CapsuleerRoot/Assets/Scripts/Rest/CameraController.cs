using UnityEngine;
using System.Collections.Generic;
public class CameraController : MonoBehaviour
{
    public Transform target; //Follow target
    public float smoothDamp; //How fast follow target
    public float minOffset, maxOffset, scrollSens; //min and max zoom, and zooming speed
    Vector3 refVel, offset; // ref - needed to SmoothDamp. offset - distance between target and camera

    public LayerMask hideLayers; //Which layers should be transparent
    List<GameObject> faded; //Which object are transaprent
    void Start()
    {
        faded = new List<GameObject>();
        target = GameObject.FindGameObjectWithTag("Player").transform; //Find target
        offset = target.position - transform.position; //Get distance
    }
    void LateUpdate()
    {
        Zoom();
        //Just with target 
        if (target != null)
        {
            FollowTarget();
            TransparentObject();
        }

    }
    void Zoom()
    {
        offset.y += Input.GetAxis("Mouse ScrollWheel") * scrollSens;
        offset.y = Mathf.Clamp(offset.y, minOffset, maxOffset); //Mo more than max and no less than min
    }
    void FollowTarget()
    {
        Vector3 desiredPos = target.position - offset; //Where go now
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref refVel, smoothDamp);//move to position
        transform.LookAt(target);//Look at target!
    }
    void TransparentObject()
    {
        RaycastHit hit;
        //Dual sending CAN fade object when player/camera is inside some trigger(collider)
        //Send raycast from camera to player
        if (Physics.Raycast(transform.position, offset, out hit, byte.MaxValue, hideLayers))
            AddToDictio(hit.collider.gameObject);
        //if nothing then send raycast from player to camera
        else if (Physics.Raycast(target.position, -offset, out hit, byte.MaxValue, hideLayers))
            AddToDictio(hit.collider.gameObject);
        else
        {
            //If there is no GameObject between target and camera then remove (if exists) all faded objects
            if (faded.Count > 0)
            {
                foreach (GameObject item in faded)
                    item.GetComponent<Transparent>().IsHitted = false; //Transparent script is changing shader to normal one 
                faded.Clear(); //Delete all faded things
            }
        }

    }
    //Adds to dictionary which contains faded objects
    void AddToDictio(GameObject hit)
    {
        //Make sure object CAN be transparent (Contains essential components)
        if (hit.GetComponent<Transparent>() != null)
        {
            hit.GetComponent<Transparent>().IsHitted = true; //Transparent script is changing shader to Transparent one
            if (!faded.Contains(hit.gameObject))
                faded.Add(hit.gameObject); //Add to faded gameobjects
        }
    }
}
