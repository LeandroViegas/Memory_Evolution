using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target;
    public int warning = 0;

    private void Update()
    {
        if (Target)
        {
            Vector3 newPosition = Target.position;
            newPosition.z = -10;
            transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        }
        else
            if (warning > 0)
            {
                Debug.Log("Target não encontrado");
                warning += 1;
            }
             
    }
}
