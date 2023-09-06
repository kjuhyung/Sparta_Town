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
    private Rigidbody2D myRigid; // Rigidbody 변수 선언

    private void Awake()
    {
        // 초기화, 자신의 컴포넌트 가져오기
        _camera = Camera.main;
        myRigid = GetComponent<Rigidbody2D>(); 
        mySprite = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue value)
    {
        inputvec = value.Get<Vector2>();
        // 인풋시스템에서 값을 가져와서 inputvec 변수에 할당

    }
    void OnLook(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputvec * speed * Time.deltaTime;
        myRigid.MovePosition(myRigid.position + nextVec);
        // 이동하기

        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePosition);
        mousePosition = (worldPos - (Vector2)transform.position).normalized;
        if (mousePosition.x < 0) mySprite.flipX = true;

        // 마우스위치 바라보기
    }
}
