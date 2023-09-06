using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public class Player : MonoBehaviour
{
    

    private Vector2 moveInput;

    private Vector2 worldPos;

    private Vector2 mouseAim;
    private Vector2 currentMouseAim;


    [Header("# Player Info")]
    [SerializeField] private float speed;
   
    private Camera _camera;
    private SpriteRenderer mySprite;
    private Rigidbody2D myRigid;
    private Animator myAnim;
    // ����� ������ ����

    private void Awake()
    {
        // �ʱ�ȭ
        _camera = Camera.main;
        myRigid = GetComponent<Rigidbody2D>(); 
        mySprite = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        // ��ǲ�ý��ۿ��� ���� �����ͼ� inputvec ������ �Ҵ�

    }
    public void OnLook(InputValue value)
    {        
        mouseAim = value.Get<Vector2>();        
    }
    public void OnJump(InputValue value)
    {        
        myAnim.SetTrigger("Jump");
    }


    private void Update()
    {
        worldPos = _camera.ScreenToWorldPoint(mouseAim);
        currentMouseAim = (worldPos - (Vector2)transform.position);

        if (currentMouseAim.x < 0)
        {
            mySprite.flipX = true;
        }
        else
        {
            mySprite.flipX = false;
        }
        // ���콺 �ٶ󺸱�
    }
    
    private void FixedUpdate()
    {
        Vector2 nextVec = moveInput * speed * Time.deltaTime;
        myRigid.MovePosition(myRigid.position + nextVec);
        // �̵��ϱ�  
    }

    private void LateUpdate()
    {
        myAnim.SetFloat("Speed",moveInput.magnitude);
        
    }
}
