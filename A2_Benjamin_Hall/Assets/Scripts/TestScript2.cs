using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript2 : MonoBehaviour {

    public GameObject tether;
    public GameObject gun;

    public bool tetherTravelSpeed;
    public bool playerTravelSpeed;

    public static bool fired;
    public bool tethered;
    public GameObject tetherTarget;

    public float maxDistance;
    public float currentDistance;

    private bool grounded;
    public Vector3 origin;

    public Texture2D reticle;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private Vector3 previousPosition;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
