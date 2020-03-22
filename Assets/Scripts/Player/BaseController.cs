using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour {

    public Vector3 speed;
    public float Health;
    public float x_speed = 8f, z_speed = 15f;
    public GameObject Hit_Effect,CollectEffect;
	void Awake () {
        speed = new Vector3(0f, 0f, z_speed);
	}

    protected void MoveLeft(){
        speed = new Vector3(-x_speed / 2f, 0f, speed.z);
    }

    protected void MoveRight(){
        speed = new Vector3(x_speed / 2f, 0f, speed.z);
    }

    protected void MoveStraight()
    {
        speed = new Vector3(0f, 0f, speed.z);
    }
/*
    protected void MoveNormal()
    {
        if (is_slow)
        {
            is_slow = false;
        }
        speed = new Vector3(speed.x, 0f, z_speed);

    }

    protected void MoveSlow()
    {
        if (!is_slow)
        {
            is_slow = true;
        }
        speed = new Vector3(speed.x, 0f, deccelerated);

    }

    protected void MoveFast()
    {
        speed = new Vector3(speed.x, 0f, accelerated);

    }
    */

}
