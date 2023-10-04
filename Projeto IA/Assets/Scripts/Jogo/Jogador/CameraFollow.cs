using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{

    public Transform target;
    void Update(){
        Vector2 newPos = new Vector2(target.position.x, target.position.y);
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
