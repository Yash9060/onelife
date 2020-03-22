using UnityEngine;
using System.Collections;

public class GroundBlock : MonoBehaviour {

    public Transform otherBlock;
    public float halfLength = 181.2f;
    private Transform player;
    private float endOffset = 300f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        MoveGround();
	}

    void MoveGround()
    {
        if(transform.position.z + halfLength < player.transform.position.z - endOffset)
        {
            transform.position = new Vector3(otherBlock.position.x, otherBlock.position.y, otherBlock.position.z + (halfLength * 2));
        }
    }
}
