using Puzzle2D.VirtualBoard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle2D.MultiThread
{
    public class MultiThreads
    {
        public int NumberOfStaticBricks;
        public int NumberOfThreads;
        public string LatestStaticBoard;
        public Task Observer;

        string OutputFolder;
        PanelColor[,] Table;

        public float CalculateProgres {
            get 
            {
                float results = 0;
                if (LatestStaticBoard.Length < 4) return 100;
                if (LatestStaticBoard.Length >= 4) 
                {
                    if (LatestStaticBoard.Substring(0, 1) == "B") results += 50;
                    results += Int32.Parse(LatestStaticBoard.Substring(1, 1)) * 12.5f;
                    results += Int32.Parse(LatestStaticBoard.Substring(2, 1)) * (12.5f/8);
                    results += Int32.Parse(LatestStaticBoard.Substring(2, 1)) * ((12.5f/8)/8);
                }
                return results;
            }}

        public MultiThreads(PanelColor[,] table, int numberOfThreads, int numberOfStaticBricks, string outputFolder)
        {
            NumberOfStaticBricks = numberOfStaticBricks;
            NumberOfThreads = numberOfThreads;
            Table = table;
            LatestStaticBoard = GetFirstStaticBoardState();
            OutputFolder = outputFolder;
        }

        public string GetFirstStaticBoardState()
        {
            return new String('.', NumberOfStaticBricks).Replace(".", "A000");
        }

        public string GetNextStaticBoardStatus()
        {
            if (LatestStaticBoard.Length == 0) return "";
            AddOneToStatus();
            Board board = new Board(LatestStaticBoard, Table, OutputFolder);
            LatestStaticBoard = board.AddBrickRecursionState("0");
            return LatestStaticBoard;
        }

        public void AddOneToStatus()
        {
            char last = LatestStaticBoard.Last();
            int newLast = Int32.Parse(last.ToString()) + 1;
            LatestStaticBoard = LatestStaticBoard.Substring(0, LatestStaticBoard.Length - 1) + newLast.ToString();
        }

        public void StartObserver()
        {

            Log("Begin" + "\r\n");

            Action<object> action = (object obj) =>
            {
                List<Board> Boards = new List<Board>();
                Log("List<Board> Boards = new List<Board>();" + "\r\n");

                while (true)
                {
                    Log("while (true)" + "\r\n");
                    try
                    {
                        if (Boards.Count < NumberOfThreads)
                        {
                            var StaticBoardStatus = GetNextStaticBoardStatus();
                            if(StaticBoardStatus != "")
                            {
                                Board board = new Board(StaticBoardStatus, Table, OutputFolder);
                                board.Start();
                                Boards.Add(board);
                            }
                        }
                        Thread.Sleep(3000);
                        if (Boards.Count == 0)
                        {
                            PickUniqueResults();
                            break;
                        }
                        Log("---------------------------------------------" + "\r\n");
                        foreach (var Board in Boards) Log(Board.BoardTask.Status + " " + Board.History + "\r\n");

                        List<Board> boardsToRemove = Boards.Where(x => x.BoardTask.Status == TaskStatus.RanToCompletion).ToList();
                        foreach (var board in boardsToRemove)
                        {
                            Boards.Remove(board);
                        }
                    }
                    catch (Exception error)
                    {
                        Log(error.Message);
                    }
                }
                Log("END" + "\r\n");
                MessageBox.Show("END");
            };
            Observer = new Task(action, "Observer");
            Observer.Start();
        }

        public void PickUniqueResults()
        {
            string catalogUnique = OutputFolder + @"\Unique";
            Directory.CreateDirectory(catalogUnique);

            List<string> files = Directory.GetFiles(OutputFolder, "*html").ToList();

            for (int i = 0; i < files.Count; i++)
            {
                Console.WriteLine(i.ToString() + ";" + files.Count);
                string fileToCompare = files[i];
                string flesh = File.ReadAllText(fileToCompare);
                for (int j = 0; j < files.Count; j++)
                {
                    string temp = files[j];
                    if (flesh == File.ReadAllText(temp))
                    {
                        if (fileToCompare != temp)
                        {
                            files.Remove(temp);
                            j--;
                        }
                    }
                }
                string to = catalogUnique + @"\" + Path.GetFileName(fileToCompare);
                File.Copy(fileToCompare, to, true);
            }
            File.Copy(@"VirtualBoard\Board\style.css", catalogUnique + @"\style.css", true);
            File.Copy(@"VirtualBoard\Board\style.css", OutputFolder + @"\style.css", true);
        }

        public void Log (String text)
        {
            File.AppendAllText(OutputFolder + @"/log.txt", text);        
        }
    }
}
