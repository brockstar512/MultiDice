using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    public float smoothTime = 0.5f;

    public float minZoom = 80f;
    public float maxZoom = 20f;
    public float zoomLimiter = 50f;

    private Vector3 startPos;
    private Vector3 velocity;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        startPos = this.transform.position;
    }

    //todo write a reset function

    void LateUpdate()
    {
        if (targets.Count == 0)
            return;


        Move();
        Zoom();


    }
    private void Move()
    {
        Vector3 centerpoint = GetCenterPoint();
        Vector3 newPosition = centerpoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

    }

    void Zoom()
    {
   
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom,Time.deltaTime);
         
    }
    float GetGreatestDistance()
    {
        //using greatest distance between players

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count;i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.z;
    }

    Vector3 GetCenterPoint()
    {

        if (targets.Count == 0)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0;i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        //Debug.Log(bounds.center);
        return bounds.center;
    }

    [ContextMenu("reset Camera")]
    public void ResetCamera()
    {
        targets.Clear();
        this.transform.position = startPos;
    }
}
