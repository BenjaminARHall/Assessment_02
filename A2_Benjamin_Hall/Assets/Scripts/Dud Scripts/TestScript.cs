using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    //public GameObject hook;
    //public GameObject hookHolder;

    //public float hookTravelSpeed;
    //public float playerTravelSpeed;

    //public static bool fired;
    //public bool hooked;
    //public GameObject hookedObj;

    //public float maxDistance;
    //private float currentDistance;

    //private bool grounded;
    //public Vector3 origin;

    //public Texture2D reticle;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;

    //private Vector3 previousPosition;
    //private float speed;
    //public bool grapple;
    //public bool swing;
    //private HingeJoint pendulum;

    //void Start()
    //{
    //    grapple = false;
    //    swing = false;
    //    pendulum = GetComponent<HingeJoint>();
    //}

    //void Update()
    //{
    //    //cursor/reticle
    //    Cursor.visible = true;
    //    Cursor.SetCursor(reticle, hotSpot, cursorMode);
    //    var vMousePosition = Input.mousePosition;
    //    vMousePosition.z = Camera.main.nearClipPlane;

    //    //Sensing player speed
    //    float distanceSinceLastFrame = Vector3.Distance(transform.position, previousPosition);
    //    speed = distanceSinceLastFrame / Time.deltaTime;

    //    //firing the hook1
    //    if (Input.GetMouseButtonDown(0) && fired == false)
    //    {
    //        fired = true; // if you haven't fired and have just pressed the mouse, then you can fired when you pressed the mouse.
    //        grapple = true;
    //    }
    //    //firing the hook2
    //    if (Input.GetMouseButtonDown(1) && fired == false)
    //    {
    //        fired = true;
    //        swing = true;
    //    }

    //    if (fired)
    //    {
    //        LineRenderer rope = hook.GetComponent<LineRenderer>();
    //        rope.SetVertexCount(2);
    //        rope.SetPosition(0, hookHolder.transform.position);
    //        rope.SetPosition(1, hook.transform.position);
    //        Debug.Log("HERE");
    //    }

    //    if (fired == true && hooked == false)
    //    {
    //        hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);// Move hook to a point
    //        currentDistance = Vector3.Distance(transform.position, hook.transform.position); //Vector3.Distance Calculates distance between position and the hook position
    //    }
    //    if (currentDistance >= maxDistance)
    //    { // If the hook's position is greater than what we set the maximum distance to...
    //        ReturnHook(); // Run ReturnHook code
    //    }

    //    //if you've hooked and fired
    //    if (hooked == true && fired == true && grapple == true)
    //    {
    //        hook.transform.parent = hookedObj.transform;
    //        //hook.transform.localScale = new Vector3(0, 0, 0);
    //        transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, playerTravelSpeed * Time.deltaTime); //Note: Take out Time.DeltaTime for Crazy things
    //        float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

    //        //Get speed
    //        Debug.Log(GetSpeed());

    //        if (distanceToHook < 2)
    //        {
    //            if (grounded == false)
    //            {
    //                this.transform.Translate(Vector3.forward * Time.deltaTime * 15f);
    //                this.transform.Translate(Vector3.up * Time.deltaTime * 100f);
    //            }
    //            StartCoroutine("Climb");
    //        }
    //        else
    //        {
    //            hook.transform.parent = hookHolder.transform;
    //            this.GetComponent<Rigidbody>().useGravity = true;
    //        }
    //    }

    //    if (hooked == true && fired == true && swing == true)
    //    {
    //        //enable hinge joint
    //        StartCoroutine("RopeJump"); // make player jump
    //        pendulum.connectedAnchor = this.transform.position;
    //        pendulum.connectedBody = hookedObj.GetComponent<Rigidbody>();
    //    }

    //}

    //IEnumerator Climb()
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    ReturnHook();
    //}

    //IEnumerator RopeJump()
    //{
    //    this.transform.Translate(Vector3.up * Time.deltaTime * 100f);
    //    yield return new WaitForSeconds(0.2f);
    //}

    //void ReturnHook()
    //{
    //    hook.transform.rotation = hookHolder.transform.rotation;
    //    hook.transform.position = hookHolder.transform.position;
    //    fired = false;
    //    hooked = false;

    //    LineRenderer rope = hook.GetComponent<LineRenderer>();
    //    rope.SetVertexCount(0);
    //    this.GetComponent<Rigidbody>().useGravity = true;
    //    hook.transform.parent = hookHolder.transform;
    //}

    //void GroundCheck()
    //{
    //    RaycastHit hit;
    //    float distance = 1f;

    //    Vector3 dir = new Vector3(0, -1);

    //    if (Physics.Raycast(transform.position, dir, out hit, distance))
    //    {
    //        grounded = true;
    //    }
    //    else
    //    {
    //        grounded = false;
    //    }
    //}

    //public float GetSpeed()
    //{
    //    return speed;
    //}
}
