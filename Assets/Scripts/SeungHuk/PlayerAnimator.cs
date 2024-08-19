
using UnityEngine;
namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        #region Variables                

        public Animator animator;


        public bool isSprinting;
        public bool isGrounded;
        public bool isRunning;
        public bool IsEquipedGun;


        #endregion  
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        public void UpdateAnimator()
        {
            if (animator == null || !animator.enabled) return;

            animator.SetBool(vAnimatorParameters.IsRunning, isRunning);
            animator.SetBool(vAnimatorParameters.IsSprinting, isSprinting);
            animator.SetBool(vAnimatorParameters.IsGrounded, isGrounded);
            animator.SetBool(vAnimatorParameters.IsEquipGun, IsEquipedGun);
        }
        //void SetGunAnimation()
        //{
            // 'Idle' 상태를 다른 상태로 변경
        //    animator.Play(stateName); // 상태 변경
        //}

    }

    public static partial class vAnimatorParameters
    {
        public static int IsGrounded = Animator.StringToHash("IsGrounded");
        public static int IsRunning = Animator.StringToHash("IsRunning");
        public static int IsSprinting = Animator.StringToHash("IsSprinting");
        public static int IsEquipGun = Animator.StringToHash("IsEquipGun");
    }

}