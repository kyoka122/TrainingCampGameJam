namespace Character
{
    public interface IJumpLogic
    {
        /// <summary>
        /// Jump���Ă΂ꂽ�Ƃ��̏���
        /// </summary>
        public void Jump(float power);

        /// <summary>
        /// �W���̕ψʂ�擾���� ���x�����ς��\��������
        /// </summary>
        public float GetDeltaHeight(float deltaTime);
    }
}
