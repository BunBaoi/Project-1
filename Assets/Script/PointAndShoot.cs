using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    private Vector3 target; // Mouse position

    private Crosshair controls;
    private Camera mainCamera;

    private void Awake()
    {
        controls = new Crosshair();
        Cursor.lockState = CursorLockMode.Confined;
    }



    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        Cursor.visible = false;
        controls.Mouse.LClick.started += _ => StartedClick();
        controls.Mouse.LClick.performed += _ => EndedClick();
    }

    private void StartedClick()//Change click beginning
    {

    }
    private void EndedClick()//Change click ending
    {

    }
    
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        if (Input.GetMouseButtonDown(0))
        {
            //fire bullet

        }
    }
    
    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Debug.Log("3D Hit: " + hit.collider.tag);
            }
        }
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
    }

}
