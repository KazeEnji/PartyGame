using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiceStatus : MonoBehaviour
{
    [SerializeField] private int diceRollValue;
    [SerializeField] private int waitTime = 3;

    [SerializeField] private float randomX, randomY, randomZ;
    [SerializeField] private float diceThrowForce;
    [SerializeField] private float currentVelocity;

    [SerializeField] private GameObject throwDiceLocation;
    [SerializeField] private GameObject mainBoardLGM;

    [SerializeField] private Rigidbody diceRB;

    private void Awake()
    {
        throwDiceLocation = GameObject.Find("ThrowDiceLocation");
        mainBoardLGM = GameObject.FindGameObjectWithTag("LGM");
        diceRB = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        currentVelocity = diceRB.velocity.magnitude;

        if(currentVelocity == 0)
        {
            DetermineDiceRoll();
            mainBoardLGM.GetComponent<MainBoardLocalManager>().SetDiceValueToList(diceRollValue);
            this.gameObject.SetActive(false);
        }
    }

    public void Roll()
    {
        if(throwDiceLocation != null)
        {
            this.transform.position = throwDiceLocation.transform.position;
            this.transform.rotation = throwDiceLocation.transform.rotation;

            this.gameObject.SetActive(true);

            diceThrowForce = Random.Range(25, 30);

            diceRB.AddForce(Vector3.forward * diceThrowForce, ForceMode.Impulse);

            randomX = Random.Range(-5, 5);
            randomY = Random.Range(-5, 5);
            randomZ = Random.Range(-5, 5);

            diceRB.AddTorque(randomX, randomY, randomZ, ForceMode.Impulse);
        }
    }

    private void DetermineDiceRoll()
    {
        if (Vector3.Dot(transform.forward, Vector3.up) >= 1)
        {
            diceRollValue = 1;
        }
        else if (Vector3.Dot(-transform.forward, Vector3.up) >= 1)
        {
            diceRollValue = 6;
        }
        else if (Vector3.Dot(transform.up, Vector3.up) >= 1)
        {
            diceRollValue = 5;
        }
        else if (Vector3.Dot(-transform.up, Vector3.up) >= 1)
        {
            diceRollValue = 2;
        }
        else if (Vector3.Dot(transform.right, Vector3.up) >= 1)
        {
            diceRollValue = 4;
        }
        else if (Vector3.Dot(-transform.right, Vector3.up) >= 1)
        {
            diceRollValue = 3;
        }
    }
}
