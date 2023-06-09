﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject loadingPanel;
    public GameObject endingPanel;
    public GameObject levelPanel;

    public TextMeshProUGUI loadingText;
    public TextMeshProUGUI levelText;

    public Slider progressBar;
    private float loadingCount;
    public static int level;

    private void Awake()
    {
        level = PlayerPrefs.GetInt("level", 1);
    }
    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 1.0f;
        loadingCount = 0;
        // cho loading chỗ này. nhưng mà nó không có timedelta ở đây :>
    }

    // Update is called once per frame
    void Update()
    {
        /*LoadSceneGame(GameState.Loader);*/
        
    }

    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Aplication.Quit();
    #endif
    }

    public void NextLevelLoadScene()
    {
        PlayerPrefs.SetInt("level", level + 1);
        SceneManager.LoadScene(0);
    }

    public void LoadLoaderScene()
    {
        SceneManager.LoadScene(1);
        if (loadingCount <= 1f)
        {
            loadingCount += Time.deltaTime * 0.1f;
            progressBar.value = loadingCount;
            loadingText.text = ((int)(loadingCount * 100)).ToString() + "%";
        }
    }

    private void LoadSceneGame(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Loader:
                LoadLoaderScene();
                break;
            case GameState.Game:
                SceneManager.LoadScene(0);
                levelText.text = "LV: " + level.ToString();
                if (endingPanel.activeSelf == true)
                {
                    gameState = GameState.End;
                }
                break;
            case GameState.End:
                Time.timeScale = 0f;
                levelPanel.SetActive(true);
                break;
            default:
                break;
        }
    }

    private enum GameState
    {
        Loader,
        Game,
        End,
    }
}
