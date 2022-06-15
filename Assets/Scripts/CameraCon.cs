using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    private Transform playerPos;
    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -22.62f, 22.62f), Mathf.Clamp(transform.position.y, -15.59f, 15.59f), transform.position.z);
    }
}
