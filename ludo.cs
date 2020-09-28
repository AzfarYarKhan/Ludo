using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using dice = System.Int32;
using piece = System.Int32;
  

namespace LudoRules
{
    /// <summary>
    /// This enum represents the possible choice of colors
    /// that pieces and squares and players can represent
    /// </summary>
    public enum Colors
    {
        Green,
        Yellow,
        Blue,
        Red,
    }
}
namespace LudoRules
{
    /// <summary>
    /// Objects that will be used by LudoBoard (pieces, squares, nests)
    /// </summary>
    public abstract class BoardObject
    {
        protected Colors color;
    }
}

namespace LudoRules
{
    /// <summary>
    /// The UI will receive this as a "board status update" from the Rule engine
    /// It may use this information however it pleases
    /// </summary>
    public struct GameState
    {
        public int[][] Squares;
        public int[][] ExitSquares;
        public int[] Nests;
        public int StartingPlayer;
    }
}

namespace LudoRules
{
    /// <summary>
    /// A very important part of the game
    /// </summary>
    public class Piece : BoardObject
    {
        #region Fields
        private bool isAlive;
        private bool isActive;
        private int ID;
        private int steps;
        private int position;
        private const int boardSize = 40;
        #endregion



        #region Constructor
        public Piece(Colors color, int ID)
        {
            Color = color;
            PieceID = ID;
            Alive = true;
            Active = false;
            Steps = 0;
            Position = 0;
        }
        #endregion



        #region Properties
        public bool Active
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }

        public bool Alive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public int PieceID
        {
            get { return this.ID; }
            set { this.ID = value; }
        }

        public int Steps
        {
            get { return this.steps; }
            set { this.steps = value; }
        }

        public int Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
                if (this.position >= boardSize && steps < boardSize)
                {
                    this.position -= boardSize;
                } // wrap arund
            }
        }

        public Colors Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        #endregion


        #region Methods
        public override string ToString()
        {
            return String.Format("Piece, number: {0}, active: {1}, color: {2}, position: {3}",
                                    PieceID, Active, Color, Position);
        }
        #endregion


    }
}

namespace LudoRules
{
    /// <summary>
    /// Nest is a stack-like construction which collects inactive pieces
    /// </summary>
    public class Nest : BoardObject
    {
        #region Fields
        private Stack<Piece> pieces;
        #endregion

        #region Constructor
        public Nest(Colors color, Piece[] pieces)
        {
            this.pieces = new Stack<Piece>();
            this.color = color;

            foreach (var piece in pieces)
            {  pushPiece(piece); }

        }
        #endregion


        #region Properties
        public int Count
        {
            get { return this.pieces.Count; }
        }        
        #endregion



        #region Methods
        public Piece popPiece()
        {
            return pieces.Pop();
        }
        public void pushPiece(Piece piece)
        {
            pieces.Push(piece);
        }

        public override string ToString()
        {
            return String.Format("\nNest, Color: {0}, pieces count: {1}", color.ToString(), Count);
        }

        #endregion  
    }
}



namespace LudoRules
{
    /// <summary>
    /// A GameEvent is what the Rule engine will receive from above from the UI
    /// It's the "API"
    /// </summary>
    public struct GameEvent
    {
        public Colors Player;
        public int Piece;
        public dice Dice;
        public Dictionary<Colors, dice> Dices;
    }
}
namespace LudoRules
{
    /// <summary>
    /// A player has a color and controls all the pieces with that color, by rolling the dice
    /// </summary>
    public class Player : BoardObject
    {
        #region Fields
        private bool isActive;
        #endregion



        #region Constructor
        public Player(Colors color)//, int numOfPieces)
        {
            PlayerID = color;
            isActive = false;
        }
        #endregion



        #region Properties
        public Colors PlayerID
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public bool Active
        {
            get { return isActive; }
            set { isActive = value; }
        }
        #endregion



        #region Methods
        public override string ToString()
        {
            string status = String.Format("\nPlayer: {0}", PlayerID);
            return status;
        }
        #endregion

    }
}


namespace LudoRules
{
    /// <summary>
    /// There are two types of squares, just to make it easier to handle abstract-ly
    /// </summary>
    public class Square : BoardObject
    {
        protected int SquareID;
        protected Piece occupant;

        public Square(Colors color, int number)
        {
            this.color = color;
            this.SquareID = number;
            this.occupant = null;
        }

        public Piece Occupant
        {
            get { return this.occupant; }
            set { this.occupant = value; }
        }

