﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HtmlAgilityPack;
using ScraperApplication.Models;

namespace ScraperApplication.ScrapingData
{
    public class dbCenter 
    {

        string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=ParsingOfData;Integrated Security=True;
                     Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InsertDataToTable(ParsingTable Stocks)
        {

            using (SqlConnection db = new SqlConnection(connectionString))
            {

                string insert = "INSERT INTO dbo.ParsingTable ( StockRecord, Symbol, Company, LastSale, Change, PChg, VolumeAvg ) VALUES (@stockRecord, @symbol, @company, @lastSale, @change, @pChg, @volumeAvg)";
                {
                    db.Open();
                    Console.WriteLine("Database has been opened");
                    Console.WriteLine();

                    using(SqlCommand dataToTable = new SqlCommand(insert, db))
                    {

                        dataToTable.Parameters.AddWithValue("@stockRecord", Stocks.StockRecord);
                        dataToTable.Parameters.AddWithValue("@symbol", Stocks.Symbol);
                        dataToTable.Parameters.AddWithValue("@company", Stocks.Company);
                        dataToTable.Parameters.AddWithValue("@lastSale", Stocks.LastSale);
                        dataToTable.Parameters.AddWithValue("@change", Stocks.Change);
                        dataToTable.Parameters.AddWithValue("@pChg", Stocks.PChg);
                        dataToTable.Parameters.AddWithValue("@volumeAvg", Stocks.VolumeAvg);

                        dataToTable.ExecuteNonQuery();

                    }

                    db.Close();
                    Console.WriteLine("Database has been inserted with data");

                } 

            }
        }

    }
}
