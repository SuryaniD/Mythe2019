using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvasPC;

    [SerializeField]
    private Canvas canvasVR;

    private bool menuActive = false;

    public void ActivateMenu()
    {
        if (!menuActive)
            SetMenu(true);
    }

    public void DeactivateMenu()
    {
        if (menuActive)
            SetMenu(false);
    }

    void SetMenu(bool _value)
    {
        menuActive = _value;
        if (SceneManager.GetActiveScene().buildIndex == 0)
            canvasPC.gameObject.SetActive(_value);
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            canvasVR.gameObject.SetActive(_value);
            canvasVR.gameObject.transform.parent.position = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        }
    }
}
