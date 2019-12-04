namespace Code
{
    public class Game
    {
        private const int _pinTotal = 10;
        private readonly int[] _rolls = new int[21];
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
            for (var frame = 0; frame < 10; frame++)
            {
                if (_rolls[firstInFrame] == _pinTotal)  // Strike.
                {
                    total += _pinTotal + _rolls[firstInFrame+1] + _rolls[firstInFrame+2];
                    firstInFrame++;
                }
                else if (IsSpare(firstInFrame))
                {
                    total += _pinTotal + _rolls[firstInFrame+2];
                    firstInFrame += 2;
                }
                else
                {
                    total += _rolls[firstInFrame] + _rolls[firstInFrame+1];
                    firstInFrame += 2;
                }
            }

            return total;
        }

        private bool IsSpare(int firstInFrame)
        {
            return _rolls[firstInFrame] + _rolls[firstInFrame + 1] == _pinTotal;
        }
    }
}