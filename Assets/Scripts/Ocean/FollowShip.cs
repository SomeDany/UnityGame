using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{

    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(target.position.x -70, transform.position.y, target.position.z -70);
        transform.position = position;
    }
}
