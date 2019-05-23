using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int currentEquipCount;
    public string currentEquip;
    private readonly string[] equipList = new string[9]{"barehand", "hammer", "schyte", "watercan", "tomatoseed", "potatoseed", "carrotseed",/* "broccoliseed", "strawberryseed",*/ "cucumberseed", "cornseed" };
    public int[] seed;
    public int watercount;
    public int[] harvest;
    public int money;
    [SerializeField]
    private Image equipImage;
    [SerializeField]
    private Sprite[] equipSprite;
    [SerializeField]
    private Text equipText;

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
            if (currentEquip == "tomatoseed" && seed[0] > 0)
            {
                SoundManagerScript.PlaySound("tanam");
                seed[0] -= 1;
            }
            else if (currentEquip == "potatoseed" && seed[1] > 0)
            {
                SoundManagerScript.PlaySound("tanam");
                seed[1] -= 1;
            }
            else if (currentEquip == "carrotseed" && seed[2] > 0)
            {
                SoundManagerScript.PlaySound("tanam");
                seed[2] -= 1;
            }/*
            else if (currentEquip == "broccoliseed" && seed[3] > 0)
            {
                SoundManagerScript.PlaySound("tanam");
                seed[3] -= 1;
            }
            else if (currentEquip == "strawberryseed" && seed[4] > 0)
            {
                SoundManagerScript.PlaySound("tanam");
                seed[4] -= 1;
            }*/
            else if (currentEquip == "cucumberseed" && seed[5] > 0)
            {
                SoundManagerScript.PlaySound("tanam");
                seed[5] -= 1;
            }
            else if (currentEquip == "cornseed" && seed[6] > 0)
            {
                SoundManagerScript.PlaySound("tanam");
                seed[6] -= 1;
            }
            else if (currentEquip == "watercan" && watercount > 0) watercount -= 1;
        }
        else if(Input.GetButtonDown("change equip"))
        {
            currentEquipCount++;
            currentEquipCount %= equipList.Length;
            currentEquip = equipList[currentEquipCount];
            equipText.text = currentEquip;
            equipImage.sprite = equipSprite[currentEquipCount];
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
        if((change.x * change.y) == 0)
        {
            myRigidBody.MovePosition(
                transform.position + change * speed * Time.deltaTime
            );
        }
        else
        {
            myRigidBody.MovePosition(
                transform.position + change * speed * 0.707f * Time.deltaTime
            );
        }
    }
}
