using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript2 : MonoBehaviour {

    public GameObject tether;
    public GameObject gun;

    public float tetherTravelSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public bool tethered;
    public GameObject tetherTarget;

    public float maxDistance;
    public float currentDistance;

    private bool grounded;
    public Vector3 origin;

    //public Texture2D reticle;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;

    private Vector3 previousPosition;
    private float speed;
    private bool swing;
    private HingeJoint pendulum;


    // Use this for initialization
    void Start () {
        swing = false;
        pendulum = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.visible = true;
        //Cursor.SetCursor(reticle, hotSpot, cursorMode);
        //var vMousePosition = Input.mousePosition;
        //vMousePosition.z = Camera.main.nearClipPlane;

        //sensing player speed
        float distanceSinceLastFrame = Vector3.Distance(transform.position, previousPosition);
        speed = distanceSinceLastFrame / Time.deltaTime;

        //firing the hook1
        if (Input.GetMouseButtonDown(0) && fired == false)
        {
            fired = true; // if you haven't fired and have just pressed the mouse, then you can fired when you pressed the mouse.
            swing = true;
        }
        if (fired)
        {
            LineRenderer rope = tether.GetComponent<LineRenderer>();
           // rope.SetVertexCount(2);
            //rope.SetPosition(0, gun.transform.position);
           // rope.SetPosition(1, tether.transform.position);
            Debug.Log("HERE");

        }

        if (fired == true && tethered == false)
        {
            tether.transform.Translate(Vector3.forward * Time.deltaTime * tetherTravelSpeed);// Move hook to a point
            currentDistance = Vector3.Distance(transform.position, tether.transform.position); //Vector3.Distance Calculates distance between position and the hook position
        }
        if (currentDistance >= maxDistance)
        { // If the hook's position is greater than what we set the maximum distance to...
            ReturnTether(); // Run ReturnHook code
        }

        if (fired == true && tethered == true)
        {
            tether.transform.parent = tetherTarget.transform;
            //hook.transform.localScale = new Vector3(0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, tether.transform.position, playerTravelSpeed * Time.deltaTime); //Note: Take out Time.DeltaTime for Crazy things
            float distanceToHook = Vector3.Distance(transform.position, tether.transform.position);

            //Get speed
            Debug.Log(GetSpeed());

            if (distanceToHook < 2)
            {
                if (grounded == false)
                {
                    this.transform.Translate(Vector3.forward * Time.deltaTime * 15f);
                    this.transform.Translate(Vector3.up * Time.deltaTime * 100f);
                }
                StartCoroutine("Climb");
            }
            else
            {
                tether.transform.parent = gun.transform;
                this.GetComponent<Rigidbody>().useGravity = true;
            }


        }
        if (tethered == true && fired == true && swing == true)
        {
            //enable hinge joint
            StartCoroutine("RopeJump"); // make player jump
            pendulum.connectedAnchor = this.transform.position;
            pendulum.connectedBody = tetherTarget.GetComponent<Rigidbody>();
        }
    }

    void ReturnTether()

        {
            tether.transform.rotation = gun.transform.rotation;
            tether.transform.position = gun.transform.position;
            fired = false;
            tethered = false;

            LineRenderer rope = tether.GetComponent<LineRenderer>();
            rope.SetVertexCount(0);
            this.GetComponent<Rigidbody>().useGravity = true;
            tether.transform.parent = gun.transform;
        }

    IEnumerator Climb()
    {
        yield return new WaitForSeconds(0.2f);
        ReturnTether();
    }

    IEnumerator RopeJump()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * 100f);
        yield return new WaitForSeconds(0.2f);
    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1f;

        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    public float GetSpeed()
    {
        return speed;
    }
}
