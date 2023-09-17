namespace Character
{
    public interface IJumpLogic
    {
        /// <summary>
        /// Jump‚ªŒÄ‚Î‚ê‚½‚Æ‚«‚Ìˆ—
        /// </summary>
        public void Jump(float power);

        /// <summary>
        /// •W‚‚Ì•ÏˆÊ‚ğæ“¾‚·‚é ‘¬“x“™‚ª•Ï‚í‚é‰Â”\«‚ª‚ ‚é
        /// </summary>
        public float GetDeltaHeight(float deltaTime);
    }
}
