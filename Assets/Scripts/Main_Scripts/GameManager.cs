using System;
using UnityEngine;

namespace Main_Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public PlayerMovement player;

        public Transform trm;
  
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

        
    }
}