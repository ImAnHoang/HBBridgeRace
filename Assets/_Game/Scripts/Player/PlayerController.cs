using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerController : GameManage
{
    [SerializeField] List<GameObject> _brickList;
    [SerializeField] Material material;

    Rigidbody rb;
    public bool canTakeBrick { get { return _brickLine != _brickList.Count - 1; } }
    public bool canTakeOff { get { return _brickLine > 0; } }
    public int brickLine
    {
        get
        {
            if (_brickLine < _brickList.Count)
            {
                return _brickLine;
            }
            else
            {
                return _brickLine = 0;
            }
        }
        set
        {
            if (0 > _brickLine)
            {
                _brickLine = value;
            }
            else
            {
                _brickLine = 0;
            }
           
        }

    }


    [SerializeField] private int _brickLine = 0;
    [SerializeField] private ColorType colorType;

    private Vector3 temp_ray = new Vector3(0f, 0f, 1f);
    private float brickPosition;

    public ColorType ColorType => colorType;

    public ColorData ColorData;

    public int BridgeCount { get; set; }

    public int FloorCount { get; set; }
    void Start()
    {
        OnInit();
    }

    private void Update()
    {
        Check_Move_Bridge();
    }
    private void OnTriggerEnter(Collider other)
    {
        ObjectColor color = other.gameObject.GetComponent<ObjectColor>();
        if (color != null && color.ColorType == colorType && color.tag != "Stair" && canTakeBrick)
        {
            CollectBrick(this._brickList, other.gameObject, this.brickLine);
            _brickLine++;

        }
        if (other.tag == "Stair")
        {
            if (canTakeOff && other.GetComponent<MeshRenderer>().enabled == false)
            {
                this._brickLine--;
                BridgeCount++;
                other.transform.GetComponent<MeshRenderer>().enabled = true;
                TakeOffBrick(_brickList, brickLine, other.gameObject);
            }
        }

    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "AIRed")
        {
            if (this.brickLine > other.transform.GetComponent<PlayerController>().brickLine)
            {
                other.transform.GetComponent<PlayerController>().brickLine = 0;
                for(int i=0; i< other.transform.GetChild(2).childCount; i++)
                {
                    other.transform.GetChild(2).GetChild(i).transform.gameObject.SetActive(false);
                    
                }
            
            }
            else
            {
                this.transform.GetComponent<PlayerController>().brickLine = 0;
                for (int i = 0; i < this.transform.GetChild(2).childCount; i++)
                {
                    this.transform.GetChild(2).GetChild(i).transform.gameObject.SetActive(false);
                }

            }
        }
        

    }

    private void OnInit()
    {
        rb = GetComponent<Rigidbody>();
        FloorCount = 1;
        OnLoad();
        LoadPosition();
    }

    private void LoadPosition()
    {
        brickPosition = 0f;
        for (int i = 0; i < _brickList.Count; i++)
        {
            _brickList[i].transform.localPosition = new Vector3(0f, brickPosition, 0f);
            brickPosition += 0.25f;
        }
    }

    private void OnLoad()
    {
        if (this.tag == "Player")
        {
            this._brickList = GetBrickList(_brickList, "PlayerBrick", ColorType.Blue);
        }
        if (this.tag == "AIRed")
        {
            this._brickList = GetBrickList(_brickList, "AIRedBrick", ColorType.Red);
        }
        if (this.tag == "AIGreen")
        {
            this._brickList = GetBrickList(_brickList, "AIGreenBrick", ColorType.Green);
        }
    }

    private void Check_Move_Bridge()
    {
        Debug.DrawLine(transform.position + (Vector3)Vector2.up * 1 + temp_ray, transform.position + (Vector3)Vector2.up * 1 + transform.forward * 10f, Color.red);
        if (Physics.Raycast(transform.position + (Vector3)Vector2.up * 1 + temp_ray, transform.forward + (Vector3)Vector2.up * 1, out var hit, 5f))
        {
            if (hit.collider.CompareTag("Stair"))
            {
                if (_brickLine == 0 && hit.collider.GetComponent<MeshRenderer>().enabled == false)
                {
                    hit.collider.GetComponent<BoxCollider>().isTrigger = false;
                }
                else if (_brickLine == 0 && hit.collider.GetComponent<MeshRenderer>().enabled == true)
                {
                    hit.collider.GetComponent<BoxCollider>().isTrigger = true;
                }
                else if (_brickLine > 0 && hit.collider.GetComponent<MeshRenderer>().enabled == false)
                {
                    hit.collider.GetComponent<BoxCollider>().isTrigger = true;
                }
                else if (_brickLine > 0 && hit.collider.GetComponent<MeshRenderer>().enabled == true)
                {
                    hit.collider.GetComponent<BoxCollider>().isTrigger = true;
                }
                else
                {
                    hit.collider.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
        }
    }

}

