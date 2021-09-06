namespace Blocks
{
    public static class Pieces
    {
        private static readonly Arr pieceO = new(new[] {
            0, 0, 0, 0,
            0, 1, 1, 0,
            0, 1, 1, 0,
            0, 0, 0, 0,
        }, 4);
        private static readonly Arr pieceI = new(new[] {
            0, 0, 0, 0,
            0, 0, 0, 0,
            2, 2, 2, 2,
            0, 0, 0, 0,
        }, 4);
        private static readonly Arr pieceT = new(new[] {
            0, 0, 0, 0,
            0, 3, 0, 0,
            3, 3, 3, 0,
            0, 0, 0, 0,
        }, 4);
        private static readonly Arr pieceL = new(new[] {
            0, 0, 0, 0,
            0, 0, 4, 0,
            4, 4, 4, 0,
            0, 0, 0, 0,
        }, 4);
        private static readonly Arr pieceJ = new(new[] {
            0, 0, 0, 0,
            5, 0, 0, 0,
            5, 5, 5, 0,
            0, 0, 0, 0,
        }, 4);
        private static readonly Arr pieceS = new(new[] {
            0, 0, 0, 0,
            0, 6, 6, 0,
            6, 6, 0, 0,
            0, 0, 0, 0,
        }, 4);
        private static readonly Arr pieceZ = new(new[] {
            0, 0, 0, 0,
            7, 7, 0, 0,
            0, 7, 7, 0,
            0, 0, 0, 0,
        }, 4);

        public static readonly Arr[] PIECES = new[]
        {
            pieceI,
            pieceO,
            pieceT,
            pieceL,
            pieceJ,
            pieceS,
            pieceZ
        };

    }
}