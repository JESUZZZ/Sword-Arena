using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraControl : MonoBehaviour
{
    public List<Transform> target;
    public Vector3 offset;
    private Vector3 velocity;
    public float smoothTime;
    private float temp;
    public float minZoom;
    public float maxZoom;
    public float slowZoom;
    public float zoomLimiter;
    public float winOffset;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        if (PlayerControl.isStun || PlayerControl2.isStun)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, slowZoom, Time.deltaTime);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if ((LevelControl.p1HP > 0 && LevelControl.p2HP > 0) || (LevelControl.p1HP == 0 && LevelControl.p2HP == 0))
        {
            move();
            zoom();
        }
        else if (LevelControl.p1HP > 0 && LevelControl.p2HP <=0)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, slowZoom, Time.deltaTime);
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target[0].position.x,target[0].position.y+winOffset,transform.position.z), ref velocity, smoothTime);
        }
        else if (LevelControl.p1HP <= 0 && LevelControl.p2HP > 0)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, slowZoom, Time.deltaTime);
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target[1].position.x, target[1].position.y + winOffset, transform.position.z), ref velocity, smoothTime);
        }
    }

    void move()
    {
        Vector3 centerPoint = getCenter();
        transform.position = Vector3.SmoothDamp(transform.position, centerPoint + offset, ref velocity, smoothTime);
    }

    void zoom()
    {
        float zooming = Mathf.Lerp(maxZoom, minZoom, getDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zooming, Time.deltaTime);
    }

    Vector3 getCenter()
    {
        var bounds = new Bounds(target[0].position, Vector3.zero);
        for(int i = 0; i < target.Count; i++)
        {
            bounds.Encapsulate(target[i].position);
        }
        return bounds.center;
    }
    float getDistance()
    {
        var bounds = new Bounds(target[0].position, Vector3.zero);
        for (int i = 0; i < target.Count; i++)
        {
            bounds.Encapsulate(target[i].position);
        }
        return bounds.size.x + bounds.size.y;
    }
}
