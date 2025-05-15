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

        public static bool reset;

        


        private void Awake()
        {
            if (ManagerEvent == null)
            {
                ManagerEvent = new UnityEvent();
            }


            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(gameObject);
            }
                DontDestroyOnLoad(this);
          

        }

       

        public void Reset1()
        {
          
                ManagerEvent?.Invoke();
           
        }

    }
}