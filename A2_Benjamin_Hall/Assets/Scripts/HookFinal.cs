using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public enum GrapplingHookMode {Ratcheting, Loose, Rigid}

public class HookFinal : MonoBehaviour {
    //https://github.com/ZacharyBuffone/UnityGrapplingHookComponent
    public Camera cam;

    public GrapplingHookMode grapplingHookMode;

    public bool drawDevLine = true;
    public bool disconnectOnLosBreak;
    public float breakTetherVelo;

   
    public Rigidbody rb;
    public GameObject playerCamera;

    public GameObject hookedNode;
    public float nodeDistance;
    public float nodeStartDistance;
    public GameObject grapplingLine;

	// Use this for initialization
	void Start () {
        this.rb = gameObject.GetComponent<Rigidbody>();

        if(drawDevLine)
        {
            grapplingLine = new GameObject("GrapplingLine");
            grapplingLine.SetActive(false);
            LineRenderer lineRenderer = grapplingLine.AddComponent<LineRenderer>();
            lineRenderer.endWidth = 0.5f;
            lineRenderer.startWidth = 0.5f;
        }
        hookedNode = null;
        return;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && hookedNode == null)
        {
            Ray ray = this.cam.ViewportPointToRay(new Vector3(.5f, .5f, 0));

            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit) &&(raycastHit.transform.tag == "tetherPoint"))
            {
                Debug.Log("Hit");
                hookedNode = raycastHit.collider.gameObject;
                nodeDistance = nodeStartDistance = (Vector3.Distance(hookedNode.transform.position, gameObject.transform.position));

                if (drawDevLine)
                {
                    grapplingLine.SetActive(true);
                }
            }

            return;
        }

        if(Input.GetMouseButtonUp(0) && hookedNode != null)
        {
            BreakTether();
        }
        return;
	}

    void FixedUpdate()
    {
        if (hookedNode != null && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = new Ray(gameObject.transform.position, (hookedNode.transform.position - gameObject.transform.position).normalized);
            if (disconnectOnLosBreak && Physics.Raycast(ray, out hit) && hit.collider.tag != "tetherPoint")
            {
                Debug.Log("LOS Break");
                BreakTether();
                return;
            }

            if (rb.velocity.magnitude > breakTetherVelo)
            {
                BreakTether();
                return;
            }

            if (drawDevLine)
            {
                Vector3[] lineVortexArr = { gameObject.transform.position, hookedNode.transform.position };
                grapplingLine.GetComponent<LineRenderer>().SetPositions(lineVortexArr);
            }

            Vector3 currentSpeed = rb.velocity * Time.fixedDeltaTime;
            Vector3 testPos = gameObject.transform.position + currentSpeed;

            if (grapplingHookMode == GrapplingHookMode.Ratcheting)
            {


                if (Vector3.Distance(testPos, hookedNode.transform.position) < nodeDistance)
                {
                    nodeDistance = Vector3.Distance(testPos, hookedNode.transform.position);
                }

                else
                {
                    ApplyTensionForce(currentSpeed, testPos);
                }
            }

            else if (grapplingHookMode == GrapplingHookMode.Loose)
            {
                if (Vector3.Distance(testPos, hookedNode.transform.position) > nodeDistance)
                {
                    ApplyTensionForce(currentSpeed, testPos);
                }
            }
            else
            {
                ApplyTensionForce(currentSpeed, testPos);
            }

           
        }
               return;
    }
    
    private void ApplyTensionForce(Vector3 currentSpeed, Vector3 testPos)
    {
        Vector3 nodeToTest = (testPos - hookedNode.transform.position).normalized;
        Vector3 newPos = (nodeToTest * nodeDistance) + hookedNode.transform.position;
        Vector3 newVelocity = newPos - gameObject.transform.position;

        Vector3 deltaVelocity = newVelocity - currentSpeed;
        Vector3 tensionForce = (rb.mass * (deltaVelocity / Time.fixedDeltaTime));
        rb.AddForce(tensionForce, ForceMode.Impulse);
    }

    public void ChangeGrapplingMode(GrapplingHookMode mode)
    {
        grapplingHookMode = mode;
        return;
    }

    public void BreakTether()
    {
        hookedNode = null;
        if (drawDevLine)
        {
            grapplingLine.SetActive(false);
        }
        return;
    }

    
}
