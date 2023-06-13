using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject Target;

    public Vector3 MinDistance;
    public Quaternion CamRotation;

    void Start()
    {
        Target = GameObject.Find("Player");
    }


    void Update()
    {
        this.transform.position = Target.transform.position + MinDistance;
        this.transform.rotation = CamRotation;
    }
}
