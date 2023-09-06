using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trencontrl : MonoBehaviour
{
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.right*Time.deltaTime*force);
    }
}
