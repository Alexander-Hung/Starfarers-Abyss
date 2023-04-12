using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public GameObject FirstPersonCam;
    public Camera fistCamera;
    public GameObject ThirdPersonCam;
    public CinemachineFreeLook thirdCamera;
    // Start is called before the first frame update
    void Start()
    {
        ThirdPersonCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (FirstPersonCam.activeSelf)
            {
                FirstPersonCam.SetActive(false);
                ThirdPersonCam.SetActive(true);
            }
            else
            {
                FirstPersonCam.SetActive(true);
                ThirdPersonCam.SetActive(false);
            }
        }

        CamZoom();

        CamBack();

    }

    private void CamZoom()
    {
        if (Input.GetKeyDown("mouse 1"))
        {
            if (FirstPersonCam.activeSelf)
            {
                fistCamera.fieldOfView = 20f;
            }
            else if (ThirdPersonCam.activeSelf)
            {
                thirdCamera.m_Lens.FieldOfView = 20f;
            }
        }
        
    }

    private void CamBack()
    {
        if (Input.GetKeyUp("mouse 1"))
        {
            if (FirstPersonCam.activeSelf)
            {
                fistCamera.fieldOfView = 60f;
            }
            else if (ThirdPersonCam.activeSelf)
            {
                thirdCamera.m_Lens.FieldOfView = 45f;
            }
        }
    }

    public GameObject GetFirstPersonCam()
    {
        return FirstPersonCam;
    }

    public GameObject GetThirdPersonCam()
    {
        return ThirdPersonCam;
    }

}
