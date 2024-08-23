using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class BulletFireControl : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������
    public PlayerControl player;
    public GunController gun;

    public void FireBullet()
    {
        if (bulletPrefab && gun.maxBullet != 0)
        {
            gun.maxBullet--;
            Debug.Log("�߻�Ϸ�");
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // �Ѿ��� �߻��� ��ġ���� �Ѿ��� �����մϴ�.
            GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);

            // �Ѿ��� Rigidbody�� ��� ������ �����մϴ�.
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                // �÷��̾ �������� �и� ������ �ָ� ��.

                // Rigid ���� ��ư �÷��̾�� �޾Ƽ� ��� ������ �������� ���¿� ���� �����ϰ� �÷��̾ ������ ������Ѿ� ��.

                // �÷��̾����� �¿� ���Ⱚ�� �ְ�, ������ �ݵ� ���� ��.
                // �ݵ� ���� ���ݿ� ���� �ٸ��� �����Ű��
                // �¿� ���� ���� ������ �и��� �������� �� ( ���߿� ������ ���ư��鼭 ���� ���� ���� ���� �� �ֱ� ���� )
                // ����� ���� ũ�⸦ ���� �÷��̾�� ���� �ִµ�, �� ������ x, y�����θ� ������Ѽ� Rigid�� �����Ű��
                // Z������ Ƣ�� ���� ���� ��?

                player.Rebound(10f);
                Vector3 direction = transform.right * 20f; // �ӵ� ����
                bulletRb.velocity = direction;

            }
        }
    }
}
