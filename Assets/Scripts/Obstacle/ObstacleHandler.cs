using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameplayController.instance.FncTakeDamage(10);
            Destroy(this.gameObject);
        }
    }
}
