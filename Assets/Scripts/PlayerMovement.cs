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
    public static PlayerMovement main;
    private PlayerState currentState;
    [SerializeField]
    private float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    private int currentEquipCount; // barehand, hoe, schyte, watering can
    public string currentEquip;
    private readonly string[] equipList = new string[11]{"barehand", "hoe", "schyte", "watercan", "tomatoseed", "potatoseed", "carrotseed", "broccoliseed", "strawberryseed", "cucumberseed", "cornseed" };
    public int[] seed;
    public int watercount;


    // Start is called before the first frame update

    void Awake()
    {
        main = this;
    }

    void Start()
    {
        currentState = PlayerState.walk;
        currentEquip = equipList[0];
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Debug.Log(seed[0]+seed[1]+seed[2]+seed[3]);
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
            if (currentEquip == "tomatoseed" && seed[0] > 0) seed[0] -= 1;
            else if (currentEquip == "potatoseed" && seed[1] > 0) seed[1] -= 1;
            else if (currentEquip == "carrotseed" && seed[2] > 0) seed[2] -= 1;
            else if (currentEquip == "broccoliseed" && seed[3] > 0) seed[3] -= 1;
            else if (currentEquip == "strawberryseed" && seed[4] > 0) seed[4] -= 1;
            else if (currentEquip == "cucumberseed" && seed[5] > 0) seed[5] -= 1;
            else if (currentEquip == "cornseed" && seed[6] > 0) seed[6] -= 1;
            else if (currentEquip == "watercan" && watercount > 0) watercount -= 1;
        }
        else if(Input.GetButtonDown("change equip"))
        {
            currentEquipCount++;
            currentEquipCount %= equipList.Length;
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
        yield return new WaitForSeconds(.25f);
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
