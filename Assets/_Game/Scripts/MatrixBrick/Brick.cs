using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    private Vector3 brickPosition;

    private ColorType colorType;

    private ObjectColor objColor;

    private ColorType currentColorType;

    public ColorType ColorType => colorType;
    private void Start()
    {
        brickPosition = transform.position;
        colorType = ColorType.None;
        objColor = GetComponent<ObjectColor>();
        currentColorType = objColor.GetColorType();

    }
    private void ResetBrick()
    {
        this.gameObject.SetActive(true);
        transform.position = brickPosition;
        //int random = Random.Range(1, 4);
        //switch (random)
        //{
        //    case 1:
        //        colorType = ColorType.Blue;
        //        objColor.ChangeColor(colorType);
        //        break;
        //    case 2:
        //        colorType = ColorType.Red;
        //        objColor.ChangeColor(colorType);
        //        break;
        //    case 3:
        //        colorType = ColorType.Green;
        //        objColor.ChangeColor(colorType);
        //        break;
        //}
    }


    private void RandomBrick()
    {
        this.gameObject.SetActive(true);
        transform.position = brickPosition;
        int random = Random.Range(1, 4);
        switch (random)
        {
            case 1:
                colorType = ColorType.Blue;
                objColor.ChangeColor(colorType);
                break;
            case 2:
                colorType = ColorType.Red;
                objColor.ChangeColor(colorType);
                break;
            case 3:
                colorType = ColorType.Green;
                objColor.ChangeColor(colorType);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<PlayerController>().ColorType == currentColorType)
        {

            if (other.gameObject.GetComponent<PlayerController>().FloorCount == 1)
            {
                Invoke(nameof(RandomBrick), 10f);
            }
            else
            {
                Invoke(nameof(ResetBrick), 10f);
            }
        }
    }
}


