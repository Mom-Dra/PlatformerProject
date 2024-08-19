using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using static UIManager;

namespace Player
{
    public class PlayerControl : PlayerAnimator
    {
        #region ���� �� �ʱ�ȭ �Լ�  

        private GameObject healthUIPrefab;
        private HealthUI healthUI;

        public bool isGround;                   //���� �ִ���?
        public bool isSprint;                   //�޸��� ������?
        public float speed;                     //�⺻ �̵� �ӵ�
        public float jumpPower;                 //�÷��̾� ���� ��
        private Rigidbody playerRigidBody;      //�÷��̾� RigidBody ����
        public Vector3 input;                   //Ű���� �Է� WASD
        //private Quaternion curRotation;         //���� ���� ����
        //float turnSpeed;                        //�� ������ �ӵ�
        //private Quaternion endturn;             //�÷��̾ ���� ������ ���ƾ��ϴ��� (���� 270��, ������ 90�� ��)
        public float sprint;                    //�޸���� �߰� �ӵ�
        public float groundCheckSensitivity;    //�� ���� �ΰ���
        public float groundCheckCount;          //���� ����� ��� �ִ��� (������ ��Ÿ�� ���߿��� 1�������߰��� �����Ͽ� ���� ���� ���� ��)
        public bool doubleJump;                 //�������� �ɷ� ���� ����
        public bool isDoubleJump;               //���������ߴ��� ����
        public float health;                      //ü��
        public int invincibilityTime;           //���� �ð�
        public Quaternion rightRotation;           //������ ���� ����
        public Quaternion leftRotation;            //���� ���� ����
        public int slot;
        public int curslot;
        public GunController gun;
        public HandedStoneController handStone;
        public bool isPlayerSeeLeft;
        public int haveStoneCount;
        public ThrowStoneController throwStone;
        public float stoneThrowPower;
        protected virtual void InitilizeController() //�ʱ� �� �ε�
        {
            stoneThrowPower = 10f;
            haveStoneCount = 10;
            slot = 1;
            curslot = 1;
            health = 3;
            isGround = true;
            isSprint = true;
            input = new Vector3(0, 0, 0);
            groundCheckSensitivity = 0.01f;
            groundCheckCount = 0;
            doubleJump = true;
            isDoubleJump = false;
            //turnSpeed = 600.0f;
            speed = 7f;
            sprint = 0f;
            jumpPower = 15f;
            playerRigidBody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            animator.applyRootMotion = false; // �ִϸ��̼��� ĳ������ ��ġ�� ȸ���� �������� �ʵ��� ����
            rightRotation = Quaternion.Euler(0, 90, 0);
            leftRotation = Quaternion.Euler(0, 270, 0);
            SlotReset();
        }

        #endregion 

        private void Awake()
        {
            InitilizeController();
        }

        private void Start()
        {
            healthUIPrefab = GameObject.Find("HealthUI");
            healthUI = healthUIPrefab.GetComponent<HealthUI>();
        }

        public void UpdateControll()
        {
            CheckGround();
            Move();
            UpdateAnimator();
            HealthControl();
            RotationPlayer();
            //SlotCheck();
            if (gun.gameObject.activeSelf)
                gun.GunCheck();
        }

        public void SlotCheck_Test(ItemList inItem)
        {
            SlotReset();
            switch (inItem)
            {
                case ItemList.None:
                    Debug.Log("1�� ����!");
                    break;
                case ItemList.Stone:
                    Debug.Log("3�� ����!");
                    StoneSet();
                    break;
                case ItemList.Gun:
                    Debug.Log("2�� ����! �� ����!");
                    TakeGun();
                    break;
            }       
        }

        //void SlotCheck()
        //{
        //    if(slot != curslot)
        //    {
        //        SlotReset();
        //        curslot = slot;
        //        switch (slot)
        //        {
        //            case 1:
        //                Debug.Log("1�� ����!");
        //                break;
        //            case 2:
        //                Debug.Log("2�� ����! �� ����!");
        //                TakeGun(); break;
        //            case 3:
        //                Debug.Log("3�� ����!");
        //                StoneSet();
        //                break;
        //            default:
        //                break;

