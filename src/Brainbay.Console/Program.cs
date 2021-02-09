using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Http; 
using System.Threading.Tasks;
using System.Text.Json;
using Brainbay.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Brainbay.Business;
using Brainbay.Repository;
using Brainbay.Common.Entities;
using System.IO;
using System.Threading;

namespace Brainbay.App
{
    public class Program
    {
        private static bool dataLoaded;
        private static bool databaseCleared;
        private static bool databaseUpdated;
        static async Task Main(string[] args)
        {
           
            #region Variables Declaration 
            IDataLoader<CharacterDto> characterLoader = new CharacterLoader();
            characterLoader.BeforeDataLoad += CharacterLoader_BeforeDataLoad;
            characterLoader.AfterDataLoad += CharacterLoader_AfterDataLoad;
            CharacterDbContext context = new CharacterDbContext();
            DatabaseManager databaseManager = new DatabaseManager(
                new EpisodeBusiness(new EpisodeRepository(context)),
                new CharacterBusiness(new CharacterRepository(context)),
                new CharacterTypeBusiness(new CharacterTypeRepository(context)),
                new StatusBusiness(new StatusRepository(context)),
                new OriginBusiness(new OriginRepository(context)),
                new LocationBusiness(new LocationRepository(context)),
                new GenderBusiness(new GenderRepository(context)),
                new SpeciesBusiness(new SpeciesRepository(context))
            );

            databaseManager.DatabaseClearing += DatabaseManager_DatabaseClearing;
            databaseManager.DatabaseCleared += DatabaseManager_DatabaseCleared;
            databaseManager.DatabaseUpdating += DatabaseManager_DatabaseUpdating;
            databaseManager.DatabaseUpdated += DatabaseManager_DatabaseUpdated;

            #endregion

            Console.ForegroundColor = ConsoleColor.Green; 
            do
            {
                dataLoaded = false;
                databaseCleared = false;
                databaseUpdated = false;
                try
                {
                    Console.Clear();
                    showMenu();

                    Console.Write(Constants.PressAnyKey);
                    Console.ReadKey();
                    ClearCurrentConsoleLine();

                    var result = await characterLoader.LoadDataAsync("https://rickandmortyapi.com/api/");
                    Console.WriteLine(Constants.RecordCount, result.Where(i => i.status.ToLower() == "alive").Count());

                    await databaseManager.ClearDatabaseAsync();
                    await databaseManager.UpdateDatabaseAsync(result.Where(i => i.status.ToLower() == "alive"));
                 
                }
                catch(Exception exp)
                {
                    var prevColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine(exp.Message);
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(Constants.PressEnter);
            }
            while (Console.ReadKey().Key == ConsoleKey.Enter);
            
        }

        private static void DatabaseManager_DatabaseUpdated(object sender, EventArgs e)
        {
            databaseUpdated = true;
            ClearCurrentConsoleLine();
            Console.WriteLine(Constants.UpdatingDatabaseFinished);
        }

        private static void DatabaseManager_DatabaseUpdating(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine(Constants.UpdatingDatabaseStarted);
                var progress = "#> ";
                while (!databaseUpdated)
                {

                    if (progress.Length == 25)
                    {
                        progress = "#> ";
                    }
                    ClearCurrentConsoleLine();
                    Console.Write(progress);
                    progress += "*";
                    Thread.Sleep(150);
                }
            });
        }

        private static void DatabaseManager_DatabaseCleared(object sender, EventArgs e)
        {
            databaseCleared = true;
            ClearCurrentConsoleLine();
            Console.WriteLine(Constants.ClearingDatabaseFinished);
        }

        private static void DatabaseManager_DatabaseClearing(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine(Constants.ClearingDatabaseStarted);
                var progress = "#> ";
                while (!databaseCleared)
                {

                    if (progress.Length == 25)
                    {
                        progress = "#> ";
                    }
                    ClearCurrentConsoleLine();
                    Console.Write(progress);
                    progress += '*';
                    Thread.Sleep(150);
                }
            });
        }

        private static void CharacterLoader_AfterDataLoad(object sender, EventArgs e)
        {
            dataLoaded = true;
            ClearCurrentConsoleLine();
            Console.WriteLine(Constants.ResponseReceived);
        }

        private static void CharacterLoader_BeforeDataLoad(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine(Constants.RequestSent);
                var progress = "#> ";
                while (!dataLoaded)
                {

                    if (progress.Length == 25)
                    {
                        progress = "#> ";
                    }
                    ClearCurrentConsoleLine();
                    Console.Write(progress);
                    progress += '*';
                    Thread.Sleep(150);
                }
            });
        }


        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        static void showMenu()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* [Enter]: Retry   ");
            Console.WriteLine("* [Other]: Exit   ");
            Console.WriteLine("*****************************************");
        }
        
    }
}
