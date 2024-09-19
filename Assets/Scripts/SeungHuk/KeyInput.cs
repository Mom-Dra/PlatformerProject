using UnityEngine;

namespace Player
{
    public class KeyInput : MonoBehaviour
    {
        #region Setting      

        [Header("Controller Input")]
        public string horizontalInput = "Horizontal";
        public string verticallInput = "Vertical";
        public KeyCode jumpInput = KeyCode.Space;
        public KeyCode strafeInput = KeyCode.Tab;
        public KeyCode sprintInput = KeyCode.LeftShift;
        public KeyCode reloadGun = KeyCode.R;
        public KeyCode rolling = KeyCode.C;
        public KeyCode JumpKing = KeyCode.P;
        public KeyCode slot1 = KeyCode.Alpha1;
        public KeyCode slot2 = KeyCode.Alpha2;
        public KeyCode slot3 = KeyCode.Alpha3;
        public bool useUi;
        public BulletFireControl bullet;
        public CameraMoveControl cam;
        public GunController gun;

        [Header("Camera Input")]
        //public string rotateCameraXInput = "Mouse X";
        //public string rotateCameraYInput = "Mouse Y";

        [HideInInspector] public PlayerControl cc;
        //[HideInInspector] public vThirdPersonCamera tpCamera;
        //[HideInInspector] public Camera cameraMain;

        // UI
        private InGameUI inGameUI;
        private PiUI piUI;
        private EquipUI equipUI;


        #endregion


        protected virtual void InitilizeController() 
        {
            cc = GetComponent<PlayerControl>();
            inGameUI = gameObject.GetComponentInChildren<InGameUI>();
            piUI = inGameUI.GetComponentInChildren<PiUI>();
            equipUI = inGameUI.GetComponentInChildren<EquipUI>();
        }

        void Start()
        {
            InitilizeController();
        }
        private void FixedUpdate()
        {
            cc.FixedUpdateControll();
        }
        void Update() 
        {
            InputHandle();
        }

        void InputHandle() 
        {
            MoveInput();
            SprintInput();
            JumpInput();
            FireInput();
            cam.CameraMove();
            //GunReLoad();
            SlotChange();
            JumpKingMode();
        }
        void JumpKingMode()
        {
            if (Input.GetKeyDown(JumpKing))
            {
                cc.moveMod = cc.moveMod == 1 ? 0 : 1;
            }
        }
        void SlotChange()
        {
            if (Input.GetMouseButtonUp(0) && useUi)
            {
                piUI.SelectItem();
                cc.SlotCheck(equipUI.currentItem);
            }

            if (Input.GetKey(KeyCode.Tab))
            {
                useUi = true;
                inGameUI.ShowPiUI(true);
            }
            else
            {
                useUi = false;
                inGameUI.ShowPiUI(false);
            }

            if (Input.GetKey(KeyCode.Tab)) inGameUI.ShowPiUI(true);
            else inGameUI.ShowPiUI(false);
        }

        void JumpInput()
        {
            if (Input.GetKeyDown(jumpInput) && (cc.isGround || cc.isDoubleJump) && cc.moveMod == 0)
            {
                cc.Jump();
                cc.onPlatform = false;
            }
            else if(Input.GetKey(jumpInput) && cc.isGround && cc.moveMod == 1)
            {
                cc.jumpKingPower += 0.1f;
            }

            if(Input.GetKeyUp(jumpInput) && cc.jumpKingPower != 0 && cc.moveMod != 0)
            {
                cc.JumpKingJump();
            }
            //else
            //{
            //    cc.AddGravity();
            //}
        }
        public virtual void MoveInput()
        {
            cc.input.x = Input.GetAxis(horizontalInput);
            //cc.input.z = Input.GetAxis(verticallInput);
            if (Input.GetKeyDown(rolling) && cc.isGround && !cc.isRolling)
            {
                cc.isRolling = true;
                cc.isRollinga = true;
            }
        }
        protected virtual void SprintInput()
        {
            if (Input.GetKey(sprintInput) && (cc.isSprint == true || cc.sprint == 3f))
            {
                cc.sprint = 3f;
                cc.isSprinting = true;
                //Debug.Log("Sprint Start");
            }
            else if (Input.GetKeyUp(sprintInput) || cc.isSprint == false)
            { 
                cc.sprint = 0f;
                cc.isSprinting = false;
                //Debug.Log("Sprint End");
            }
        }
        void FireInput()
        {
            if (Input.GetButtonDown("Fire1") && gun.gameObject.activeSelf)
            {
                Debug.Log("Try Shot");
                bullet.FireBullet();
            }

            if (Input.GetButtonDown("Fire1") && cc.handStone.gameObject.activeSelf)
            {
                Debug.Log("Throw Stone");

                cc.ThrowStone();
            }
        }
        public void GunReLoad()
        {
            //if(/*Input.GetKeyDown(reloadGun) && */gun.gameObject.activeSelf)
           // {
                Debug.Log("Bullets Reloading....");
                bullet.Reload();
            //}
        }
    }
}

