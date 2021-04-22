using BowlingGame;
using Xunit;

namespace BowlingGameTests
{
    public class GameTests
    {
        private readonly Game _game;

        public GameTests()
        {
            _game = new Game();
        }

        [Fact]
        public void Game_CallRoll_CalledSuccesfully()
        {
            _game.Roll(0);
        }

        [Fact]
        public void Game_FullGameZeroes_ScoreIsZero()
        {
            RollMany(20, 0);

            int resultScore = _game.Score();

            Assert.Equal(0, resultScore);
        }

        [Fact]
        public void Game_FullGameOnes_ScoreIsCorrect()
        {
            RollMany(20, 1);

            int resultScore = _game.Score();

            Assert.Equal(20, resultScore);
        }

        [Fact]
        public void Game_OneSpare_ScoreIsCorrect()
        {
            _game.Roll(5);
            _game.Roll(5);
            RollMany(18, 1);

            int resultScore = _game.Score();

            Assert.Equal(29, resultScore);
        }

        [Fact]
        public void Game_FullGameFives_ScoreIsCorrect()
        {
            RollMany(21, 5);

            int resultScore = _game.Score();

            Assert.Equal(150, resultScore);
        }

        [Fact]
        public void Game_OneStrike_ScoreIsCorrect()
        {
            _game.Roll(10);
            RollMany(18, 1);

            int resultScore = _game.Score();

            Assert.Equal(30, resultScore);
        }

        [Fact]
        public void Game_FullGameStrikes_ScoreIsCorrect()
        {
            RollMany(12, 10);

            int resultScore = _game.Score();

            Assert.Equal(300, resultScore);
        }

        private void RollMany(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}