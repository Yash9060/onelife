using UnityEngine;
using System.Collections;

public class PlayerController : BaseController {

    private Rigidbody myBody;


	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        ControlMovementWithKeyboard();
	}

    void FixedUpdate()
    {
        MoveTank();
    }

    void MoveTank()
    {
        myBody.MovePosition(myBody.position + speed * Time.deltaTime);
    }

    void ControlMovementWithKeyboard()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }


        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            MoveStraight();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            MoveStraight();
        }

    }
}
