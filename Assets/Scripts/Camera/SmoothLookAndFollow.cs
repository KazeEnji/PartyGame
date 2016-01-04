using UnityEngine;
using System.Collections;

public class SmoothLookAndFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float smoothingRate = 5;

    private void Update()
    {
        this.transform.LookAt(target);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
