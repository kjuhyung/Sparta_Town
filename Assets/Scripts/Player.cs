using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    

    private Vector2 inputvec;

    private Vector2 mousePosition;

    [SerializeField] private float speed;

    private Camera _camera;
    private SpriteRenderer mySprite;
    private Rigidbody2D myRigid; // Rigidbody ���� ����

    private void Awake()
    {
        // �ʱ�ȭ, �ڽ��� ������Ʈ ��������
        _camera = Camera.main;
        myRigid = GetComponent<Rigidbody2D>(); 
        mySprite = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue value)
    {
        inputvec = value.Get<Vector2>();
        // ��ǲ�ý��ۿ��� ���� �����ͼ� inputvec ������ �Ҵ�

    }
    void OnLook(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputvec * speed * Time.deltaTime;
        myRigid.MovePosition(myRigid.position + nextVec);
        // �̵��ϱ�

        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePosition);
        mousePosition = (worldPos - (Vector2)transform.position).normalized;
        if (mousePosition.x < 0) mySprite.flipX = true;

        // ���콺��ġ �ٶ󺸱�
    }
}
