using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOriginalPos : MonoBehaviour
{
    [SerializeField]
    private float checkTimeInterval;
    [SerializeField]
    private float outCameraTime;

    private Vector3 originalPos;
    private Renderer objectRenderer;

    private static WaitForSeconds waitForSeconds;

    private IEnumerator currCoroutine;

    private void Awake()
    {
        originalPos = transform.position;
        objectRenderer = GetComponent<Renderer>();

        if(objectRenderer == null)
        {
            objectRenderer = GetComponentInChildren<Renderer>();
        }

        waitForSeconds = new WaitForSeconds(checkTimeInterval);
    }

    private void Start()
    {
        //Invoke("StartCheckOutCameraCoroutine", 3f);
    }

    private void StartCheckOutCameraCoroutine()
    {
        StartCoroutine(CheckOutCameraCoroutine());
    }

    private IEnumerator CheckOutCameraCoroutine()
    {
        Debug.Log("CheckOutCameraCoroutine");

        float time = 0f;
        bool stateChanged = objectRenderer.isVisible;

        while (true)
        {
            Debug.Log(objectRenderer.isVisible);
            if(stateChanged != objectRenderer.isVisible)
            {
                time = 0f;
                stateChanged = objectRenderer.isVisible;
            }
            
            if(!objectRenderer.isVisible)
            {
                time += Time.deltaTime;

                if (time > outCameraTime)
                {
                    transform.position = originalPos;
                    time = 0f;
                }

                yield return null;
            }
            else
            {
                yield return waitForSeconds;
            }
        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible");
    }

    private void OnBecameVisible()
    {
        Debug.Log("OnBecameVisible");
    }
}
