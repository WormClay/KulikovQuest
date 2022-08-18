using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Quest.UI
{
    public class MainMenuScript : MonoBehaviour
    {
        private GameObject mainMenu;
        [SerializeField] private Button startGame;
        [SerializeField] private Button exitGame;
        [SerializeField] private Slider slider;
        //[SerializeField] private AudioMixer audioMixer;
        [SerializeField] private string firstScene = "MainScene";

        private void Awake()
        {
            startGame.onClick.AddListener(StartGame);
            exitGame.onClick.AddListener(Exit);
            slider.value = 100;
            AudioListener.volume = slider.value;
            
            slider.onValueChanged.AddListener(value => AudioListener.volume = value);
        }

        /*public void SetVolume(float volume)
        {
            audioMixer.SetFloat("MasterVolume", volume);
        }*/


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
            Inventar.ClearInventar();
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
