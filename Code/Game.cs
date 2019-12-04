namespace Code
{
    public class Game
    {
        private const int _numberOfFrames = 10;
        private const int _numberOfPins = 10;
        private readonly int[] _rolls = new int[2 * _numberOfFrames + 1];
        private int _current;

        public void Roll(int pins)
        {
            _rolls[_current] += pins;
            _current++;
        }

        public int Score()
        {
            var total = 0;
            var firstInFrame = 0;
            for (var frame = 0; frame < _numberOfFrames; frame++)
            {
                if (IsStrike(firstInFrame))
                {
                    total += _numberOfPins + StrikeBonus(firstInFrame);
                    firstInFrame++;
                }
                else
                {
                    total += _rolls[firstInFrame] + _rolls[firstInFrame + 1];
                    if (IsSpare(firstInFrame))
                        total += SpareBonus(firstInFrame);

                    firstInFrame += 2;
                }
            }

            return total;
        }

        private bool IsStrike(int firstInFrame)
        {
            return _rolls[firstInFrame] == _numberOfPins;
        }

        private int StrikeBonus(int firstInFrame)
        {
            return _rolls[firstInFrame + 1] + _rolls[firstInFrame + 2];
        }

        private bool IsSpare(int firstInFrame)
        {
            return _rolls[firstInFrame ] + _rolls[firstInFrame + 1] == _numberOfPins;
        }

        private int SpareBonus(int firstInFrame)
        {
            return _rolls[firstInFrame + 2];
        }
    }
}