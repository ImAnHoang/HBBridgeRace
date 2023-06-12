using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{

    protected void CollectBrick(List<GameObject> brickList, GameObject brick, int brickLine)
    {
        brick.transform.DOMove(brickList[brickLine].transform.position, 0.2f).OnComplete(() => brick.gameObject.SetActive(false));
        brickList[brickLine].transform.gameObject.SetActive(true);
    }

    protected void TakeOffBrick(List<GameObject> brickList, int brickLine, GameObject collision)
    {
        brickList[brickLine].transform.gameObject.SetActive(false);
        collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    protected List<GameObject> GetBrickList(List<GameObject> brickList, string tagetTag, ColorType colorType)
    {

        GameObject[] brks = GameObject.FindGameObjectsWithTag(tagetTag);
        for (int i = 0; i < brks.Length; i++)
        {
            brks[i].GetComponent<ObjectColor>().ChangeColor(colorType);
            brks[i].gameObject.SetActive(false);
            brickList.Add(brks[i]);
        }
        return brickList;
    }
}