        public override string ToString()
        {
            string status = (occupant != null) ?
                String.Format("\nSquare, color: {0}, id: {1}, is occupied by: {2}",
                this.color, this.SquareID, this.occupant.ToString()) :
                String.Format("\nSquare, color: {0}, id: {1}, is occupied by: {2}",
                this.color, this.SquareID, "none");
            return status;
        }
    }



    public class ExitSquare : Square
    {
        public ExitSquare(Colors color, int number) : base(color, number) { }
        public override string ToString()
        {
            return base.ToString() + "(exit)";
        }
    }
}
namespace LudoRules
{
    /// <summary>
    /// We want to make sure that board contains mathods and attributes
    /// to keep track of the actual state of of what's taking place
    /// and also services to change its state
    /// </summary>
    public class LudoBoard
    {       
        #region Fields
        private bool isActive = false;

        public int numOfActivePlayers;
        private const int numOfPlayers = 4;
        private const int numOfPiecesPerPlayer = 4;
        private const int numOfSquaresPerSide = 10;
        private const int numOfExitSquaresPerSide = 4;
        private const int numOfMaximumStepsPerLap = numOfSquaresPerSide * numOfPlayers;
        private const int numOfStepsToExit = numOfMaximumStepsPerLap + numOfExitSquaresPerSide;

    

        private Player[] players;
        private Piece[][] pieces;
        private Nest[] nests;
        private Square[][] squares;
        private Square[][] exitSquares;
        #endregion



        #region Constructor
        /// <summary>
        /// By default, assume players are 4
        /// </summary>
        public LudoBoard() : this(4) { } 
        public LudoBoard(int numOfPlayers)
        {
            this.numOfActivePlayers = numOfPlayers;

            generateBoard();


            System.Diagnostics.Debug.Write("\nBoard constructed");
            //Debug.Write("\nBoard constructed");
        }
        #endregion



        #region Properties
        public bool Active
        {
            get { return isActive;  }
            set { isActive = value;  }
        }

        /// <summary>
        /// The rule engine and the test engine will make good use of this information contained here
        /// </summary>
        public Dictionary<string, object> State
        {
            get
            {
                Dictionary<string, object> gameState = new Dictionary<string, object>();

                gameState.Add("board", this.ToString());
                gameState.Add("players", players);
                gameState.Add("pieces", pieces);
                gameState.Add("nests", nests);
                gameState.Add("squares", squares);
                gameState.Add("exitsquares", exitSquares);

                return gameState;
            }
        }
        #endregion



        #region Methods
        /// <summary>
        /// Initialize
        /// </summary>
        private void generateBoard()
        {
            generatePlayersAndPieces();
            generateNests();
            generateSquares();
            Active = true;
        }
        private void generateNests()
        {
            nests = new Nest[numOfPlayers];

            for (int i = 0; i < numOfPlayers; i++)
            {
                nests[i] = new Nest((Colors)i, pieces[i]);
            }
        }
        private void generatePlayersAndPieces()
        {
            players = new Player[numOfPlayers];
            pieces = new Piece[numOfPlayers][];

            for (int i = 0; i < numOfPlayers; i++)
            {
                players[i] = new Player((Colors)i);
                generatePieces((Colors)i);
            }
        }
        private void generatePieces(Colors color)
        {
            pieces[(int)color] = new Piece[numOfPiecesPerPlayer];
            for (int i = 0; i < numOfPiecesPerPlayer; i++)
            {
                pieces[(int)color][i] = new Piece(color, i);
            }
        }
        private void generateSquares()
        {
            squares = new Square[numOfPlayers][];
            exitSquares = new ExitSquare[numOfPlayers][];

            for (int side = 0; side < numOfPlayers; side++)
            {
                squares[side] = new Square[numOfSquaresPerSide];
                for (int position = 0; position < numOfSquaresPerSide; position++)
                {
                    int squarePosition = position + (side * numOfSquaresPerSide);
                    squares[side][position] = new Square((Colors)side, squarePosition);
                }

                exitSquares[side] = new ExitSquare[numOfExitSquaresPerSide];
                for (int position = 0; position < numOfExitSquaresPerSide; position++)
                {
                    exitSquares[side][position] = new ExitSquare((Colors)side, position);
                }
            }
        }

        public void deActivatePiece(Piece piece)
        {
            nests[(int)piece.Color].pushPiece(piece);
            piece.Active = false;
        }

        /// <summary>
        /// The nest works like a stack
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private Piece popPieceFromNest(Colors color)
        {
            return nests[(int)color].popPiece();
        }
        /// <summary>
        /// Stack-like behaviour
        /// </summary>
        /// <param name="piece"></param>
        private void pushPieceToNest(Piece piece)
        {
            nests[(int)piece.Color].pushPiece(piece);
        }

