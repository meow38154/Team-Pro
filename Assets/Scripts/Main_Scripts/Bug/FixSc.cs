using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class FixSc : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.sKey.isPressed && Keyboard.current.cKey.isPressed && Keyboard.current.f1Key.wasPressedThisFrame)
        {
            SceneManager.LoadScene(7);
        }

        if (Keyboard.current.sKey.isPressed && Keyboard.current.cKey.isPressed && Keyboard.current.f2Key.wasPressedThisFrame)
        {
            SceneManager.LoadScene(8);
        }

        if (Keyboard.current.sKey.isPressed && Keyboard.current.cKey.isPressed && Keyboard.current.f3Key.wasPressedThisFrame)
        {
            SceneManager.LoadScene(9);
        }

        if (Keyboard.current.sKey.isPressed && Keyboard.current.cKey.isPressed && Keyboard.current.f4Key.wasPressedThisFrame)
        {
            SceneManager.LoadScene(10);
        }

        if (Keyboard.current.sKey.isPressed && Keyboard.current.cKey.isPressed && Keyboard.current.f5Key.wasPressedThisFrame)
        {
            SceneManager.LoadScene(11);
        }
    }
}
