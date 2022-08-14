using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Quest.UI
{
    public class MainMenuScript : MonoBehaviour
    {
        private GameObject mainMenu;
        [SerializeField] private Button startGame;
        [SerializeField] private Button exitGame;

        [SerializeField] private string firstScene = "MainScene";

        private void Awake()
        {
            startGame.onClick.AddListener(StartGame);
            exitGame.onClick.AddListener(Exit);
        }

        private void Exit()
        {

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Aplication.Quit();
            #endif
        }

        private void StartGame()
        {
            SceneManager.LoadScene(firstScene);
        }

        void Start()
        {
            mainMenu = transform.Find("MainMenu").gameObject;
            mainMenu.SetActive(false);
            GameManager.IsMenu = false;
            Time.timeScale = 1;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainMenu.SetActive(!mainMenu.active);
                if (mainMenu.active) 
                {
                    Time.timeScale = 0;
                    GameManager.IsMenu = true;
                }
                else 
                {
                    Time.timeScale = 1;
                    GameManager.IsMenu = false;
                }
            }
        }
    }
}
