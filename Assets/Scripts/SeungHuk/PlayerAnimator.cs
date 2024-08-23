
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
        public bool isRollinga;
        public bool isDead;


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
            animator.SetBool(vAnimatorParameters.IsRolling, isRollinga);
            animator.SetBool(vAnimatorParameters.IsDead, isDead);
        }
        //void SetGunAnimation()
        //{
            // 'Idle' ���¸� �ٸ� ���·� ����
        //    animator.Play(stateName); // ���� ����
        //}

    }

    public static partial class vAnimatorParameters
    {
        public static int IsGrounded = Animator.StringToHash("IsGrounded");
        public static int IsRunning = Animator.StringToHash("IsRunning");
        public static int IsSprinting = Animator.StringToHash("IsSprinting");
        public static int IsEquipGun = Animator.StringToHash("IsEquipGun");
        public static int IsRolling = Animator.StringToHash("IsRolling");
        public static int IsDead = Animator.StringToHash("IsDead");
    }

}