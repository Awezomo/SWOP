using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOClicked : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		gEventHandler.Logger = message => Debug.Log(message);
	}

    private void FixedUpdate()
    {
        GetComponent<Renderer>().material.color = new Color(Mathf.Sin(Time.time),
                                                            Mathf.Sin(Time.time / Mathf.PI), 
                                                            Mathf.Sin(Time.time + Mathf.PI / 3 * 2));
    }
    // Update is called once per frame
    void Update()
    {
		gEventHandler.Logger("hello world");
	}
}
