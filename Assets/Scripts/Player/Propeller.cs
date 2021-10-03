using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{

    public float speed;

    void LateUpdate() {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        if(transform.rotation.y > 360) {
            transform.Rotate(transform.rotation.x, 0, transform.rotation.z);
        }
    }
}
