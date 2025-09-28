using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public Canvas myCanvas;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M))
        {
            myCanvas.enabled = !myCanvas.enabled;
            toggleCursorLock();
        }
    }

    public static void toggleCursorLock()
    {
        // Lock the cursor to the center of the screen
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;    
        }

        // Hide the cursor
        Cursor.visible = !Cursor.visible;
    }
}
