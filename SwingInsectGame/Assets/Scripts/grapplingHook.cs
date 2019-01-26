using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplingHook : MonoBehaviour {

    private DistanceJoint2D joint;
    private Vector3 cursorPos;
    private RaycastHit2D raycast;
    public float maxDistance = 10f, approachSpeed;
    public LayerMask mask;
    public LineRenderer line;
    private Rigidbody2D rb;
    private Vector2 connectedAnchor;


	void Start () {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPos.z = 0;

            raycast = Physics2D.Raycast(transform.position, cursorPos - transform.position, maxDistance, mask);
            if (raycast.collider != null && raycast.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                Vector2 connectPoint = raycast.point - new Vector2(raycast.collider.transform.position.x, raycast.collider.transform.position.y);
                connectPoint.x = connectPoint.x / raycast.collider.transform.localScale.x;
                connectPoint.y = connectPoint.y / raycast.collider.transform.localScale.y;

                connectedAnchor = connectPoint;
                joint.connectedAnchor = connectPoint;
                joint.connectedBody = raycast.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, raycast.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, raycast.point);

            }
        }

        if (Input.GetMouseButton(1))
        {
            if (Input.GetKey(KeyCode.UpArrow)){
                joint.distance -= approachSpeed * Time.deltaTime;
                joint.connectedAnchor = connectedAnchor;
            }
            line.SetPosition(0, transform.position);
        }

        if (Input.GetMouseButtonUp(1))
        {
            joint.enabled = false;
            line.enabled = false;
            rb.gravityScale = 8;
        }
	}
}
