using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LookAtTransform : MonoBehaviour
{
    Camera m_Camera;
    Quaternion editorCamRot;

    // Update is called once per frame
    /*void Update()
    {
        _LookAtSceneCamera();
    }

    void _LookAtSceneCamera()
    {
        editorCamRot = SceneView.lastActiveSceneView.rotation;

        transform.LookAt(transform.position + editorCamRot * Vector3.forward, editorCamRot * Vector3.up);
    }*/
}
