using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SBUG : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(0);
        }
    }
}
