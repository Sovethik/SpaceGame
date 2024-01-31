using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLeftPush : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;


  
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 1, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }
}
