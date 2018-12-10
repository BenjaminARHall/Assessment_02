using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;




public class HookFinal : MonoBehaviour
{
    public Transform camera;

    public GameObject hookPoint;
    public Rigidbody player;
    public bool hooked = false;
    private RaycastHit hit;
    public float boost;
    public bool detectCollisions;
    //public float minD;
    //public float maxD;
    //public float damper;
    //public float spring;
    public Rigidbody rb;
    public RigidbodyFirstPersonController cc;

    private HingeJoint joint;
    private MouseLook mouseLook;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mouseLook = cc.mouseLook;

        // rb.isKinematic = false;
        // rb.useGravity = true;
    }

    public void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camera.position, camera.forward, out hit) && (hit.transform.tag == "tetherPoint"))
            {
                Debug.Log("Hit");
                hookPoint = hit.collider.gameObject;
                DoJoint();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            UndoJoint();
        }

        //if (hookPoint)
        //{
        //    transform.position += hingeSim.transform.localPosition;
        //    hingeSim.transform.localPosition = Vector3.zero;
        //}
    }

    public void DoJoint()
    {
        hooked = !hooked;
        if (hooked)
        {
            cc.m_Jump = true;
            player.AddForce(Vector3.up * boost);
            StartCoroutine(Hooked());
        }
        else
        {
            Destroy(joint);
            //  rb.constraints = RigidbodyConstraints.None;
            // rb.isKinematic = false;
        }

    }

    IEnumerator Hooked()
    {
        yield return new WaitForSeconds(0.5f);
        // rb.isKinematic = true;
        joint = hookPoint.AddComponent<HingeJoint>();
        mouseLook.joint = joint;
        joint.connectedBody = rb;

        if (Input.GetMouseButtonUp(0))
        {
            UndoJoint();
        }
        // cc.mouseLook.XSensitivity = 0;
        //  cc.mouseLook.YSensitivity = 0;
        //  rb.constraints = RigidbodyConstraints.FreezeRotationY;
        // rb.constraints = RigidbodyConstraints.FreezeRotationZ;

        // hookPoint.GetComponent<SpringJoint>().minDistance = minD;
        // hookPoint.GetComponent<SpringJoint>().maxDistance = maxD;
        // hookPoint.GetComponent<SpringJoint>().damper = damper;
        // hookPoint.GetComponent<SpringJoint>().spring = spring;
        // hookPoint.GetComponent<SpringJoint>().enablePreprocessing = true;

        yield break;
    }

    public void UndoJoint()
    {
        rb.isKinematic = false;
        hooked = !hooked;
        hookPoint = null;
        Destroy(joint);
        // cc.mouseLook.XSensitivity = 5;
        // cc.mouseLook.YSensitivity = 5;
        // rb.constraints = RigidbodyConstraints.None;
    }


}
