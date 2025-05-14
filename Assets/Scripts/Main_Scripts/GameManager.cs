using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Main_Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public PlayerMovement player;

        public Transform trm;

        public UnityEvent ManagerEvent = new UnityEvent();

        private void Awake()
        {


            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(gameObject);
            }
                DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (Keyboard.current.rKey.wasPressedThisFrame && Keyboard.current.fKey.isPressed)
            {
                ManagerEvent?.Invoke();
            }
        }

    }
}