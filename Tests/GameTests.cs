using Code;
using Xunit;

namespace Tests
{
    public class GameTests
    {
        private readonly Game _game;

        public GameTests()
        {
            _game = new Game();
        }

        [Fact]
        public void GutterGame()
        {
            RollMany(20, 0);

            Assert.Equal(0, _game.Score());
        }        
        
        [Theory]
        [InlineData(1, 20)]
        [InlineData(2, 40)]
        [InlineData(3, 60)]
        [InlineData(4, 80)]
        public void AllOnesToAllFours(int pins, int expected)
        {
            RollMany(20, pins);

            Assert.Equal(expected, _game.Score());
        }

        [Fact]
        public void OneSpare()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);

            Assert.Equal(16, _game.Score());
        }       
        
        [Fact]
        public void OneStrike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(17, 0);

            Assert.Equal(24, _game.Score());
        }

        [Fact]
        public void PerfectGame()
        {
            RollMany(12, 10);

            Assert.Equal(300, _game.Score());
        }

        [Fact]
        public void SpareInLastFrame()
        {
            RollMany(18, 0);
            RollSpare();
            _game.Roll(3);

            Assert.Equal(13, _game.Score());
        }       
        
        [Fact]
        public void StrikeInLastFrame()
        {
            RollMany(18, 0);
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);

            Assert.Equal(17, _game.Score());
        }

        private void RollMany(int count, int pins)
        {
            for(var i = 0; i < count; i++)
                _game.Roll(pins);
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }        
        
        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }
    }
}