        /// <summary>
        /// Pop a piece but push it back if there's a collision
        /// </summary>
        /// <param name="color"></param>
        /// <param name="isPieceActivated"></param>
        public void activatePiece(Colors color, out bool isPieceActivated)
        {
            Piece piece = popPieceFromNest(color);
            isPieceActivated = tryIntroducePiece(piece);
            piece.Active = isPieceActivated;
            piece.Position = 0 + ((int)color * numOfSquaresPerSide);
            if (!isPieceActivated)  
            {
                pushPieceToNest(piece);
            }
            else      
            { 
                players[(int)color].Active = true;
            }
        }

        /// <summary>
        /// By moving through the goal the piece gets killed
        /// </summary>
        /// <param name="piece"></param>
        private bool killPiece(Piece piece)
        {
            Square currentPosition = locateSquare(piece.Steps, piece.Position, piece.Color);
            currentPosition.Occupant = null;
            piece.Alive = false;
            piece.Active = false;
            return true;
        }

        private bool allPiecesDead(Colors color)
        {
            foreach (var piece in pieces[(int)color])
            { 
                if (piece.Alive) { return false;  }
            }
            return true;
        }
        
        /// <summary>
        /// Here we need to consider 3 scenarios:
        /// - If we are about to roll the dice and have a chance at moving to the exit squares 
        /// - chance at moving through the goal
        /// - "normal" behaviour
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="steps"></param>
        /// <param name="isMoveSuccesful"></param>
        public void tryMovePiece(Piece piece, int steps, ref bool isMoveSuccesful)
        {
            int requestedSteps = piece.Steps + steps;

            // 3 scenarios //
            if (requestedSteps == numOfStepsToExit)
            {
                System.Diagnostics.Debug.Write("\nExiting");
                //Debug.Write("\nExiting");
                isMoveSuccesful = killPiece(piece);
                checkPlayerDeActivation(piece.Color);
            }
            // Almost quitting
            else if (requestedSteps > numOfStepsToExit)
            {
                System.Diagnostics.Debug.Write(String.Format(
                            "\nGoing to the exit squares. Steps walked: {0}, position: {1}, trying new pos: {2}",
                            piece.Steps, piece.Position, piece.Position + steps));

                //Debug.Write(String.Format(
                //            "\nGoing to the exit squares. Steps walked: {0}, position: {1}, trying new pos: {2}",
                //            piece.Steps, piece.Position, piece.Position + steps));

                // We will have to step back x steps from the goal square (overflow)
                Square currentPosition = locateSquare(piece.Steps, piece.Position, piece.Color);
                calculateNewStepsAfterMissedTarget(piece.Position, requestedSteps, ref steps);
                Square requestedPosition = locateSquare(requestedSteps, piece.Position + steps, piece.Color);
               
                isMoveSuccesful = tryMove(currentPosition, requestedPosition, piece, steps, requestedSteps);

            }
            else
            {
                System.Diagnostics.Debug.Write(String.Format(
                    "\nSteps walked: {0}, position: {1}, trying new pos: {2}", 
                     piece.Steps, piece.Position, piece.Position + steps));
                //Debug.Write(String.Format(
                //    "\nSteps walked: {0}, position: {1}, trying new pos: {2}",
                //     piece.Steps, piece.Position, piece.Position + steps));

                Square currentPosition = locateSquare(piece.Steps, piece.Position, piece.Color);
                Square requestedPosition = locateSquare(requestedSteps, piece.Position + steps, piece.Color);

                isMoveSuccesful = tryMove(currentPosition, requestedPosition, piece, steps, requestedSteps);
            }
        }

        private bool checkPlayerDeActivation(Colors color)
        {
            foreach (var piece in pieces[(int)color])
            {
                    if (piece.Alive) 
                    { 
                        return false;  
                    }
            }
            players[(int)color].Active = false;
            return true;
        }

        /// <summary>
        /// This is a collision detector. 
        /// You need to get an exact match with the dice in order to exit
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="requestedSteps"></param>
        /// <returns></returns>
        private void calculateNewStepsAfterMissedTarget(int currentPosition, int requestedSteps, ref int steps)
        {
            int overflow = requestedSteps - numOfStepsToExit;
            int newPosition = numOfStepsToExit - overflow;
            int numOfNewSteps = newPosition - currentPosition;
            steps = numOfNewSteps;
        }

