using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_generator : MonoBehaviour
{
    public GameObject platform1;
    public GameObject spikes;
    public Transform spikePlacer;
    public Transform generationPoint;
    public float distancebetween;
    public float platformWidth;
    public float xmin = -3.5f;
    public float xmax = 3.5f;
    public float smin = -2.0f;
    public float smax = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platform1.GetComponent<BoxCollider2D>().size.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < generationPoint.position.y)
        {
            transform.position = new Vector3(Random.Range(xmin,xmax), transform.position.y + platformWidth + distancebetween, transform.position.z);
            spikePlacer.position = new Vector3(transform.position.x + Random.Range(smin,smax), transform.position.y + platformWidth + distancebetween, transform.position.z);
            Instantiate(spikes, spikePlacer.position, transform.rotation);
            Instantiate(platform1, transform.position, transform.rotation);
            
        }
    }
}
