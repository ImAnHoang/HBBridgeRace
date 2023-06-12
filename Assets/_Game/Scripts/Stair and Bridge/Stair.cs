using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    private ColorType colorType;
    private ObjectColor objColor;

    private void Start()
    {
        objColor = GetComponent<ObjectColor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.tag = "Stair";

        colorType = other.GetComponent<PlayerController>().ColorType;
        objColor.ChangeColor(colorType);
        other.transform.position = new Vector3(other.transform.position.x, transform.position.y + 0.3f, other.transform.position.z);



    }

}
