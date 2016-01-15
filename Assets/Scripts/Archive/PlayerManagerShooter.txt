using UnityEngine;
using System.Collections;

public class PlayerManagerShooter : MonoBehaviour 
{
    public Rigidbody bullet;
    public GameObject spawnLocation;
    public float speed = 10;

	// Use this for initialization
	void Start () 
    {
        Cursor.visible = false;
	}

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Rigidbody _clone = (Rigidbody)Instantiate(bullet, spawnLocation.transform.position, spawnLocation.transform.rotation);
            _clone.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
    }
}
