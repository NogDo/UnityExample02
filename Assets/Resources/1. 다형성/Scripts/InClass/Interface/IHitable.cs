public interface IHitable
{
    public void Hit(float damage);
}

#region 06.12 ����
/*
1. IInteractable �������̽� �����ϱ�

2. Chest Ŭ������ Box Ŭ������ IInteractable �������̽��� ����(implements)

3. �÷��̾�� Rigidbody �Ǵ� Character Controller ������Ʈ�� �ٿ� ������ �����ϱ�

4. Box �� Chest�� �ݶ��̴��� ���� ����� ��ȣ�ۿ� �����ϵ��� ���� (Trigger or Collision)

5. ���� ��ü�� IInteractable �������̽��� �����Ͽ� ��ȣ�ۿ��� ������ �繰�� ���, F��ư�� ������ ��ȣ�ۿ� �ϵ���
�� Chest�� ��� ������ Box�� �÷��̾� �Ӹ� ���� ��ų� ������ų� ���...

����) Canvas Ȱ���� �ͼ��� �л��� ��ȣ�ۿ� ������ ������ �� F��ư ������� ȭ�鿡 ���ÿ�.
 
*/
#endregion