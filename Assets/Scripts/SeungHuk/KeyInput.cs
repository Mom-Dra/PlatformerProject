using System.Runtime.InteropServices;
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
        private UIManager uiManager;
        private PiUI piUI;
        private EquipUI equipUI;


        #endregion


        protected virtual void InitilizeController() //�ʱ� �� �ε�
        {
            cc = GetComponent<PlayerControl>();
            uiManager = gameObject.GetComponentInChildren<UIManager>();
            piUI = uiManager.GetComponentInChildren<PiUI>();
            equipUI = uiManager.GetComponentInChildren<EquipUI>();
        }

        void Start()
        {
            InitilizeController();
        }
        private void FixedUpdate()
        {
            cc.UpdateControll();
        }
        void Update() // ���� ������Ʈ
        {
            InputHandle();
        }

        void InputHandle() //�ٲ�� �κ�
        {
            MoveInput();
            SprintInput();
            JumpInput();
            FireInput();
            cam.CameraMove();
            GunReLoad();
            SlotChange();
        }
        void SlotChange()
        {
            if (Input.GetMouseButtonUp(0) && useUi)//��Ŭ��
            {
                piUI.SelectItem();
                cc.SlotCheck(equipUI.currentItem);
            }

            if (Input.GetKey(KeyCode.Tab))
            {
                useUi = true;
                uiManager.ShowPiUI(true);
            }
            else
            {
                useUi = false;
                uiManager.ShowPiUI(false);
            }

            if (Input.GetKey(KeyCode.Tab))  uiManager.ShowPiUI(true);
            else                            uiManager.ShowPiUI(false);
        }

        void JumpInput()
        {
            if (Input.GetKeyDown(jumpInput) && (cc.isGround || cc.isDoubleJump))
            {
                cc.Jump();
            }
            else
            {
                cc.AddGravity();
            }
        }
        public virtual void MoveInput()
        {
            cc.input.x = Input.GetAxis(horizontalInput);
            cc.input.z = Input.GetAxis(verticallInput);
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
                //Debug.Log("�޸��� ��");
            }
            else if (Input.GetKeyUp(sprintInput) || cc.isSprint == false)
            { 
                cc.sprint = 0f;
                cc.isSprinting = false;
                //Debug.Log("�޸��� ����");
            }
        }
        void FireInput()
        {
            // �Ѿ� �߻�
            if (Input.GetButtonDown("Fire1") && gun.gameObject.activeSelf)
            {
                Debug.Log("�߻�");
                bullet.FireBullet();
            }

            // �� ������
            if (Input.GetButtonDown("Fire1") && cc.handStone.gameObject.activeSelf)
            {
                Debug.Log("�� ������ �õ�");

                cc.ThrowStone();
            }
        }
        void GunReLoad()
        {
            if(Input.GetKeyDown(reloadGun) && gun.gameObject.activeSelf)
            {
                Debug.Log("����");
                gun.maxBullet = 6;
            }
        }
    }
}

