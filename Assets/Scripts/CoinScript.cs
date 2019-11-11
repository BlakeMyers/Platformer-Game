using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject DestructionPoint;
    private void Start()
    {
        DestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }
    private void Update()
    {
        if (transform.position.y < DestructionPoint.transform.position.y)
        { 
            Destroy(gameObject);        
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("Scene Manager").GetComponent <UI_Controller>().numCoins += 1;
            Destroy(gameObject);
        }
    }
}
