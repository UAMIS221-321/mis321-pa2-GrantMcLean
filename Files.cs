using System.IO;
using System.Collections.Generic;
namespace mis321_pa2_GrantMcLean
{
    public class Files
    {
        static public void SaveToFile(string winner, List<string> winnerList)   // Saves to file
        {
            winnerList.Add(winner);

            StreamWriter outFile = new StreamWriter("results.txt"); // Open file
            
            foreach(string item in winnerList)  // process file
            {
                outFile.WriteLine(item);
            }
            
            outFile.Close();    // close file
        }
        static public List<string> ReturnList() // Populates winnerList
        {
            List<string> tempList = new List<string>{};

            StreamReader inFile = new StreamReader("results.txt");  // open file
            string line = inFile.ReadLine();

            while(line != null) // process file
            {
                tempList.Add(line);
                line = inFile.ReadLine();
            }
            
            inFile.Close(); // close file

            return tempList;
        }
        static public int NumOfWins(string winner)  // Calculates wins by winners name
        {   
            int count = 0;
            StreamReader inFile = new StreamReader("results.txt");  // open file
            string line = inFile.ReadLine();

            while(line != null) // process file
            {
                if(line.Contains(winner))
                {
                   count++; 
                }
                line = inFile.ReadLine();
            }
            inFile.Close(); // close file
            return count;
        }
    }
}