        /// <summary>
        /// 2 scenarios; two types of squares
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private Square locateSquare(int steps, int position, Colors color)
        {
            if (steps >= numOfMaximumStepsPerLap) // look in exitSquares
            {
                int side = (int)color;
                int squareID = position - (numOfPlayers * numOfSquaresPerSide);
                return exitSquares[side][squareID];
            }
            else // look in normal squares
            {
                int side = position / numOfSquaresPerSide;
                int squareID = position - (side * numOfSquaresPerSide);
                if (side == 4) { side = 0; } // wrap around array
                return squares[side][squareID];
            }    
        }

        /// <summary>
        /// To introduce: move a player from nest to square
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        private bool tryIntroducePiece(Piece piece)
        {
            Square firstSquare = squares[(int)piece.Color][0];
            bool isIntroduced = tryMove(null, firstSquare, piece, 0, 0);
            return isIntroduced;
        }

        /// <summary>
        /// We would like to achieve the following: 
        /// - replacing our last position with null
        /// - knocking pieces out or passing depending on collision with ourselves or others
        /// </summary>
        /// <param name="fromSquare"></param>
        /// <param name="toSquare"></param>
        /// <param name="piece"></param>
        /// <param name="steps"></param>
        /// <param name="requestedSteps"></param>
        /// <returns></returns>
        private bool tryMove(Square fromSquare, Square toSquare, Piece piece, int steps, int requestedSteps)
        {
            if (toSquare.Occupant == null)
            {
                //Debug.Write("\nMoving piece to square ");
                System.Diagnostics.Debug.Write("\nMoving piece to square ");
                move(piece, toSquare, fromSquare, steps);
                return true;
            }
            else
            {
                Piece occupyingPiece = toSquare.Occupant;
                //Debug.Write("\nSquare  is occupied");
                System.Diagnostics.Debug.Write("\nSquare  is occupied");
                if (occupyingPiece.Color == piece.Color)
                {
                    // Two pieces of the same color cannot occupy the same space (pass)
                    return false;
                }
                else
                {
                    // We will now deActivate the colliding piece, since it's not our own
                    // ... and insert our own piece
                    //Debug.Write("\nKnocking out piece ");
                    System.Diagnostics.Debug.Write("\nKnocking out piece ");
                    move(piece, toSquare, fromSquare, steps);
                    deActivatePiece(occupyingPiece);
                    if (nests[(int)occupyingPiece.Color].Count == 4)
                    { players[(int)occupyingPiece.Color].Active = false; }

                    return true;
                }
            }
        }
        private void move(Piece piece, Square toSquare, Square fromSquare, int steps)
        {
            if (fromSquare != null) { fromSquare.Occupant = null; }
            toSquare.Occupant = piece;
            piece.Steps += steps;
            piece.Position += steps;
        }

        /// <summary>
        /// Exports status to int[]-friendly API handling
        /// </summary>
        /// <returns></returns>
        public GameState ToArray()
        {
            GameState gameState = new GameState();

            gameState.Nests = nestsToArray();
            gameState.Squares = squaresToArray(squares, numOfSquaresPerSide);
            gameState.ExitSquares = squaresToArray(exitSquares, numOfExitSquaresPerSide);
            return gameState;
        }
        public int[] nestsToArray()
        {
            int[] nestsArray = new int[numOfPiecesPerPlayer];
            int i = 0;
            foreach (var nest in nests)
            { nestsArray[i++] = nest.Count; }
            return nestsArray;
        }
        public int[][] squaresToArray(Square[][] squaresToConvert, int squaresPerSide)
        {
            int[][] squaresArray = new int[numOfPlayers][];

            for (int i = 0; i < numOfPlayers; i++)
            {
                squaresArray[i] = new int[squaresPerSide]; 

                for (int j = 0; j < squaresPerSide; j++)
                {
                    squaresArray[i][j] = (squaresToConvert[i][j].Occupant == null) ? -1 :
                                          (int)squaresToConvert[i][j].Occupant.Color;
                }
            }
            return squaresArray;
        }

        public override string ToString()
        {
            return (Active) ? "Board is active" : "Board is not active";
        }         
        #endregion
    }
}





namespace LudoRules
{
    
    public class RuleEngine
    {
        #region Fields
        private int numOfPlayers;
        private LudoBoard ludoBoard;
        private bool isActive;
        #endregion



