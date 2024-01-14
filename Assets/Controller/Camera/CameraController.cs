using UnityEngine;
using Core;
using Math;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CameraSettings CameraValues;

    private void Update()
    {
        CheckMouseEdgePan();
        CheckMouseZoom();
    }

    private void CheckMouseEdgePan()
    {
        Vector3 pos = transform.position;
        bool shouldPan = false;

        if (Input.mousePosition.y >= Screen.height - CameraValues.edgePanBorder)
        {
            pos.z += CameraValues.edgePanSpeed * Time.deltaTime;
            shouldPan = true;
        }
        if (Input.mousePosition.y <= CameraValues.edgePanBorder)
        {
            pos.z -= CameraValues.edgePanSpeed * Time.deltaTime;
            shouldPan = true;
        }
        if (Input.mousePosition.x >= Screen.width - CameraValues.edgePanBorder)
        {
            pos.x += CameraValues.edgePanSpeed * Time.deltaTime;
            shouldPan = true;
        }
        if (Input.mousePosition.x <= CameraValues.edgePanBorder)
        {
            pos.x -= CameraValues.edgePanSpeed * Time.deltaTime;
            shouldPan = true;
        }

        if (shouldPan)
        {
            pos.x = Mathf.Clamp(pos.x, -CameraValues.edgePanLimit.x, CameraValues.edgePanLimit.x);
            pos.z = Mathf.Clamp(pos.z, -CameraValues.edgePanLimit.y, CameraValues.edgePanLimit.y);

            PanCamera(pos);
        }
    }

    private void CheckMouseZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > Mathf.Epsilon)
        {
            Vector3 pos = transform.position;

            pos.y -= scroll * CameraValues.zoomSpeed * 100f * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, CameraValues.zoomMiny, CameraValues.zoomMaxy);

            ZoomCamera(pos.y);
        }
    }

    private void PanCamera(Vector3 destination)
    {
        transform.position = AnimMath.Lerp(transform.position, destination, CameraValues.edgePanSpeed * Time.deltaTime, false);
    }

    private void ZoomCamera(float zoom)
    {
        float newY = AnimMath.Lerp(transform.position.y, zoom, CameraValues.zoomSpeed * Time.deltaTime, false);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
