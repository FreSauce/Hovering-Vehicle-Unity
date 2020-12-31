using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset = new Vector3();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rotationVector = player.rotation.eulerAngles;
        rotationVector.z = 0;
        rotationVector.x = 0;
        transform.rotation = Quaternion.Euler(rotationVector);
        transform.position = player.position + offset; 
    }
}
