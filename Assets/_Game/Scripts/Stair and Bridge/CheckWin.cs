using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckWin : MonoBehaviour
{


    [SerializeField] GameObject TextMesh;
    [SerializeField] GameObject Reset;
    [SerializeField] GameObject Nexts;
    [SerializeField] GameObject JoyStick;

    private void OnTriggerEnter(Collider other)
    {
        TextMesh.SetActive(true);
        
        JoyStick.SetActive(false);
        TextMesh.gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
        
        if (other.gameObject.GetComponent<PlayerController>().ColorType == ColorType.Red)
        {
            Nexts.SetActive(false);
            Reset.SetActive(true);
            TextMesh.gameObject.GetComponent<Text>().text = "Red Player Win The Game !";
            
        }
        if (other.gameObject.GetComponent<PlayerController>().ColorType == ColorType.Blue)
        {
            Nexts.SetActive(true);
            Reset.SetActive(false); 
            TextMesh.gameObject.GetComponent<Text>().text = "Blue Player Win The Game !";
            
        }
        if (other.gameObject.GetComponent<PlayerController>().ColorType == ColorType.Green)
        {
            Nexts.SetActive(false);
            Reset.SetActive(true);
            TextMesh.gameObject.GetComponent<Text>().text = "Green Player Win The Game !";
        }

        Time.timeScale = 0;



    }
}