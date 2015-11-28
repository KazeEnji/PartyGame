using UnityEngine;
using System.Collections;

public class Debugger : MonoBehaviour
{
    void Awake()
    {
        Debug.Log(this.transform.position);
    }

	// Update is called once per frame
	void Update ()
    {
        Debug.Log(this.transform.position);
    }
}
