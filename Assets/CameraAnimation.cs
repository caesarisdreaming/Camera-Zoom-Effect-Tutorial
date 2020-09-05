using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{

    [SerializeField] float zoomInSpeed = 1f;
    [SerializeField] float zoomOutSpeed = 1f;
    [SerializeField] float targetZoomIn = .3f;

    float initalZoom = 0f;
    float initialPosX;
    float initialPosY;

    public static bool IsZoomedIn = false;
    public static bool IsZoomedOut = false;

    Transform target;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        initalZoom = cam.orthographicSize;
        initialPosX = cam.transform.position.x;
        initialPosY = cam.transform.position.y;
    }

    public void ZoomInCamera(Transform target)
    {
        if (!IsZoomedIn)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoomIn, Time.deltaTime * zoomInSpeed);
            cam.transform.position = new Vector3(Mathf.Lerp(cam.transform.position.x, target.position.x, Time.deltaTime * zoomInSpeed),
                Mathf.Lerp(cam.transform.position.y, target.position.y, Time.deltaTime * zoomInSpeed), 
                cam.transform.position.z);
            if (cam.orthographicSize - targetZoomIn <= .001f)
            {
                IsZoomedIn = true;
            }
        }
    }

    public void ZoomOutCamera()
    {
        if (IsZoomedIn)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, initalZoom, Time.deltaTime * zoomOutSpeed);
            cam.transform.position = new Vector3(Mathf.Lerp(cam.transform.position.x, initialPosX, Time.deltaTime * zoomOutSpeed),
                Mathf.Lerp(cam.transform.position.y, initialPosY, Time.deltaTime * zoomOutSpeed),
                cam.transform.position.z);
            if (initalZoom - cam.orthographicSize <= .05f)
            {
                IsZoomedIn = false;
                IsZoomedOut = true;
                cam.orthographicSize = initalZoom;
                cam.transform.position = new Vector3(initialPosX, initialPosY, cam.transform.position.z);
            }
        }
    }

}
