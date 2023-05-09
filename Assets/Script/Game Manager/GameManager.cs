using System.Collections;
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

    public Slider ProgressBar;
    private float loadingCount;
    public static int level;
    public  bool isLoading { get; private set; }

    private void Awake()
    {
        level = PlayerPrefs.GetInt("level", 1);
        isLoading = true;
    }
    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 1.0f;
        loadingCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //UI loading
        if(isLoading)
        {
            if (loadingCount <= 1f)
            {
                loadingCount += Time.deltaTime * 0.1f;
                ProgressBar.value = loadingCount;
                loadingText.text = ((int)(loadingCount * 100)).ToString() + "%";
                levelPanel.SetActive(false);
            }
            isLoading = false;
        }
        else
        {
            loadingPanel.SetActive(false);
            levelPanel.SetActive(true);
        }

        if (endingPanel.activeSelf == true)
        {
            Time.timeScale = 0f;
            levelPanel.SetActive(true);
        }
        //UI level
        levelText.text = "LV: " + level.ToString();    
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
        isLoading = false;
    }
}
