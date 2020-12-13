using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSelfRotation : MonoBehaviour
{
    [SerializeField] private float rotX, rotY, rotZ;
    private void Update()
    {
        transform.Rotate(rotX * Time.deltaTime, rotY * Time.deltaTime, rotZ * Time.deltaTime);
    }
}