        //        }
        //    }
        //}
        void RotationPlayer()
        {
            //Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouseX = Input.mousePosition.x - 950;
            //Debug.Log(mouseX);
            if (transform.position.x - mouseX >= 0)
            {
                transform.rotation = leftRotation;
                isPlayerSeeLeft = true;
            }
            else
            {
                transform.rotation = rightRotation;
                isPlayerSeeLeft = false;
            }
        }
        private void Move()
        {
            //if (input.x > 0 ) endturn = Quaternion.Euler(0, 90, 0);
            //if (input.x < 0) endturn = Quaternion.Euler(0, 270, 0);
            //if (input.z > 0) endturn = Quaternion.Euler(0, 0, 0);
            //if (input.z < 0) endturn = Quaternion.Euler(0, 180, 0);

            if (Vector3.zero == input) { isRunning = false; }
            else { isRunning = true; }

            //curRotation = transform.rotation;
            //transform.rotation = Quaternion.RotateTowards(curRotation, endturn, turnSpeed * Time.deltaTime);
            playerRigidBody.MovePosition(playerRigidBody.position + input * Time.fixedDeltaTime * (speed+sprint));
        }

        public void Jump()
        {
            if (isGround)
            {
                //Debug.Log("�׳�����");
                isGround = false;
                isGrounded = false;
    }
            else
            {
                this.playerRigidBody.velocity = new Vector3(this.playerRigidBody.velocity.x, 0, this.playerRigidBody.velocity.z);
                //Debug.Log("��������");
                isDoubleJump = false;
                isGrounded = false;
            }
            groundCheckCount+=2;
            playerRigidBody.AddForce(Vector3.up * jumpPower + (input * Time.fixedDeltaTime * (speed + sprint)), ForceMode.Impulse);
        }
        public void AddGravity()
        {
            playerRigidBody.AddForce(Vector3.down * 5f, ForceMode.Force);
        }
        void CheckGround()
        {
            if (Mathf.Abs(this.playerRigidBody.velocity.y) <= groundCheckSensitivity && groundCheckCount == 0)
            {
                isGround = true;
                isGrounded = true;
                if (doubleJump)
                {
                    isDoubleJump = true;
                    //Debug.Log("�������� ����");
                }
            }
            else if (Mathf.Abs(this.playerRigidBody.velocity.y) >= groundCheckSensitivity)
            {

                isGround = false;
                isGrounded = false;
            }
            else if(Mathf.Abs(this.playerRigidBody.velocity.y) <= groundCheckSensitivity)
            {
                groundCheckCount--;
            }
        }

        void HealthControl()
        {
            if (health <= 0)
                Debug.Log("���� ����!");
        }
        public void TakeDamage(float damage)
        {
            health -= damage;
            healthUI.currentHealth = health;
            Debug.Log("ü�� ����!");
        }

        public void Heal(float heal)
        {
            health += heal;
            healthUI.currentHealth = health;
            Debug.Log("ü�� ����!");
        }
        public void SlotReset()
        {
            gun.Reset();
            IsEquipedGun = false;
            handStone.ResetStone(false);
        }
        public void TakeGun()
        {
            gun.Take();
            IsEquipedGun = true;
        }

        public void Rebound(float power)
        {
            if (isPlayerSeeLeft)
            {
                playerRigidBody.velocity = new Vector3(1, 2.5f-(gun.normalizedY*5), 0) * power;
            }
            else
            {
                playerRigidBody.velocity = new Vector3(-1, 2.5f-(gun.normalizedY*5), 0) * power;
            }
        }


        public void StoneSet()
        {
            if (haveStoneCount != 0)
                handStone.ResetStone(true);
        }
        public void ThrowStone()
        {
            haveStoneCount--;
            //Throwcontroller�� �Ŀ� ����
            throwStone.Throw(stoneThrowPower, isPlayerSeeLeft);
            if (haveStoneCount == 0)
                handStone.ResetStone(false);
        }
    }
}
