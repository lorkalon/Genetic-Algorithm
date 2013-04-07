using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace GeneticAlgoritm
{
    class BestAlgorithmFinder
    {
        int iterationCount = 20;

        public BestAlgorithmFinder()
        {

        }

        public BestAlgorithmFinder(int iterationCount)
        {
            this.iterationCount = iterationCount;
        }

        public List<AlgorithmStatistic> FindBestAlgorithm()
        {
            List<AlgorithmStatistic> algorithmsStatistics = new List<AlgorithmStatistic>();
            foreach (var grid in SubAlgorithmsManager.GridsDictionary)
            {
                foreach (var division in SubAlgorithmsManager.DivisionsDictionary)
                {
                    foreach (var selectionFromGeneration in SubAlgorithmsManager.SelectionFromGenerationDictionary)
                    {
                        foreach (var selectionFromGroups in SubAlgorithmsManager.SelectionFromGroupsDictionary)
                        {
                            GeneticAlgorithmCore geneticAlgoritm = CreateGeneticAlgorithm(grid, selectionFromGroups, division, selectionFromGeneration);
                            double bestResultAccumulator = 0;
                            for (int i = 0; i < iterationCount; i++)
                            {
                                geneticAlgoritm.ExecuteGeneticAlgorithm();
                                bestResultAccumulator += geneticAlgoritm.GetEntities().MaxBy(entity => entity.F1).F1;//change to Fg
                            }
                            double bestResult = bestResultAccumulator / iterationCount;
                            AlgorithmStatistic currentAlgorithmStatistic = new AlgorithmStatistic();
                            currentAlgorithmStatistic.Division = division.Key;
                            currentAlgorithmStatistic.Grid = grid.Key;
                            currentAlgorithmStatistic.SelectionFromGeneration = selectionFromGeneration.Key;
                            currentAlgorithmStatistic.SelectionFromGroups = selectionFromGroups.Key;
                            currentAlgorithmStatistic.FGeneralized = bestResult;
                            algorithmsStatistics.Add(currentAlgorithmStatistic);
                        }
                    }
                }
            }

            return algorithmsStatistics.OrderByDescending(e => e.FGeneralized).ToList();
        }

        private GeneticAlgorithmCore CreateGeneticAlgorithm(KeyValuePair<String, Type> grid, KeyValuePair<String, Type> selectionFromGroups, KeyValuePair<String, Type> division, KeyValuePair<String, Type> selectionFromGeneration)
        {
            SearchArea searchAreaSize = ConfigurationManager.GetAreaSize();
            int cycles = ConfigurationManager.GetCyclesCount();
            GeneticAlgorithmCore geneticAlgoritm = new GeneticAlgorithmCore(searchAreaSize, cycles);
            geneticAlgoritm.Hybridize = new Hybridizer(searchAreaSize, new int[] { 40, 62 });
            geneticAlgoritm.PerformMutation = new Mutation(searchAreaSize, 2);

            geneticAlgoritm.Grid = (IGrid)Activator.CreateInstance(grid.Value, searchAreaSize, 14);
            geneticAlgoritm.SelectionFromGroups = (ISelection)Activator.CreateInstance(selectionFromGroups.Value, 4);
            geneticAlgoritm.EntitiesDivision = (IDividable)Activator.CreateInstance(division.Value);
            geneticAlgoritm.SelectionFromGeneration = (ISelection)Activator.CreateInstance(selectionFromGeneration.Value, 10);

            geneticAlgoritm.SetLogOff();
            
            return geneticAlgoritm;
        }
    }
}
