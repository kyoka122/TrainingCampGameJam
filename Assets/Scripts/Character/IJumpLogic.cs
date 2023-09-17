namespace Character
{
    public interface IJumpLogic
    {
        /// <summary>
        /// Jumpが呼ばれたときの処理
        /// </summary>
        public void Jump(float power);

        /// <summary>
        /// 標高の変位を取得する 速度等が変わる可能性がある
        /// </summary>
        public float GetDeltaHeight(float deltaTime);
    }
}
