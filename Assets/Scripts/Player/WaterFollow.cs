using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFollow : MonoBehaviour
{

    Transform player;

    void Awake() {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
    }
}
