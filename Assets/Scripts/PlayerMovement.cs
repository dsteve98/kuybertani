using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    public int currentEquipCount; // barehand, hoe, schyte, watering can
    public string currentEquip;
    string[] equipList = new string[4]{"barehand", "hoe", "schyte", "watercan"};
    


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); //use GetAxis() untuk adanya acceleration
        change.y = Input.GetAxisRaw("Vertical");
        
        if(Input.GetButtonDown("interact") && currentState != PlayerState.interact)
        {
            StartCoroutine(InteractCo());
        }
        else if (Input.GetButtonDown("change equip"))
        {
            currentEquipCount++;
            currentEquipCount %= 4;
            currentEquip = equipList[currentEquipCount];
            Debug.Log(currentEquip);
        }
        else if(currentState == PlayerState.walk)
            {
                UpdateAnimationAndMove();
            }
    }

    private IEnumerator InteractCo()
    {
        animator.SetBool("interacting", true);
        currentState = PlayerState.interact;
        yield return null;
        animator.SetBool("interacting", false);
        yield return new WaitForSeconds(.2f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}
