using System;

namespace TicTacToeWPF
{
    class TicTacToeLogic
    {
        private FlagType[,] board { get; set; }
        private FlagType currentPlayer { get; set; }
        public bool isGameOver { get; set; }
        public int[] winningPositions { get; set; }

        public TicTacToeLogic()
        {
            board = new FlagType[3, 3];
            isGameOver = false;

            Random rng = new Random();
            currentPlayer = FlagType.PlayerX;
        }

        public void MakeMove(int row, int column)
        {
            board[row, column] = currentPlayer;
            isGameOver = CheckForWin();
            SwitchPlayers();
        }

        public bool CheckForWin()
        {
            // check horizontal
            for(int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] != FlagType.Empty)
                {
                    winningPositions = new int[] { (0 + i * 3), (1 + i * 3), (2 + i * 3) };
                    return true;
                }
            }

            // check vertical
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[0, i] == board[2, i] && board[0, i] != FlagType.Empty)
                {
                    winningPositions = new int[] { (0 * 3 + i), (1 * 3 + i), (2 * 3 + i) };
                    return true;
                }
            }

            // check diagonal
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] != FlagType.Empty)
            {
                winningPositions = new int[] { 0, 4, 8 };
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] != FlagType.Empty)
            {
                winningPositions = new int[] { 2, 4, 6 };
                return true;
            }

            return false;
        }

        public void SwitchPlayers()
        {
            if(currentPlayer == FlagType.PlayerX)
            {
                currentPlayer = FlagType.PlayerO;
            }
            else
            {
                currentPlayer = FlagType.PlayerX;
            }
        }

        public char GetPlayerChar()
        {
            if (currentPlayer == FlagType.PlayerX)
            {
                return 'X';
            }
            else
            {
                return 'O';
            }
        }

        public bool IsFull()
        {
            foreach(var value in board)
            {
                if(value == FlagType.Empty)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
