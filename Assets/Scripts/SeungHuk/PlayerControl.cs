using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using static Player.PlayerControl;
using static UIManager;

namespace Player
{
    #region Health Class
    public class Health
    {
        public float health;
        public GameObject healthUIPrefab;
        public HealthUI healthUI;
        public PlayerControl player;
        
        public Health()
        {
            health = 3f;
            healthUIPrefab = GameObject.Find("HealthUI");
            healthUI = healthUIPrefab.GetComponent<HealthUI>();
            healthUI.currentHealth = health;
            player = GameObject.Find("Guy").GetComponent<PlayerControl>();
            Debug.Log("나 셋팅 됨");
        }

        public void Heal(float heal)
        {
            if (health < 3f)
            {
                health += heal;
                healthUI.currentHealth = health;
                Debug.Log("체력 증가!");
            }
            else
            {
                Debug.Log("이미 풀피야!");
            }
        }
        public void TakeDamage(float damage)
        {
            health -= damage;
            healthUI.currentHealth = health;
            Debug.Log("체력 감소!");
            if (health <= 0)
            {
                player.isDead = true;
                Debug.Log("게임 오버!");
            }
        }
    }
    public class PlayerControl : PlayerAnimator
    {

        #endregion
        #region 변수 및 초기화 함수 

        public bool isGround;                   //땅에 있는지?
        public bool isSprint;                   //달리는 중인지?
        public float speed;                     //기본 이동 속도
        public float jumpPower;                 //플레이어 점프 힘
        private Rigidbody playerRigidBody;      //플레이어 RigidBody 연동
        public Vector3 input;                   //키보드 입력 WASD
        //private Quaternion curRotation;         //현재 몸의 각도
        //float turnSpeed;                        //고개 돌리는 속도
        //private Quaternion endturn;             //플레이어가 고개를 어디까지 돌아야하는지 (왼쪽 270도, 오른족 90도 등)
        public float sprint;                    //달리기시 추가 속도
        public float groundCheckSensitivity;    //땅 감지 민감도
        public float groundCheckCount;          //땅을 제대로 밟고 있는지 (무작정 연타시 공중에서 1단점프추가로 가능하여 공중 점프 막기 용)
        public bool doubleJump;                 //더블점프 능력 보유 여부
        public bool isDoubleJump;               //더블점프했는지 여부
        public Health hp;                      //체력
        public int invincibilityTime;           //무적 시간
        public Quaternion rightRotation;           //오른쪽 보는 방향
        public Quaternion leftRotation;            //왼쪽 보는 방향
        public int slot;
        public int curslot;
        public GunController gun;
        public HandedStoneController handStone;
        public bool isPlayerSeeLeft;
        public int haveStoneCount;
        public ThrowStoneController throwStone;
        public float stoneThrowPower;
        public bool isRolling;
        float rollingTimer;
        protected virtual void InitilizeController() //초기 값 로드
        {
            rollingTimer = 0f;
            isRolling = false;
            stoneThrowPower = 10f;
            haveStoneCount = 10;
            slot = 1;
            curslot = 1;
            //health = 3;
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
            jumpPower = 25f;
            playerRigidBody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            animator.applyRootMotion = false; // 애니메이션이 캐릭터의 위치와 회전을 변경하지 않도록 설정
            rightRotation = Quaternion.Euler(0, 90, 0);
            leftRotation = Quaternion.Euler(0, 270, 0);
            SlotReset();
            hp = new Health();
        }

        #endregion 

        private void Awake()
        {
            InitilizeController();
        }

        private void Start()
        {
        }

        public void UpdateControll()
        {
            CheckGround();
            UpdateAnimator();
            //HealthControl();
            RotationPlayer();
            if (isRolling == true)
                DoRolling();
            else
                Move();
            if (gun.gameObject.activeSelf)
                gun.GunCheck();
        }

        public void SlotCheck(ItemList inItem)
        {
            SlotReset();
            switch (inItem)
            {
                case ItemList.None:
                    Debug.Log("1번 슬롯!");
                    break;
                case ItemList.Stone:
                    Debug.Log("3번 슬롯!");
                    StoneSet();
                    break;
                case ItemList.Gun:
                    Debug.Log("2번 슬롯! 총 장착!");
                    TakeGun();
                    break;
            }
        }
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
                //Debug.Log("그냥점프");
                isGround = false;
                isGrounded = false;
    }
            else
            {
                this.playerRigidBody.velocity = new Vector3(this.playerRigidBody.velocity.x, 0, this.playerRigidBody.velocity.z);
                //Debug.Log("더블점프");
                isDoubleJump = false;
                isGrounded = false;
            }
            groundCheckCount+=2;
            playerRigidBody.AddForce(Vector3.up * jumpPower + (input * Time.fixedDeltaTime * (speed + sprint)), ForceMode.Impulse);
        }
        public void AddGravity()
        {
            playerRigidBody.AddForce(Vector3.down * 4f, ForceMode.Force);
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
                    //Debug.Log("더블점프 충전");
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
            //Throwcontroller에 파워 전달
            throwStone.Throw(stoneThrowPower, isPlayerSeeLeft);
            if (haveStoneCount == 0)
                handStone.ResetStone(false);
        }

        public void DoRolling()
        {
            //Debug.Log("구르기");
            rollingTimer += Time.deltaTime;
            playerRigidBody.MovePosition(playerRigidBody.position + input * Time.deltaTime * 30f);
            if (rollingTimer > 0.3f || !isGround)
            {
                isRollinga = false;
                isRolling = false;
                rollingTimer = 0f;
            }
        }
    }
}
