using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //1 

public class AgentScript : MonoBehaviour
{
    public Animator animator; //2 
    public Transform goal; //3 
    NavMeshAgent agent;  //4 
    public GameController gc;
    // Start is called before the first frame update 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //5 
    }
    // Update is called once per frame 
    void Update()
    {
        agent.destination = goal.position; //6 
        animator.SetFloat("Speed_f", agent.velocity.magnitude); //7 
    }
    private void OnTriggerEnter(Collider other){
        if  (other.tag == "bullet"){
            animator.SetInteger("DeathType_int",1);
        }
    }
}