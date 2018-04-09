using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision)
        {
            Debug.DrawLine(contact.point, contact.normal, Color.white, 5.0f, false);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
