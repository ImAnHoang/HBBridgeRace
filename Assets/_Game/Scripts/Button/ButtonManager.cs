using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{

    [SerializeField] GameObject Starts;
    [SerializeField] GameObject Reset;
    [SerializeField] GameObject Nexts;
    [SerializeField] GameObject JoyStick;
    [SerializeField] GameObject TextLevel;

    private static int  level;


    private PlayerMovement playerMove;



    private void Start()
    {

        level = 1;
        PlayerPrefs.SetInt("Level", level);
        TextLevel.gameObject.GetComponent<Text>().text = "Level: " + PlayerPrefs.GetInt("Level");
        Starts.SetActive(true);
        Reset.SetActive(false);
        Nexts.SetActive(false);
        playerMove = FindObjectOfType<PlayerMovement>();
    }
    public void StartGame()
    {
        JoyStick.SetActive(true);
        playerMove.variableJoystick = FindObjectOfType<DynamicJoystick>();
        Time.timeScale = 1;
        Starts.transform.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        JoyStick.SetActive(true);
        TextLevel.gameObject.GetComponent<Text>().text = "Level: " + PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        
        level++;
        PlayerPrefs.SetInt("Level", level);
        Debug.Log("Level: " + PlayerPrefs.GetInt("Level"));
        JoyStick.SetActive(true);
        TextLevel.gameObject.GetComponent<Text>().text = "Level: " + PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
