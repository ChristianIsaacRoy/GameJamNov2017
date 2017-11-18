using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed =10;
    private Rigidbody2D rigidBody
    private bool Up;
    private bool Down;
    private bool Left;
    private bool Righ;


    private void Awake()
    {
        rigidbody = GetComponent.rigidbody2D();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

     Up = Input.GetButtonDown("D-Pad Up");
     Down = Input.GetButtonDown("D-Pad Down");
     Left = Input.GetButtonDown("D-Pad Left");
     Right = Input.GetButtonDown("D-Pad Right");
}

    void PlayerInput()
    {
        if (Down = true)
        {
            rigidbody.
        }

    }





}
