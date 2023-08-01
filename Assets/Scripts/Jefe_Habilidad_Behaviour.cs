using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe_Habilidad_Behaviour : StateMachineBehaviour
{
    [SerializeField] private GameObject habiliad;
    [SerializeField] private float offsetY;
    private FinalBoss jefe;
    private Transform jugador;




    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe =  animator.GetComponent<FinalBoss>();
        jugador = jefe.jugador;

        jefe.MirarJugador();

        Vector2 posicionAparicion = new Vector2(jugador.position.x, jugador.position.y + offsetY);

        Instantiate(habiliad, posicionAparicion, Quaternion.identity);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
