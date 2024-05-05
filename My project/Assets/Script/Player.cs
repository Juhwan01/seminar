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
        //// ���� ȭ��ǥ�� ������ ��
        //if (Input.GetKey(KeyCode.LeftArrow)&&!isTouchLeft)
        //{
        //    transform.Translate(-speed, 0, 0); // �������� speed��ŭ �����δ�
        //    spriteRenderer.flipX = true;
        //}

        //// ������ ȭ��ǥ�� ������ ��
        //if (Input.GetKey(KeyCode.RightArrow)&&!isTouchRight)
        //{
        //    transform.Translate(speed, 0, 0); // ���������� speed��ŭ �����δ�
        //    spriteRenderer.flipX = false;
        //}


        // ���� �ּ� ó���� �ڵ���� Ű����� �����̴� �ڵ�
        // �� �Ʒ��� �ڵ�� ui��ư Ŭ������ �����̴� �ڵ�
        // ���� ȭ��ǥ�� ������ ��
        if (isLeft && !isTouchLeft)
        {
            transform.Translate(-speed, 0, 0); // �������� speed��ŭ �����δ�
            spriteRenderer.flipX = true;
        }

        // ������ ȭ��ǥ�� ������ ��
        if (isRight && !isTouchRight)
        {
            transform.Translate(speed, 0, 0); // ���������� speed��ŭ �����δ�
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
    //Retry��ư ������ �� �ε� �ٽ��ؼ� �����
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
    //Retry��ư ������ �� �ε� �ٽ��ؼ� �����
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
        overSet.SetActive(false);
        gameObject.SetActive(true);
    }
}

