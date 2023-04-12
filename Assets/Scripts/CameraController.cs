using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float mouseSensitivity = 2f;
    private float cameraRotationVertical = 0f;

    bool CursorLock = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(Time.timeScale == 1)
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            cameraRotationVertical -= inputY;
            cameraRotationVertical = Mathf.Clamp(cameraRotationVertical, -45f, 45f);
            transform.localEulerAngles = Vector3.right * cameraRotationVertical;

            player.Rotate(Vector3.up * inputX);
        }

        if (Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
