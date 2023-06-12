using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] GameObject Maxtrix_Brick1;
    [SerializeField] GameObject Maxtrix_Brick2;
    private void Start()
    {
        OnInit();   
    }
    private void OnTriggerEnter(Collider other)
    {
        Maxtrix_Brick2.SetActive(true);
        other.gameObject.GetComponent<PlayerController>().FloorCount++;
        if (other.gameObject.GetComponent<PlayerController>().ColorType == ColorType.Blue)
        {
            for (int i = 0; i < Maxtrix_Brick2.transform.childCount; i++)
            {
                if (Maxtrix_Brick2.transform.GetChild(i).gameObject.GetComponent<ObjectColor>().GetColorType() == ColorType.Blue)
                {
                    Maxtrix_Brick2.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
                    Maxtrix_Brick2.transform.GetChild(i).gameObject.tag = "Brick";
                }
             
            }
            for (int i = 0; i < Maxtrix_Brick1.transform.childCount; i++)
            {
                if (Maxtrix_Brick1.transform.GetChild(i).gameObject.GetComponent<ObjectColor>().GetColorType() == ColorType.Blue)
                {
                    Destroy(Maxtrix_Brick1.transform.GetChild(i).gameObject); 
                }
            }
        }
        if (other.gameObject.GetComponent<PlayerController>().ColorType == ColorType.Red)
        {
            
            for (int i = 0; i < Maxtrix_Brick2.transform.childCount; i++)
            {
                if (Maxtrix_Brick2.transform.GetChild(i).gameObject.GetComponent<ObjectColor>().GetColorType() == ColorType.Red)
                {
                    Maxtrix_Brick2.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
                    Maxtrix_Brick2.transform.GetChild(i).gameObject.tag = "Brick";
                }
            }
            for (int i = 0; i < Maxtrix_Brick1.transform.childCount; i++)
            {
                if (Maxtrix_Brick1.transform.GetChild(i).gameObject.GetComponent<ObjectColor>().GetColorType() == ColorType.Red)
                {
                    Destroy(Maxtrix_Brick1.transform.GetChild(i).gameObject);
                }
            }
        }
        if (other.gameObject.GetComponent<PlayerController>().ColorType == ColorType.Green)
        {
            
            for (int i = 0; i < Maxtrix_Brick2.transform.childCount; i++)
            {
                if (Maxtrix_Brick2.transform.GetChild(i).gameObject.GetComponent<ObjectColor>().GetColorType() == ColorType.Green)
                {
                    Maxtrix_Brick2.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
                    Maxtrix_Brick2.transform.GetChild(i).gameObject.tag = "Brick";
                }
            }
            for (int i = 0; i < Maxtrix_Brick1.transform.childCount; i++)
            {
                if (Maxtrix_Brick1.transform.GetChild(i).gameObject.GetComponent<ObjectColor>().GetColorType() == ColorType.Green)
                {
                    Destroy(Maxtrix_Brick1.transform.GetChild(i).gameObject);
                }
            }
        }

    }
    private void CloseDor()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Bridge");
        foreach (GameObject item in obj)
        {
            item.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            item.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnInit()
    {
        
        for (int i = 0; i < Maxtrix_Brick2.transform.childCount; i++)
        {
            Maxtrix_Brick2.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
