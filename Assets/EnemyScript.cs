using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum STATE
    {
        LOOKFOR, GOTO, ATTACK, DEAD
    }
   public STATE currentState = STATE.LOOKFOR;
    public float enemySpeed;
    public float attackDistance;
    public float goToDistance;
    public Transform target;
    public string playerTag;
    public float attackTimer;
    public float currentTime;
    PlayerScript playerScript;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator NameFunction()
    {
        currentTime = attackTimer;
        if(target !=null)
        {
            playerScript = target.GetComponent<PlayerScript>();
        }
        while (true)
        {
            switch (currentState)
            {
                case STATE.LOOKFOR:
                    LookFor();
                    break;
                case STATE.GOTO:
                    Goto();
                    break;
                case STATE.ATTACK:
                    Attack();
                    break;
                case STATE.DEAD:
                    Dead();
                    break;
                default:
                    break;
            }
            yield return 0;

        }

        

    }
    public void LookFor()
    {
        
        if(Vector3.Distance (target.transform.position, this.transform.position) < goToDistance)
        {
            currentState = STATE.GOTO;
        }
        Debug.Log("Lookfor state");
    }
    public void Goto()
    {
         
        if(Vector3.Distance(target.transform.position, this.transform.position) > attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
            
        }
        else
        {
            currentState = STATE.ATTACK;
        }
        Debug.Log("Goto state");
    }
    public void Attack()
    {
        currentTime = currentTime - Time.deltaTime;
        if(currentTime <=0f)
        {
            playerScript.health--;
            Debug.Log(playerScript.health);
            currentTime = attackTimer;
            
        }
        if(playerScript.health < 0)
        {
            currentState = STATE.DEAD;
        }
        if(Vector3.Distance(target.transform.position, this.transform.position)>attackDistance)
        {
            currentState = STATE.GOTO;
        }
         Debug.Log("Attack state");
    

    }
    public void Dead()
    {
        Debug.Log("Game Over!");
    }
}
