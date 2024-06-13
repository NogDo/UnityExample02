public interface IHitable
{
    public void Hit(float damage);
}

#region 06.12 과제
/*
1. IInteractable 인터페이스 정의하기

2. Chest 클래스와 Box 클래스는 IInteractable 인터페이스를 구현(implements)

3. 플레이어에게 Rigidbody 또는 Character Controller 컴포넌트를 붙여 움직임 구현하기

4. Box 및 Chest의 콜라이더와 닿을 경우의 상호작용 가능하도록 설정 (Trigger or Collision)

5. 닿은 물체가 IInteractable 인터페이스를 구현하여 상호작용이 가능한 사물일 경우, F버튼을 누르면 상호작용 하도록
ㄴ Chest의 경우 열리게 Box는 플레이어 머리 위로 들거나 사라지거나 등등...

번외) Canvas 활용이 익숙한 학생은 상호작용 가능한 상태일 때 F버튼 누르라고 화면에 띄우시오.
 
*/
#endregion