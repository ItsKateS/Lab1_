using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    public GameObject gameObj;
    public int direction;
    void Update()
    {
        Vector3 localCenter = new Vector3(-1, 0.5f, 6);
        Vector3 globalCenter = gameObj.transform.TransformPoint(localCenter);
        gameObj.transform.RotateAround(globalCenter, Vector3.up * direction, 0.5f);
    }
}
