using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections;

namespace Main_Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public PlayerMovement player;

        public Transform trm;

        public static bool reset;

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
                reset = true;
                StartCoroutine(ChogiHa());
            }
        }

        IEnumerator ChogiHa()
        {
            yield return new WaitForSeconds(0.1f);
            reset = false;
        }
    }
}