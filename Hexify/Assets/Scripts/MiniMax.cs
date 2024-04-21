using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MiniMax : MonoBehaviour
{
    struct Move
    {
        int x, y, z;
    };

    GridManager g1;
    HexGen h1;
    bool flag = true;
    public Place ps;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        h1 = GetComponent<HexGen>();
        g1 = GetComponentInParent<GridManager>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int [] bestMove=new int[3];
        // bestMove=findBestMove(g1.grid,h1.maplength+1);
        evaluate(g1.grid, h1.maplength + 1);
    }


    bool isMovesLeft(int [,,]grid, int n)
{
    for (int y = n - 1; y >= -n + 1; y--)
    {
        for (int z = (y >= 0 ? 1 - n : 1 - n - y); z <= (y >= 0 ? n - 1 - y : n - 1); z++)
        {
            int x = -y - z;
            if (grid[x + n - 1, y + n - 1, z + n - 1] == 0)
                return true;
        }
    }
    for (int z = n - 1; z >= -n + 1; z--)
    {
        for (int x = (z >= 0 ? 1 - n : 1 - n - z); x <= (z >= 0 ? n - 1 - z : n - 1); x++)
        {
            int y = -x - z;
            if (grid[x + n - 1, y + n - 1, z + n - 1] == 0)
                return true;
        }
    }
    for (int x = n - 1; x >= -n + 1; x--)
    {
        for (int z = (x >= 0 ? 1 - n : 1 - n - x); z <= (x >= 0 ? n - 1 - x : n - 1); z++)
        {
            int y = -x - z;
            if (grid[x + n - 1, y + n - 1, z + n - 1] == 0)
                return true;
        }
    }
    return false;
}
    public int evaluate(int [,,]grid, int n = 3)
    {   
        int score=0;
        
        for (int y = n - 1; y >= -n + 1; y--)
        {
            int counter1 = 0;
            int counter2 = 0;
            for (int z = (y >= 0 ? 1 - n : 1 - n - y); z <= (y >= 0 ? n - 1 - y : n - 1); z++)
            {
                int x = -y - z;
                //  int x = -y - z;
                if (z + 1 <= (y >= 0 ? n - 1 - y : n - 1) && grid[x + n - 1, y + n - 1, z + n - 1] == grid[x + n - 2, y + n - 1, z + n])
                {
                    if (grid[x + n - 1, y + n - 1, z + n - 1] == 1)
                    {
                        counter1++;
                    }
                    if (grid[x + n - 1, y + n - 1, z + n - 1] == -1)
                    {

                        counter2++;
                    }
                }
                else if (z + 1 <= (y >= 0 ? n - 1 - y : n - 1) && grid[x + n - 1, y + n - 1, z + n - 1] != grid[x + n - 2, y + n - 1, z + n])
                {
                   
                    if (counter2>= 4 - 1)
                    {
                        score=-n*100;
                        if (3*n*n -3*n +1 -Place.numberOfPiecesLeft % 2==1)
                        {
                        Debug.Log("WIN1");
                        SceneManager.LoadScene("Lose");

                        }
                        else
                        {
                            SceneManager.LoadScene("Win");

                        }
                    }
                    else if (counter2 == 3 - 1)
                    {
                        score=n*100;
                        Debug.Log("Lose2");
                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            Debug.Log("WIN1");
                            SceneManager.LoadScene("Win");

                        }
                        else
                        {
                            SceneManager.LoadScene("Lose");

                        }
                    }
                    else if (counter2 == 2-1){
                        score+=-10;
                    }
                    counter2 = 0;
                }
                else if (z == (y >= 0 ? n - 1 - y : n - 1))
                {
                    
                    if (counter2>= 4 - 1)
                    {
                        score=-n*100;
                        Debug.Log("WIN2");

                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            Debug.Log("WIN1");
                            SceneManager.LoadScene("Lose");

                        }
                        else
                        {
                            SceneManager.LoadScene("Win");

                        }
                    }
                    else if (counter2 == 3 - 1)
                    {
                        score=n*100;
                        Debug.Log("Lose2");
                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            Debug.Log("WIN1");
                            SceneManager.LoadScene("Win");

                        }
                        else
                        {
                            SceneManager.LoadScene("Lose");

                        }
                    }
                    else if (counter2 == 2-1){
                        score+=-10;
                    }
                    counter2 = 0;
                }
                
                //Debug.Log("counter1" + counter1);
                //Debug.Log("counter2" + counter2);
                //Debug.Log(" x: " + (x + n - 1) + "y: " + (y + n - 1) + " z: " + (z + n - 1) + "N:" + g1.grid[x + n - 1, y + n - 1, z + n - 1]);
            }
        }
        for (int z = n - 1; z >= -n + 1; z--)
        {
            int counter1 = 0;
            int counter2 = 0;
            for (int x = (z >= 0 ? 1 - n : 1 - n - z); x <= (z >= 0 ? n - 1 - z : n - 1); x++)
            {
                int y = -x - z;
                if (x + 1 <= (z >= 0 ? n - 1 - z : n - 1) && grid[x + n - 1, y + n - 1, z + n - 1] == grid[x + n, y + n - 2, z + n - 1])
                {
                    if (grid[x + n - 1, y + n - 1, z + n - 1] == 1)
                    {
                        counter1++;
                    }
                    if (grid[x + n - 1, y + n - 1, z + n - 1] == -1)
                    {
                        counter2++;
                    }
                }
                else if (x + 1 <= (z >= 0 ? n - 1 - z : n - 1) && grid[x + n - 1, y + n - 1, z + n - 1] != grid[x + n, y + n - 2, z + n - 1])
                {
                   
                    if (counter2>= 4 - 1)
                    {
                        score=-n*100;
                        Debug.Log("WIN2");
                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            SceneManager.LoadScene("Lose");
                        }
                        else
                        {
                            SceneManager.LoadScene("Win");

                        }
                    }
                    else if (counter2 == 3 - 1)
                    {
                        score=n*100;
                        Debug.Log("Lose2");
                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            SceneManager.LoadScene("Win");
                        }
                        else
                        {
                            SceneManager.LoadScene("Lose");

                        }
                    }
                    else if (counter2 == 2-1){
                        score+=-10;
                    }
                    counter2 = 0;
                }
                else if (x == (z >= 0 ? n - 1 - z : n - 1))
                {
                    if (counter2>= 4 - 1)
                    {
                        score=-n*100;
                        Debug.Log("WIN2");
                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            SceneManager.LoadScene("Lose");
                        }
                        else
                        {
                            SceneManager.LoadScene("Win");

                        }
                    }
                    else if (counter2 == 3 - 1)
                    {
                        score=n*100;
                        Debug.Log("Lose2");
                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            SceneManager.LoadScene("Win");
                        }
                        else
                        {
                            SceneManager.LoadScene("Lose");

                        }
                    }
                    else if (counter2 == 2-1){
                        score+=-10;
                    }
                    counter2 = 0;
                }
                
                //Debug.Log("counter1" + counter1);
                //Debug.Log("counter2" + counter2);
                //Debug.Log(" x: " + (x + n - 1) + "y: " + (y + n - 1) + " z: " + (z + n - 1) + "N:" + g1.grid[x + n - 1, y + n - 1, z + n - 1]);
            }
        }

        for (int x = n - 1; x >= -n + 1; x--)
        {
            int counter1 = 0;
            int counter2 = 0;
            for (int z = (x >= 0 ? 1 - n : 1 - n - x); z <= (x >= 0 ? n - 1 - x : n - 1); z++)
            {
                int y = -x - z;
                if (z + 1 <= (x >= 0 ? n - 1 - x : n - 1) && grid[x + n - 1, y + n - 1, z + n - 1] == grid[x + n - 1, y + n - 2, z + n])
                {
                    if (grid[x + n - 1, y + n - 1, z + n - 1] == 1)
                    {
                        counter1++;
                    }
                    if (grid[x + n - 1, y + n - 1, z + n - 1] == -1)
                    {
                        counter2++;
                    }
                }
                else if (z + 1 <= (x >= 0 ? n - 1 - x : n - 1) && grid[x + n - 1, y + n - 1, z + n - 1] != grid[x + n - 1, y + n - 2, z + n])
                {
                    
                    if (counter2>= 4 - 1)
                    {
                        score=-n*100;
                        Debug.Log("WIN2");

                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            SceneManager.LoadScene("Lose");
                        }
                        else
                        {
                            SceneManager.LoadScene("Win");

                        }
                    }
                    else if (counter2 == 3 - 1)
                    {
                        score=n*100;
                        Debug.Log("Lose2");
                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            SceneManager.LoadScene("Win");
                        }
                        else
                        {
                            SceneManager.LoadScene("Lose");

                        }
                    }
                    else if (counter2 == 2-1){
                        score+=-10;
                    }
                    counter2 = 0;
                }
                else if (z == (x >= 0 ? n - 1 - x : n - 1))
                {
                    if (counter2>= 4 - 1)
                    {
                        score=-n*100;
                        Debug.Log("WIN2");
                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            SceneManager.LoadScene("Lose");
                        }
                        else
                        {
                            SceneManager.LoadScene("Win");

                        }
                    }
                    else if (counter2 == 3 - 1)
                    {
                        score=n*100;
                        Debug.Log("Lose2");
                        if (3 * n * n - 3 * n + 1 - Place.numberOfPiecesLeft % 2 == 1)
                        {
                            SceneManager.LoadScene("Win");
                        }
                        else
                        {
                            SceneManager.LoadScene("Lose");

                        }
                    }
                    else if (counter2 == 2-1){
                        score+=-10;
                    }
                    counter2 = 0;
                }
                
                //Debug.Log("counter1" + counter1);
                //Debug.Log("counter2" + counter2);
                //Debug.Log(" x: " + (x + n - 1) + "y: " + (y + n - 1) + " z: " + (z + n - 1) + "N:" + g1.grid[x + n - 1, y + n - 1, z + n - 1]);
            }
        }
        if (Place.numberOfPiecesLeft == 0)
        {
            SceneManager.LoadScene("Draw");
        }
        return score;
    }
 
    int minimax(int[, , ] grid, int depth, bool isMax, int n)
{
    int player = 1, opponent = -1;
    int score = evaluate(grid, n);
    // If Maximizer has won the game return his/her
    // evaluated score
    if (score == n * 100)
        return score;
    // If Minimizer has won the game return his/her
    // evaluated score
    if (score == -n * 100)
        return score;
    // If there are no more moves and no winner then
    // it is a tie
    if (!isMovesLeft(grid, n))
        return 0;

    if (isMax)
    {
        int best = -10000;
        for (int y = n - 1; y >= -n + 1; y--)
        {
            for (int z = (y >= 0 ? 1 - n : 1 - n - y); z <= (y >= 0 ? n - 1 - y : n - 1); z++)
            {
                int x = -y - z;
                if (grid[x + n - 1, y + n - 1, z + n - 1] == 0)
                {
                    // Make the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = player;

                    // Call minimax recursively and choose
                    // the maximum value
                    best = Math.Max(best, minimax(grid, depth + 1, !isMax, n));

                    // Undo the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = 0;
                }
            }
        }
        for (int z = n - 1; z >= -n + 1; z--)
        {
            for (int x = (z >= 0 ? 1 - n : 1 - n - z); x <= (z >= 0 ? n - 1 - z : n - 1); x++)
            {
                int y = -x - z;
                if (grid[x + n - 1, y + n - 1, z + n - 1] == 0)
                {
                    // Make the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = player;

                    // Call minimax recursively and choose
                    // the maximum value
                    best = Math.Max(best, minimax(grid, depth + 1, !isMax, n));

                    // Undo the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = 0;
                }
            }
        }
        for (int x = n - 1; x >= -n + 1; x--)
        {
            for (int z = (x >= 0 ? 1 - n : 1 - n - x); z <= (x >= 0 ? n - 1 - x : n - 1); z++)
            {
                int y = -x - z;
                if (grid[x + n - 1, y + n - 1, z + n - 1] == 0)
                {
                    // Make the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = player;

                    // Call minimax recursively and choose
                    // the maximum value
                    best = Math.Max(best, minimax(grid, depth + 1, !isMax, n));

                    // Undo the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = 0;
                }
            }
        }
        return best;
    }
    else
    {
        int best = 10000;

        // Traverse all cells

        for (int y = n - 1; y >= -n + 1; y--)
        {
            for (int z = (y >= 0 ? 1 - n : 1 - n - y); z <= (y >= 0 ? n - 1 - y : n - 1); z++)
            {
                int x = -y - z;
                // Check if cell is empty
                if (grid[x + n - 1, y + n - 1, z + n - 1] == 0)
                {
                    // Make the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = opponent;

                    // Call minimax recursively and choose
                    // the minimum value
                    best = Math.Min(best,minimax(grid, depth + 1, !isMax, n));

                    // Undo the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = 0;
                }
            }
        }
        for (int z = n - 1; z >= -n + 1; z--)
        {
            for (int x = (z >= 0 ? 1 - n : 1 - n - z); x <= (z >= 0 ? n - 1 - z : n - 1); x++)
            {
                int y = -x - z;
                // Check if cell is empty
                if (grid[x + n - 1, y + n - 1, z + n - 1] == 0)
                {
                    // Make the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = opponent;

                    // Call minimax recursively and choose
                    // the minimum value
                    best = Math.Min(best,minimax(grid, depth + 1, !isMax, n));

                    // Undo the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = 0;
                }
            }
        }
        for (int x = n - 1; x >= -n + 1; x--)
        {
            for (int z = (x >= 0 ? 1 - n : 1 - n - x); z <= (x >= 0 ? n - 1 - x : n - 1); z++)
            {
                int y = -x - z;
                // Check if cell is empty
                if (grid[x + n - 1, y + n - 1, z + n - 1] == 0)
                {
                    // Make the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = opponent;

                    // Call minimax recursively and choose
                    // the minimum value
                    best = Math.Min(best,minimax(grid, depth + 1, !isMax, n));

                    // Undo the move
                    grid[x + n - 1, y + n - 1, z + n - 1] = 0;
                }
            }
        }

        return best;
    }
}
int [] findBestMove(int [,,]grid, int n)
{
    int player =1, opponent=-1;
    int bestVal = -10000;
    // Move bestMove;
    int [] bestMove = new int [3];
    bestMove[0] = -1; bestMove[1] = -1; bestMove[2] = -1;
    // Traverse all cells, evaluate minimax function for
    // all empty cells. And return the cell with optimal
    // value.

    for (int y = n - 1; y >= -n + 1; y--)
    {
        for (int z = (y >= 0 ? 1 - n : 1 - n - y); z <= (y >= 0 ? n - 1 - y : n - 1); z++)
        {
            int x = -y - z;
            // Check if cell is empty
            if (grid[x+n-1, y+n-1, z+n-1] == 0)
            {
                // Make the move
                grid[x+n-1, y+n-1, z+n-1] = player;

                // compute evaluation function for this
                // move.
                int moveVal = minimax(grid, 0, false, n);

                // Undo the move
                grid[x+n-1, y+n-1, z+n-1] = 0;

                // If the value of the current move is
                // more than the best value, then update
                // best/
                if (moveVal > bestVal)
                {
                    bestMove[0] = x;
                    bestMove[1] = y;
                    bestMove[2] = z;
                    bestVal = moveVal;
                }
            }
        }
    }
    for (int z = n - 1; z >= -n + 1; z--)
    {
        for (int x = (z >= 0 ? 1 - n : 1 - n - z); x <= (z >= 0 ? n - 1 - z : n - 1); x++)
        {
            int y = -x - z;
            // Check if cell is empty
            if (grid[x+n-1, y+n-1, z+n-1] == 0)
            {
                // Make the move
                grid[x+n-1, y+n-1, z+n-1] = player;

                // compute evaluation function for this
                // move.
                int moveVal = minimax(grid, 0, false, n);

                // Undo the move
                grid[x+n-1, y+n-1, z+n-1] = 0;

                // If the value of the current move is
                // more than the best value, then update
                // best/
                if (moveVal > bestVal)
                {
                    bestMove[0] = x;
                    bestMove[1] = y;
                    bestMove[2] = z;
                    bestVal = moveVal;
                }
            }
        }
    }
    for (int x = n - 1; x >= -n + 1; x--)
    {
        for (int z = (x >= 0 ? 1 - n : 1 - n - x); z <= (x >= 0 ? n - 1 - x : n - 1); z++)
        {
            int y = -x - z;
             // Check if cell is empty
            if (grid[x+n-1, y+n-1, z+n-1] == 0)
            {
                // Make the move
                grid[x+n-1, y+n-1, z+n-1] = player;

                // compute evaluation function for this
                // move.
                int moveVal = minimax(grid, 0, false, n);

                // Undo the move
                grid[x+n-1, y+n-1, z+n-1] = 0;

                // If the value of the current move is
                // more than the best value, then update
                // best/
                if (moveVal > bestVal)
                {
                    bestMove[0] = x;
                    bestMove[1] = y;
                    bestMove[2] = z;
                    bestVal = moveVal;
                }
            }
        }
    }
    Debug.Log("bestmove" + bestMove[0] + bestMove[0] + bestMove[0]);
    return bestMove;
}

}
