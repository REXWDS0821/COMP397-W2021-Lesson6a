using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum WhiteclownState
{
    IDLE,
    RUN,
    JUMP
}

public class WhiteclownBehaviour : MonoBehaviour
{
    [Header("Line of Sight")]
    public bool HasLOS;
    public GameObject player;
    private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasLOS)
        {
            agent.SetDestination(player.transform.position);
        }
            
        if(HasLOS && Vector3.Distance(transform.position, player.transform.position) < 2.5)

            {
                //could be an attack
                animator.SetInteger("AnimState", (int)WhiteclownState.IDLE);
                transform.LookAt(transform.position - player.transform.forward);

            if (agent.isOnOffMeshLink)
            {
                animator.SetInteger("AnimState", (int)WhiteclownState.JUMP);
            }
            }
            else
            {
                animator.SetInteger("AnimState", (int)WhiteclownState.RUN);
            }
        


        

        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    animator.SetInteger("AnimState", (int)WhiteclownState.IDLE);
        //}
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    animator.SetInteger("AnimState", (int)WhiteclownState.RUN);
        //}
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    animator.SetInteger("AnimState", (int)WhiteclownState.JUMP);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HasLOS = true;
            player = other.transform.gameObject;
        }
    }

}
