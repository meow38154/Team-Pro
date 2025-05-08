using System;
using UnityEngine;

namespace Main_Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public GameObject player;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}