        #region Constructor
        public RuleEngine()
        {
            ActiveGame = false;
            setupBoard();
            this.numOfPlayers = ludoBoard.numOfActivePlayers;
        }
        #endregion



        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> State
        {
            get { return ludoBoard.State; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ActiveGame
        {
            get
            {
                return this.isActive;
            }
            set
            {
                this.isActive = value;

                string status = "\nGame is: ";
                status += (this.isActive) ? "active" : "not active";
                //Debug.Write(status);
                System.Diagnostics.Debug.Write(status);
            }
        }
        #endregion



        #region Methods
        private void setupBoard()
        {
            ludoBoard = new LudoBoard();
        }

        /// <summary>
        /// This is the method that UI will call in order to get a status update
        /// </summary>
        /// <param name="gameEvent"></param>
        /// <returns></returns>
        public GameState parseEvent(GameEvent gameEvent)
        {
            // Game State not active, Decide who is going to start
            if (!ActiveGame)
            {
                return decideStartingPlayer(gameEvent);
            }
            // Game State active, make active game relevant choices
            else
            {
                Colors playerID = gameEvent.Player;
                piece chosenPieceID = gameEvent.Piece;
                Piece[][] pieces = (Piece[][])ludoBoard.State["pieces"];
                Piece chosenPiece = pieces[(int)playerID][chosenPieceID];
                dice dice = gameEvent.Dice;
                Player[] players = (Player[])ludoBoard.State["players"];
                Player player = players[(int)playerID];


                //Debug.Write("\nDeciding action for player: " + player.PlayerID + ", with piece: " +
                //            chosenPiece.PieceID + ", player rolled: " + dice);
                System.Diagnostics.Debug.Write("\nDeciding action for player: " + player.PlayerID + ", with piece: " +
                            chosenPiece.PieceID + ", player rolled: " + dice);

                if (!chosenPiece.Active)
                {
                    bool isPieceActivated = tryActivate(playerID, dice);
                    //Debug.Write(String.Format("\nTried activating new piece: {0}", isPieceActivated));
                    System.Diagnostics.Debug.Write(String.Format("\nTried activating new piece: {0}", isPieceActivated));
                }
                else
                {
                    //Debug.Write("\nTrying to move piece."); 
                    System.Diagnostics.Debug.WriteLine("\nTrying to move piece."); ;
                    tryMove(chosenPiece, dice);
                }
            }
            return ludoBoard.ToArray(); // return updated state to UI
        }

        /// <summary>
        /// tryActivate(Piece)
        /// </summary>
        /// <param name="dice"></param>
        /// <returns></returns>
        private bool tryActivate(Colors playerID, dice dice)
        {
            bool isPieceActivated;

            switch (dice)
            {
                case 6:
                    ludoBoard.activatePiece(playerID, out isPieceActivated);
                    break;
                default:
                    isPieceActivated = false;
                    break;
            }
            return isPieceActivated;
        }

        /// <summary>
        ///  tryMove(piece)
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="dice"></param>
        private void tryMove(Piece piece, dice dice)
        {
            bool isMoveSuccesful = false;
            ludoBoard.tryMovePiece(piece, dice, ref isMoveSuccesful);
            string debug = (isMoveSuccesful) ? "Move succesful" : "Move not succesful";
            System.Diagnostics.Debug.WriteLine("\n" + debug);
            //Debug.WriteLine("\n" + debug);
        }

        /// <summary>
        /// If there is a player with higher result than the others, make them the winner
        /// Otherwise, do nothing
        /// </summary>
        /// <param name="gameEvent"></param>
        /// <param name="winner"></param>
        /// <returns></returns>
        private GameState decideStartingPlayer(GameEvent gameEvent)
        {
            GameState gameState = new GameState();
            Colors winner;
            Dictionary<Colors, dice> diceResults = gameEvent.Dices;

            System.Diagnostics.Debug.WriteLine("\ndiceResults check");
            //Debug.WriteLine("\ndiceResults check");
            // Create ordered List
            var orderedResults = diceResults.OrderBy(results => results.Value).ToList();
            // Check if there are two equally maximum results
            int last = orderedResults[numOfPlayers - 1].Value;
            int nextLast = orderedResults[numOfPlayers - 2].Value;
            bool isTie = (last == nextLast);

            if (isTie)
            {
                //Debug.WriteLine("\n it's a Tie");
                System.Diagnostics.Debug.WriteLine("\n it's a Tie");
                gameState.StartingPlayer = -1;
            }
            else
            {
                winner = orderedResults[numOfPlayers - 1].Key;
                gameState.StartingPlayer = (int)winner;
                System.Diagnostics.Debug.Write("\nWinner of round robin is: " + winner);
                //Debug.Write("\nWinner of round robin is: " + winner);
                ActiveGame = true;  // TODO: ???
            }
            return gameState;
        }
        #endregion
    }
}


namespace csharp_ludo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
