using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hbController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody hb;
    public Transform com;
    private void Start()
    {
        hb = GetComponent<Rigidbody>();
        hb.centerOfMass = com.position;
    }

    public float multiplier;
    public float moveForce, turnTorque, bendTorque;

    public Transform[] anchors = new Transform[5];
    RaycastHit[] hits = new RaycastHit[5];

    // Update is called once per frame
    private void FixedUpdate()
    {
        for(int i=0; i<4; i++)
        {
            ApplyForce(anchors[i], hits[i]);
        }
        hb.AddForce(Input.GetAxis("Vertical") * moveForce * transform.forward);
        hb.AddTorque(Input.GetAxis("Horizontal") * turnTorque * transform.up);
        hb.AddTorque(Input.GetAxis("Horizontal") * bendTorque * transform.forward);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyVerticalForce(anchors[4], hits[4]);
        }
    }
    void ApplyForce(Transform anchor, RaycastHit hit)
    {
        if(Physics.Raycast(anchor.position, -anchor.up, out hit))
        {
            float force = 0;
            force = Mathf.Abs(1 / (hit.point.y - anchor.position.y));
            hb.AddForceAtPosition(transform.up * force * multiplier, anchor.position, ForceMode.Acceleration);
        }
    }
    void ApplyVerticalForce(Transform anchor, RaycastHit hit)
    {
        if (Physics.Raycast(anchor.position, anchor.up, out hit))
        {
            float force = 0;
            force = Mathf.Abs(1 / (1+hit.point.y - anchor.position.y));
            hb.AddForceAtPosition(transform.up * force * multiplier, anchor.position, ForceMode.Acceleration);
        }
    }
}
