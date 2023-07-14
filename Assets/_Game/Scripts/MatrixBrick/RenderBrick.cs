using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RenderBrick : MonoBehaviour
{

    private GameObject tmp_brick;

    private GameObject[,] Maxtrix_Bricks;

    private ColorType colorType;

    private ObjectColor objColor;


    void Start()
    {
        OnInit();
        CreateBrick();
    }

    
    private void OnInit()
    {
        
        Maxtrix_Bricks = new GameObject[10, 9];
        colorType = ColorType.None;
        
    }

    private void CreateBrick()
    {
        //tmp_brick = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Game/Prefabs/BrickDefault.prefab");
        tmp_brick = Resources.Load<GameObject>("BrickDefault");
        int red_brick = 0;
        int blue_brick = 0;
        int green_brick = 0;

        List<Vector2Int> positions = new List<Vector2Int>();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                positions.Add(new Vector2Int(i, j));
            }
        }

        int n = positions.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Vector2Int temp = positions[k];
            positions[k] = positions[n];
            positions[n] = temp;
        }
        
        foreach (Vector2Int position in positions)
        {
            Maxtrix_Bricks[position.x, position.y] = Instantiate(tmp_brick, new Vector3(-4.5f + position.y, 4.5f - position.x, 0), Quaternion.identity);
            Maxtrix_Bricks[position.x, position.y].transform.localScale = new Vector3(1f, 0.5f, 0.5f);
            Maxtrix_Bricks[position.x, position.y].transform.position += new Vector3(3f * position.y, 3f * position.x, 3f);
            Maxtrix_Bricks[position.x, position.y].transform.parent = this.transform;
            Maxtrix_Bricks[position.x, position.y].name = "Brick" + position.x + position.y;
            objColor = Maxtrix_Bricks[position.x, position.y].GetComponent<ObjectColor>();
            if (red_brick < 30)
            {
                colorType = ColorType.Red;
                objColor.ChangeColor(colorType);
                red_brick++;
            }
            else if (blue_brick < 30)
            {
                colorType = ColorType.Blue;
                objColor.ChangeColor(colorType);
                blue_brick++;
            }
            else if (green_brick < 30)
            {
                colorType = ColorType.Green;
                objColor.ChangeColor(colorType);
                green_brick++;
            }
            else
            {
                colorType = ColorType.None;
            }
        }
        transform.position = new Vector3(13f, 21.5f, -19f);
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

 
}
