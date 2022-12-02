using UnityEngine;

public static class Utilites
{

    /// <summary>
    /// ���������� �����������, � ������� ���������� ��������, ����� ������ ������
    /// </summary>
    public static AimDirection LookAtPlayer(Transform gameObjectTransform)
    {
        if (gameObjectTransform.position.x > GameManager.Instance.GetPlayer().transform.position.x)
        {
            return AimDirection.left;
        }
        else
        {
            return AimDirection.right;
        }
    }

}
