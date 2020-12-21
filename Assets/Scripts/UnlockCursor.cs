using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		LockCursor(false);
    }

	private void LockCursor(bool isLocked)
	{
		if (isLocked)
		{
			// make the mouse pointer invisible
			Cursor.visible = false;

			// lock the mouse pointer within the game area
			Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			// make the mouse pointer visible
			Cursor.visible = true;

			// unlock the mouse pointer so player can click on other windows
			Cursor.lockState = CursorLockMode.None;
		}
	}


}
