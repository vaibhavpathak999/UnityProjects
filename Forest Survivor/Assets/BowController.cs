using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowController : MonoBehaviour
{
    [SerializeField] Bow bow;
    public bool rotate;
    protected Plane plane;
    public bool isPanning = true;
    // new Camera variables
    //[SerializeField] Camera FPS_Camera;
    [SerializeField] Canvas FPS_UI_Canvas;
    //public bool isFPS = false;
    //public bool isMainCameraOn = false;
    //[SerializeField] GameObject FPS_Player_GameObject;
    //
    // implementing FPS Camera 

    //{
        //AllowPanning();
        //GetComponent<PowerUpButton>().PlayButtonSound();
        //FPS_Camera.GetComponent<Camera>().enabled = false;
        //GetComponent<PauseManagerScript>().EnableUICanvas();
        //cam.enabled = true;
        //cam.GetComponent<Camera>().enabled = true;
        //isMainCameraOn = true;
        //FPS_UI_Canvas.enabled = false;
    //}
    //public void PlayFPSCamera()
    //{
        //StopPanning();
        //GetComponent<PowerUpButton>().PlayButtonSound();
        //GetComponent<PauseManagerScript>().DisableUICanvas();
        //cam.enabled = false;
        //cam.GetComponent<Camera>().enabled = false;
        //FPS_Camera.enabled = true;
        //FPS_UI_Canvas.enabled = true;
        //FPS_Camera.GetComponent<Camera>().enabled = true;
        //isMainCameraOn = false;
    //}

    /*
    public void FPSPlayButton()
    {
        if (!GetComponent<HelperCanvas>().isAnyCanvasOpened)
        {
            if (GetComponent<CoinController>().is3DViewerEnabled)
            {
                if (isFPS)
                {
                    FPS_Player_GameObject.SetActive(false);
                    PlayMainCamera();
                    isFPS = false;
                }
                else
                {
                    FPS_Player_GameObject.SetActive(true);
                    PlayFPSCamera();
                    isFPS = true;
                }
            }
        }
    } */
    // 
    private void Update()
    {

        //Update Plane
        if (isPanning)
        {
            if (Input.touchCount >= 0)
                plane.SetNormalAndPosition(transform.up, transform.position);

            var Delta1 = Vector3.zero;
            var Delta2 = Vector3.zero;


            //Scroll
            /*
            if (Input.touchCount >= 1)
            {
                Delta1 = PlanePositionDelta(Input.GetTouch(0));
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    bow.transform.Translate(Delta1, Space.World);
                }
            }
            */
            //Pinch
            if (Input.touchCount >= 2 && cam.transform.position.y <= 40f && cam.transform.position.y >= 5f)
            {
                var pos1 = PlanePosition(Input.GetTouch(0).position);
                var pos2 = PlanePosition(Input.GetTouch(1).position);
                var pos1b = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
                var pos2b = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

                //calc zoom
                var zoom = Vector3.Distance(pos1, pos2) /
                           Vector3.Distance(pos1b, pos2b);

                //edge case
                //if (zoom == 0 || zoom > 10)
                    return;

            */
                //cam.transform.position = Vector3.LerpUnclamped(pos1, cam.transform.position, 1 / zoom);
                if (rotate && pos2b != pos2)
                    cam.transform.RotateAround(pos1, plane.normal, Vector3.SignedAngle(pos2 - pos1, pos2b - pos1b, plane.normal));
            }

            if (cam.transform.position.y > 30f)
                cam.transform.position = new Vector3(cam.transform.position.x, 30f, cam.transform.position.z);
            if (cam.transform.position.y < 5f)
                cam.transform.position = new Vector3(cam.transform.position.x, 5f, cam.transform.position.z);
            if (cam.transform.position.x > 30f)
                cam.transform.position = new Vector3(30f, cam.transform.position.y, cam.transform.position.z);
            if (cam.transform.position.x < -30f)
                cam.transform.position = new Vector3(-30f, cam.transform.position.y, cam.transform.position.z);
            if (cam.transform.position.z > 30f)
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 30f);
            if (cam.transform.position.z < -30f)
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -30f);
        }
    }

    protected Vector3 PlanePositionDelta(Touch touch)
    {
        //not moved
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        //delta
        var rayBefore = cam.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = cam.ScreenPointToRay(touch.position);
        if (plane.Raycast(rayBefore, out var enterBefore) && plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

        //not on plane
        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
        //position
        var rayNow = cam.ScreenPointToRay(screenPos);
        if (plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }

    public void StopPanning()
    {
        isPanning = false;
    }
    public void AllowPanning()
    {
        isPanning = true;
    }
}
