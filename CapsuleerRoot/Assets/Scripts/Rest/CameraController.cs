using UnityEngine;
using System.Collections.Generic;
public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothDamp;
    public float minOffset, maxOffset, scrollSens;
    Vector3 refVel, offset;

    public LayerMask hideLayers;
    List<GameObject> faded;
    void Start()
    {
        faded = new List<GameObject>();
        offset = target.position - transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void LateUpdate()
    {
        Zoom();
        FollowTarget();
        TransparentObject();

    }
    void Zoom()
    {
        offset.y += Input.GetAxis("Mouse ScrollWheel") * scrollSens;
        offset.y = Mathf.Clamp(offset.y, minOffset, maxOffset);
    }
    void FollowTarget()
    {
        Vector3 desiredPos = target.position - offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref refVel, smoothDamp);
        transform.LookAt(target);
    }
    void TransparentObject()
    {
        RaycastHit hit;
        //Dual sending CAN fade object when player/camera is inside some trigger(collider)
        //Send raycast from camera to player
        if (Physics.Raycast(transform.position, offset, out hit, byte.MaxValue, hideLayers))
        {
            AddToDictio(hit.collider.gameObject);
        }
        //if nothing then send raycast from player to camera
        else if (Physics.Raycast(target.position, -offset, out hit, byte.MaxValue, hideLayers))
        {
            AddToDictio(hit.collider.gameObject);
        }
        else
        {
            //If there is no GameObject between target and camera then remove (if exists) all faded objects
            if (faded.Count > 0)
            {
                foreach (GameObject item in faded)
                    item.GetComponent<Transparent>().IsHitted = false; //Transparent script is changing shader to normal one 
                faded.Clear();
            }
        }

    }
    void AddToDictio(GameObject hit)
    {
        if (hit.GetComponent<Transparent>() != null)
        {
            hit.GetComponent<Transparent>().IsHitted = true; //Transparent script is changing shader to Transparent one
            if (!faded.Contains(hit.gameObject))
                faded.Add(hit.gameObject); //Add to faded gameobjects
        }
    }
}
