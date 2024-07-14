/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera cabinCamera;

    void Start()
    {
        mainCamera.enabled = true;
        cabinCamera.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCamera.enabled = !mainCamera.enabled;
            cabinCamera.enabled = !cabinCamera.enabled;
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    private int currentCameraIndex;
    private AudioListener[] audioListeners;

    void Start()
    {
        if (cameras.Length > 0)
        {
            audioListeners = new AudioListener[cameras.Length];

            for (int i = 0; i < cameras.Length; i++)
            {
                audioListeners[i] = cameras[i].GetComponent<AudioListener>();
            }

            currentCameraIndex = 0;
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].enabled = (i == currentCameraIndex);
                audioListeners[i].enabled = (i == currentCameraIndex);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cameras.Length > 0)
            {
                cameras[currentCameraIndex].enabled = false;
                audioListeners[currentCameraIndex].enabled = false;

                currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

                cameras[currentCameraIndex].enabled = true;
                audioListeners[currentCameraIndex].enabled = true;
            }
        }
    }
}
