using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotAI : MonoBehaviour
{
    
    [SerializeField] int targetColor;


    PlayerController playerController;
    Animator animator;

    float distanceToClosestTarget;
    float distanceToTarget;

    private GameObject target;
    private GameObject[] _allTargets;

    private GameObject[] _allbricks;
    private NavMeshAgent NavMeshAgent;

    [SerializeField] private ColorType colorType;

    [SerializeField] public GameObject BridgeTarget;

    private string currentAnim = "idle";

    [SerializeField] private GameObject WinPos;

    bool canMove = false;

    int count_stair = 0;

    private float SpeedBot; 
    
    [SerializeField] private GameObject[] _allTargetsBridge;
    [SerializeField] private float distanceToClosestBridge;
    [SerializeField] private float distanceToBridge;

    private void Start()
    {
        OnInit();
        Invoke(nameof(FindClosestEnemy), 1f);

    }

    private void Update()
    {
        if (playerController.brickLine == 0)
        {
            FindClosestEnemy();
        }
        if (playerController.brickLine >= 5)
        {
            target = BridgeTarget;
        }
        if (playerController.BridgeCount >= 20 && playerController.brickLine >= 5)
        {
            target = WinPos;
        }
        if (canMove)
        {
            ChangeAnimation("run");
            if (target != null)
            {
                NavMeshAgent.SetDestination(target.transform.position);
            }
            else
            {
                FindClosestEnemy();
            }
        }
        else
        {
            ChangeAnimation("idle");
        }
    }


    private void OnInit()
    {
        SpeedBot = (float)5.5;
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
        colorType = (ColorType)targetColor;
        NavMeshAgent.speed = SpeedBot;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObjectColor>().GetColorType() == this.colorType)
        {
            canMove = false;
            other.gameObject.tag = "Untagged";
            FindClosestEnemy();
        }

    }

    void FindClosestEnemy()
    {
        distanceToClosestTarget = Mathf.Infinity;

        _allTargets = GameObject.FindGameObjectsWithTag("Brick");

        for (int i = 0; i < this._allTargets.Length; i++)
        {
            if (_allTargets[i].GetComponent<ObjectColor>().GetColorType() == colorType)
            {
                distanceToTarget = (this._allTargets[i].transform.position - this.transform.position).sqrMagnitude;
                if (distanceToTarget < distanceToClosestTarget)
                {
                    distanceToClosestTarget = distanceToTarget;
                    target = this._allTargets[i];
                }
            }
        }
        canMove = true;
    }

    //private GameObject FindClosestBridge()
    //{
    //    distanceToClosestBridge = Mathf.Infinity;
    //    _allTargetsBridge = GameObject.FindGameObjectsWithTag("Bridge");
    //    for (int i = 0; i < this._allTargetsBridge.Length; i++)
    //    {
    //        distanceToBridge = (this._allTargetsBridge[i].transform.position - this.transform.position).sqrMagnitude;
    //        if (distanceToBridge < distanceToClosestBridge)
    //        {
    //            distanceToClosestBridge = distanceToBridge;
    //            target = this._allTargetsBridge[i];
    //        }
    //    }
    //    canMove = true;
    //    return target;
    //}


    public void ChangeAnimation(string newAnim)
    {
        if (currentAnim != newAnim)
        {
            animator.ResetTrigger(newAnim);
            currentAnim = newAnim;
            animator.SetTrigger(currentAnim);
        }
    }
}
