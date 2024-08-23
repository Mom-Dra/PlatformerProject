using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterMoveControl : MonoBehaviour
{
    Rigidbody rb;
    private float moveSpeed = 0.1f;
    private Vector3 move_to_ray;
    private Vector3 player_Position;
    public GameObject player;
    public int location = 1;
    //private Animator anim;
    public int status = 0;
    public int health = 3;
    //public bool is_player_in = false;

    void Start()
    {
        //anim = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if ((health >=0))
        {
            switch (status)
            {
                case 0:
                    Walk_Status();
                    break;
                case 1:
                    Watching_Status();
                    break;
                case 2:
                    Following_Status();
                    break;

            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    void Walk_Status() //�ȴ� ����
    {
        //anim.SetInteger("AnimationPar", 1);
        if (!IsMonsterSeePlayer())
            MonsterSearchingPlayer();
        else
            status = 1;
    }
    void Watching_Status() // �÷��̾ �����Ͽ� �ֽ��ϴ� ����
    {
        //anim.SetInteger("AnimationPar", 0);
        Looking_Location();
        if (!IsMonsterSeePlayer())
        {
            status = 0;
        }
        else if (CheckDistance() <= 10 && IsPlayerStandFront() && Mathf.Abs(player_Position.y - transform.position.y) <= 1f)
        {
            status = 2;
        }
    }
    void Following_Status() //�÷��̾� �߰� ����
    {
        Get_Player_Position();
        //anim.SetInteger("AnimationPar", 1);

        Looking_Location();

        if ((location == 1 && player_Position.x - transform.position.x < 0) || (location == -1 && player_Position.x - transform.position.x > 0))
        {
            location = location * -1;
        }
        if (!Physics.Raycast(move_to_ray, Vector3.down, 0.1f))
        {
            location = location * -1;
            rb.MovePosition(transform.position + Vector3.left * moveSpeed * location);
        }
        else
        {
            rb.MovePosition(transform.position + Vector3.left * moveSpeed *location);
        }

        if (!(CheckDistance() <= 10))
        {
            status = 1;
        }
    }
    /*void Following_To_Player() //���Ͱ� �¿�� �̵��ϴ� �Լ� -> ���̸� �Ʒ��� 2��ŭ ���� ������� ����
    {
        move_to_ray = transform.position;
        move_to_ray.x = move_to_ray.x - (moveSpeed * 3);
        if (!Physics.Raycast(transform.position, Vector3.down, 2))
        {
            transform.Rotate(Vector3.up * 180);
            //transform.Translate(Vector3.forward * moveSpeed);
            location = location * -1;
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed);
        }
    }*/

    void Get_Player_Position() //�÷��̾��� ��ġ�� Ȯ���ϴ� �Լ�
    {
        player_Position = player.transform.position;
    }
    
    float CheckDistance() // �÷��̾���� �Ÿ��� �����ϴ� �Լ�
    {
        float x = transform.position.x - player_Position.x;
        float y = transform.position .y - player_Position.y;
        float dis = Mathf.Sqrt((x*x) + (y*y));
        return dis;
    }
    bool IsMonsterSeePlayer() //�� �þ߰� �� �÷��̾ ������ True ������ False�� �����ϴ� �Լ�
    {
        Get_Player_Position();
        if (CheckDistance() <= 10 && IsPlayerStandFront())
        {
            return true;
        }
        return false;
    }

    void MonsterSearchingPlayer() //���Ͱ� �¿�� �̵��ϴ� �Լ� -> ���̸� �Ʒ��� 0.1f��ŭ ���� ������� ����
    {
        Looking_Location();
        if (!Physics.Raycast(move_to_ray, Vector3.down, 1f))
        {
            rb.MovePosition(transform.position + Vector3.left * moveSpeed * location);
            location = location * -1;
        }
        else
        {
            rb.MovePosition(transform.position + Vector3.left * moveSpeed * location);
        }
    }
    void Looking_Location()
    {
        move_to_ray = transform.position;
        if (location == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
            move_to_ray.x = move_to_ray.x - (moveSpeed * 10);
        }
        else if (location == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            move_to_ray.x = move_to_ray.x + (moveSpeed * 10);
        }
    }

    bool IsPlayerStandFront() // �÷��̾��� x�� ���� ���� ���Ͱ� ���� ������ ��Ÿ���� Location ������ �÷��̾ ���� �������� �ľ�
    {
        if ((player.transform.position.x - transform.position.x < 0 && location == 1)
            || (player.transform.position.x - transform.position.x >= 0 && location == -1))
            return true;
        return false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            player.gameObject.GetComponent<PlayerControl>().hp.TakeDamage(0.5f);
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            Debug.Log("�Ѹ���");
        }
    }
}
