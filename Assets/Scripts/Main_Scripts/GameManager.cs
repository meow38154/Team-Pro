using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Main_Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public UnityEvent ManagerEvent;

        private void Awake()
        {
            ManagerEvent = new UnityEvent();

            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            DontDestroyOnLoad(this);
        }

        public void Reset1()
        {
            Debug.Log("Reset1 호출됨, 이벤트 실행");
            ManagerEvent?.Invoke();
        }
    }
}
