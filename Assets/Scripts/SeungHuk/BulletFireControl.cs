using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class BulletFireControl : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public PlayerControl player;
    public GunController gun;

    public void FireBullet()
    {
        if (bulletPrefab && gun.maxBullet != 0)
        {
            gun.maxBullet--;
            Debug.Log("발사완료");
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // 총알을 발사할 위치에서 총알을 생성합니다.

            GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);

            // 총알의 Rigidbody를 얻고 방향을 설정합니다.
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                // 플레이어를 기준으로 밀릴 방향을 주면 됨.

                // Rigid 값을 암튼 플레이어에서 받아서 모든 물리를 받을지를 상태에 따라 결정하고 플레이어가 스스로 적용시켜야 함.

                // 플레이어한테 좌우 방향값을 주고, 적용할 반동 힘을 줘.
                // 반동 힘은 웨펀에 따라 다르게 적용시키고
                // 좌우 방향 값은 실제로 밀리는 방향으로 줘 ( 나중에 앞으로 나아가면서 베는 동작 등이 나올 수 있기 때문 )
                // 방향과 힘의 크기를 받은 플레이어에서 힘을 주는데, 그 방향은 x, y축으로만 적용시켜서 Rigid에 적용시키면
                // Z축으로 튀는 일은 없을 듯?

                player.Rebound(10f);
                Vector3 direction = transform.right * 20f; // 속도 조정
                bulletRb.velocity = direction;

            }
        }
    }
}
