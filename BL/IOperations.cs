using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BL
{
    //Contract with clauses in the form of methods / properties
    //It must be overridden in a class. Which means you agree to the contract clauses
    public interface IOperations
    {
        void Create();
        void Read();
        void Write();
        void Delete();
    }
    public interface IOperationsV2
    {
        void Merge();
    }

    public class FileOps : IOperations
    {
        public void Create()
        {
            Console.WriteLine("File Created");
        }

        public void Delete()
        {
            Console.WriteLine("File Deleted");
        }

        public void Read()
        {
            Console.WriteLine("File Read in progress...");
        }

        public void Write()
        {
            Console.WriteLine("Written and saved data to the file");
        }
    }

    

    public class DbObs : IOperations, IOperationsV2
    {
        public void Create()
        {
            Console.WriteLine("DB Created");
        }

        public void Delete()
        {
            Console.WriteLine("DB Deleted");
        }

        public void Merge()
        {
            Console.WriteLine("DB Merge completed");
        }

        public void Read()
        {
            Console.WriteLine("Data fetched into recordset");
        }

        public void Write()
        {
            Console.WriteLine("Data saved into DB");
        }
    }
}
