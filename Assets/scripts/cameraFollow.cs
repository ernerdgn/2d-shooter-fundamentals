using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    private Vector3 mousePosition;
    private Vector3 cameraOffset;
    private Camera cam;
    private GameObject cameraHolder;
    public float cameraSpeed;
    public float multi;

    void Start()
    {
        cam = GetComponent<Camera>();
        cameraHolder = transform.parent.gameObject;
    }

    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        cameraOffset = (mousePosition - playerPosition.position) / multi;
    }

    private void LateUpdate()
    {
        cameraHolder.transform.position = 
            Vector3.Lerp(cameraHolder.transform.position, 
            playerPosition.position + cameraOffset, cameraSpeed * Time.deltaTime);
    }
}
