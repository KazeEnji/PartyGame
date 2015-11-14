using UnityEngine;
using System.Collections;

public class PlayerThirdPersonMove : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    private CharacterController playerCC;

    private Vector3 sideways;
    private Vector3 forward;

    private float axisVSpeed;
    private float axisHSpeed;

    void Awake()
    {
        playerCC = transform.GetComponent<CharacterController>();

    }

    void Update()
    {
        forward = transform.TransformDirection(Vector3.forward);
        sideways = transform.TransformDirection(Vector3.right);

        axisVSpeed = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        axisHSpeed = speed * Input.GetAxis("Horizontal") * Time.deltaTime;

        //playerCC.SimpleMove(forward * axisVSpeed);
        //playerCC.SimpleMove(sideways * axisHSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody _tempRB = GetComponent<Rigidbody>();
            _tempRB.AddForce(Vector3.up * jumpSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    /* Translation example for movement. Better movement is 
     * physics  based.
    void Update()
    {
        float translationV = Input.GetAxis("Vertical") * speed;
        float translationH = Input.GetAxis("Horizontal") * speed;

        translationV *= Time.deltaTime;
        translationH *= Time.deltaTime;

        transform.Translate(translationH, 0, translationV);
    }
     */
}
