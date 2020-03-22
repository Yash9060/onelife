using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.name == "space_man_model")
    //    {

    //        GameplayController.instance.FncCollectCoins();
    //        Destroy(this.gameObject);
    //    }
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameplayController.instance.FncCollectCoins();
            Destroy(this.gameObject);
        }
    }



    void FncReactive()
    {
        this.gameObject.SetActive(true);
    }
}


