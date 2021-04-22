namespace BowlingGame
{
    public class Game
    {
        private int[] _rolls = new int[21];
        private int _currentRoll = 0;

        public void Roll(int numberOfPins)
        {
            _rolls[_currentRoll++] = numberOfPins;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (_rolls[roll] == 10)
                {
                    score += 10 + _rolls[roll + 1] + _rolls[roll + 2];
                    roll++;
                }
                else if (_rolls[roll] + _rolls[roll + 1] == 10)
                {
                    score += 10 + _rolls[roll + 2];
                    roll += 2;
                }
                else
                {
                    score += _rolls[roll] + _rolls[roll + 1];
                    roll += 2;
                }
            }

            return score;
        }
    }
}