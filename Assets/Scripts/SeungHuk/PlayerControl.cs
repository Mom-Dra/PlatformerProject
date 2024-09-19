using UnityEngine;
using UnityEngine.SocialPlatforms;
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
        public float invincibilityDuration; // 무적 지속 시간
        public bool isInvincible; // 무적 상태 플래그
        public float invincibilityTimer; // 무적 타이머

        public Health()
        {
            health = 3f;
            healthUIPrefab = GameObject.Find("HealthUI");
            healthUI = healthUIPrefab.GetComponent<HealthUI>();
            healthUI.currentHealth = health;
            player = GameObject.Find("Guy").GetComponent<PlayerControl>();
            isInvincible = false;
            invincibilityDuration = 1.0f;
            Debug.Log("Health Setting Ok");
        }

        public void Heal(float heal)
        {
            if (health < 3f)
            {
                health += heal;
                healthUI.currentHealth = health;
                Debug.Log("Already Healty!");
            }
            else
            {
                Debug.Log("Healing!");
            }
        }
        public void TakeDamage(float damage)
        {
            if (isInvincible)
                return;
            Physics.IgnoreLayerCollision(6, 7, true); // 6 : Player, 7 : Trap -> Layer
            // 무적 상태 설정
            isInvincible = true;
            invincibilityTimer = invincibilityDuration;
            Debug.Log("Player is now invincible!");

            health -= damage;
            healthUI.currentHealth = health;
            Debug.Log("Player Took Damage!");

            if (health <= 0)
            {
                player.isDead = true;
                Debug.Log("Good bye, World!");
            }
        }
    }
    #endregion
    public class PlayerControl : PlayerAnimator
    {

        #region InitilizeSetting 

        public int moveMod;
        public float jumpKingPower;
        public bool isGround;                  
        public bool isSprint;                  
        public float speed;                   
        public float jumpPower;                
        public Rigidbody playerRigidBody;     
        public Vector3 input;                 
        //private Quaternion curRotation;       
        //float turnSpeed;                      
        //private Quaternion endturn;            
        public float sprint;                   
        public float groundCheckSensitivity; 
        public float groundCheckCount;        
        public bool doubleJump;         
        public bool isDoubleJump;            
        public Health hp; 
        public int invincibilityTime; 
        public Quaternion rightRotation;
        public Quaternion leftRotation;
        public int slot;
        public int curslot;
        public GunController gun;
        public HandedStoneController handStone;
        public bool isPlayerSeeLeft;
        public int haveStoneCount;
        public ThrowStoneController throwStone;
        public float stoneThrowPower;
        public bool isRolling;
        private RaycastHit hit;
        public float rollingTimer;
        public bool onPlatform;
        public float platformDis;
        public Platform platform;
        protected virtual void InitilizeController() 
        {
            jumpKingPower = 0f;
            moveMod = 0;
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
            animator.applyRootMotion = false;
            rightRotation = Quaternion.Euler(0, 90, 0);
            leftRotation = Quaternion.Euler(0, 270, 0);
            SlotReset();
            hp = new Health();
            Physics.gravity = new Vector3(0, -9.81f * 5f, 0);
        }

        #endregion 

        private void Start()
        {
            InitilizeController();
            Debug.Log("들어옴");
        }

        public void FixedUpdateControll()
        {
            
            Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f);
            CheckGround();
            UpdateAnimator();
            //HealthControl();
            RotationPlayer();
            if(isRolling)
            {
                DoRolling();
            }
            if (moveMod == 0)
                Move();
            else
                JumpKing();
            if (gun.gameObject.activeSelf)
                gun.GunCheck();
            InvincibleControl();
        }

        public void JumpKing()
        {
            if (isGround && jumpKingPower == 0)
                Move();

            if (jumpKingPower > 1000f)
                jumpKingPower = 1000f;
        }
        public void JumpKingJump()
        {
            if (isGround)
            {
                //Debug.Log("JumpKingJump!");
                isGround = false;
                isGrounded = false;
                playerRigidBody.AddForce(Vector3.up * jumpKingPower + (input * (speed + sprint)), ForceMode.Impulse);
            }
            jumpKingPower = 0;
        }

        public void SlotCheck(ItemList inItem)
        {
            SlotReset();
            switch (inItem)
            {
                case ItemList.None:
                    Debug.Log("No.1 Slot Set!");
                    break;
                case ItemList.Stone:
                    Debug.Log("No.3 Slot Set!");
                    StoneSet();
                    break;
                case ItemList.Gun:
                    Debug.Log("No.2 Slot Set! You have a gun Now!");
                    TakeGun();
                    break;
            }
        }

        void RotationPlayer()
        {
            float mouseX = Input.mousePosition.x - 950;
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
            Debug.Log("PlayerController_Move");
            if (Vector3.zero == input) { isRunning = false; }
            else { isRunning = true; }

            Vector3 direction = input * Time.fixedDeltaTime * (speed + sprint);

            direction = Vector3.ProjectOnPlane(direction, hit.normal);
            if(onPlatform)
            {
                //platformDis = platform.transform.position.y + (transform.position.y - platform.transform.position.y)-0.08f;
                playerRigidBody.MovePosition(new Vector3(playerRigidBody.position.x + direction.x, platform.transform.position.y + 0.5f, playerRigidBody.position.z + direction.z));
            }
            else
            {
                playerRigidBody.MovePosition(playerRigidBody.position + direction);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Platform"))
            {
                platform = collision.transform.GetComponent<PlatformMoving>();
                if (platform == null)
                    platform = collision.transform.GetComponent<PlatformWeightInfluenced>();
                if(platform != null)
                    onPlatform = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.transform.CompareTag("Platform"))
            {
                onPlatform = false;
                platform = null;
            }
        }

        public void Jump()
        {
            if (isGround)
            {
                //Debug.Log("Normal Jump!");
                isGround = false;
                isGrounded = false;
            }
            else
            {
                this.playerRigidBody.velocity = new Vector3(this.playerRigidBody.velocity.x, 0, this.playerRigidBody.velocity.z);
                //Debug.Log("Double Jump");
                isDoubleJump = false;
                isGrounded = false;
            }
            groundCheckCount+=2;
            playerRigidBody.AddForce(Vector3.up * jumpPower + (input * Time.fixedDeltaTime * (speed + sprint)), ForceMode.Impulse);
        }
        //public void AddGravity()
        //{
            //playerRigidBody.AddForce(Vector3.down * 4f, ForceMode.Force);
        //}
        void CheckGround()
        {
            if (Mathf.Abs(this.playerRigidBody.velocity.y) <= groundCheckSensitivity && groundCheckCount == 0)
            {
                isGround = true;
                isGrounded = true;
                if (doubleJump)
                {
                    isDoubleJump = true;
                    //Debug.Log("You Can Use Double Jump Now");
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

        public void Rebound(float power, Vector3 otherPos)
        {
            double data = otherPos.x - transform.position.x;
            if (data < 0)
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
            throwStone.Throw(stoneThrowPower, isPlayerSeeLeft);
            if (haveStoneCount == 0)
                handStone.ResetStone(false);
        }

        public void DoRolling()
        {
            Debug.Log("Rolling!");
            rollingTimer += Time.deltaTime;
            Vector3 direction = input * Time.deltaTime * 20f;

            direction = Vector3.ProjectOnPlane(direction, hit.normal);

            playerRigidBody.MovePosition(playerRigidBody.position + direction);
            if (rollingTimer > 0.4f || !isGround)
            {
                isRollinga = false;
                isRolling = false;
                rollingTimer = 0f;
            }
        }

        private void InvincibleControl()
        {
            if(hp.isInvincible)
            {
                hp.invincibilityTimer -= Time.deltaTime;
                if (hp.invincibilityTimer <= 0)
                {
                    hp.isInvincible = false;
                    Physics.IgnoreLayerCollision(6, 7, false);
                    Debug.Log("Player is no longer invincible.");
                }
            }
        }
    }
}
