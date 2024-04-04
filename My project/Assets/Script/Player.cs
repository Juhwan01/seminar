using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private bool isTouchLeft;
    private bool isTouchRight;
    private SpriteRenderer spriteRenderer;
    private bool isLeft;
    private bool isRight;
    public GameObject overSet;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        //// 왼쪽 화살표가 눌렸을 때
        //if (Input.GetKey(KeyCode.LeftArrow)&&!isTouchLeft)
        //{
        //    transform.Translate(-speed, 0, 0); // 왼쪽으로 speed만큼 움직인다
        //    spriteRenderer.flipX = true;
        //}

        //// 오른쪽 화살표가 눌렸을 때
        //if (Input.GetKey(KeyCode.RightArrow)&&!isTouchRight)
        //{
        //    transform.Translate(speed, 0, 0); // 오른쪽으로 speed만큼 움직인다
        //    spriteRenderer.flipX = false;
        //}


        // 위에 주석 처리된 코드들은 키보드로 움직이는 코드
        // 이 아래의 코드는 ui버튼 클릭으로 움직이는 코드
        // 왼쪽 화살표가 눌렸을 때
        if (isLeft && !isTouchLeft)
        {
            transform.Translate(-speed, 0, 0); // 왼쪽으로 speed만큼 움직인다
            spriteRenderer.flipX = true;
        }

        // 오른쪽 화살표가 눌렸을 때
        if (isRight && !isTouchRight)
        {
            transform.Translate(speed, 0, 0); // 오른쪽으로 speed만큼 움직인다
            spriteRenderer.flipX = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;

            }
        }
    }
    //Retry버튼 누르면 씬 로드 다시해서 재시작
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;

            }
        }
    }

    public void movdLeft()
    {
        isLeft= !isLeft;
    }
    public void moveRight()
    {
        isRight = !isRight;
    }
    //Retry버튼 누르면 씬 로드 다시해서 재시작
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
        overSet.SetActive(false);
        gameObject.SetActive(true);
    }
}

