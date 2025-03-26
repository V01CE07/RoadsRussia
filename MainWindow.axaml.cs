using Avalonia.Controls;
using calendar.Models;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace calendar
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            List<HighLevelDepartment> highLevels = new List<HighLevelDepartment>();
            HighLevelDepartment newItem = new HighLevelDepartment() { NameDepartmenthigh = "Высший уровень" };
            highLevels.Add(newItem);
            List<HighLevelDepartment> sortedList = Helper.Database.HighLevelDepartments.OrderBy(x => x.IdDepartmenthigh).ToList();
            highLevels.AddRange(sortedList);
            highComboBox.ItemsSource = highLevels;
            highComboBox.SelectedIndex = 0;
            loadWorkers();

        }

      

        public void LoadMediumLevel()
        {
            List<MediumLevelDepartment> mediumLevels = new List<MediumLevelDepartment>();
                        
            if (highComboBox.SelectedItem is HighLevelDepartment selectedHighLevel)
            {
                 List<MediumLevelDepartment> sortedList = Helper.Database.MediumLevelDepartments
                 .Where(x => x.ParentDepartmentmedium == selectedHighLevel.IdDepartmenthigh)
                 .OrderBy(x => x.IdDepartmentmedium)
                 .ToList();

                mediumLevels.AddRange(sortedList);              
            }
           
            mediumComboBox.ItemsSource = mediumLevels;
            mediumComboBox.SelectedIndex = 0;

            mediumComboBox.IsEnabled = true;
           
            LoadLowLevel();

        }

        public void LoadLowLevel()
        {
            List<LowLevelDepartment> lowLevels = new List<LowLevelDepartment>();

            if (mediumComboBox.SelectedItem is MediumLevelDepartment selectedMediumLevel)
            {
                List<LowLevelDepartment> sortedList = Helper.Database.LowLevelDepartments
                .Where(x => x.ParentDepartmentlow == selectedMediumLevel.IdDepartmentmedium)
                .OrderBy(x => x.IdDepartmentlow)
                .ToList();

                lowLevels.AddRange(sortedList);              
            }


            lowComboBox.ItemsSource = lowLevels;
            lowComboBox.SelectedIndex = 0;

            lowComboBox.IsEnabled = true;
            loadWorkers();

        }

        public void workerEdit(object sender, SelectionChangedEventArgs e)
        {
            if (workersList.SelectedItem != null)
            {
                dynamic selectedWorker = workersList.SelectedItem;
                int workerId = selectedWorker.IdWorker;

                Worker editWorker = Helper.Database.Workers.FirstOrDefault(x => x.IdWorker == workerId);

                if (editWorker != null)
                {
                    addWorker editWorkerWindow = new addWorker(editWorker);
                    editWorkerWindow.Show();
                    Close();
                }
            }
            
        }

        public void loadWorkers()
        {
            List<Worker> workers = new List<Worker>();

            HighLevelDepartment selectHigh = highComboBox.SelectedItem as HighLevelDepartment;
            MediumLevelDepartment selectMed = mediumComboBox.SelectedItem as MediumLevelDepartment;
            LowLevelDepartment selectLow = lowComboBox.SelectedItem as LowLevelDepartment;

            if (selectHigh != null)
            {
                int highDepartmentId = selectHigh.IdDepartmenthigh;

                if (selectMed  != null)
                {
                    int medDepartmentId = selectMed.IdDepartmentmedium;

                    if (selectLow != null)
                    {
                        int lowDepartmentId = selectLow.IdDepartmentlow;

                        workers = Helper.Database.Workers
                            .Include(x => x.JobPositionWorkerNavigation)
                            .Include(x => x.CabinetWorkerNavigation)
                            .Where(x => x.HighDepartmentWorker == highDepartmentId &&
                                        x.MediumDepartmentWorker == medDepartmentId &&
                                        x.LowDepartmentWorker == lowDepartmentId)
                            .OrderBy(x => x.IdWorker)
                            .ToList();
                    }
                    else
                    {
                        workers = Helper.Database.Workers
                           .Include(x => x.JobPositionWorkerNavigation)
                           .Include(x => x.CabinetWorkerNavigation)
                           .Where(x => x.HighDepartmentWorker == highDepartmentId &&
                                       x.MediumDepartmentWorker == medDepartmentId)                                 
                           .OrderBy(x => x.IdWorker)
                           .ToList();
                    }
                }
                else
                {
                    workers = Helper.Database.Workers
                           .Include(x => x.JobPositionWorkerNavigation)
                           .Include(x => x.CabinetWorkerNavigation)
                           .Where(x => x.HighDepartmentWorker == highDepartmentId)
                           .OrderBy(x => x.IdWorker)
                           .ToList();
                }
            }
            else
            {
                workers = Helper.Database.Workers
                           .Include(x => x.JobPositionWorkerNavigation)
                           .Include(x => x.CabinetWorkerNavigation)
                           .OrderBy(x => x.IdWorker)
                           .ToList();
            }


            workersList.ItemsSource = workers.Select(x => new 
            {
                x.IdWorker,
                highLevel = x.HighDepartmentWorkerNavigation.NameDepartmenthigh,
                mediumLevel = (x.MediumDepartmentWorkerNavigation != null) ? " - " + x.MediumDepartmentWorkerNavigation.NameDepartmentmedium : "",
                name = x.NameWorker,
                phoneEmail = x.PhonenumberWorker + " " + x.EmailWorker,
                cabinet = (x.CabinetWorkerNavigation != null) ? x.CabinetWorkerNavigation.NumberCabinet : "Кабинет не указан",
                position = (x.JobPositionWorkerNavigation != null) ? x.JobPositionWorkerNavigation.Jobname : "Должность не указана",
                color = (x.IsfiredWorker == true) ? "DarkGray" : "#a1d99b"
            });





        }
        public void newsButton(object? sender, RoutedEventArgs e)
        {
            News news = new News();
            news.Show();
            Close();

        }

        public void addWorkers(object sender, RoutedEventArgs e)
        {
            addWorker addWorker = new addWorker();
            addWorker.Show();
            Close();
        }

        public void highLevelSelect(object? sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            LoadMediumLevel();
        }
        public void mediumLevelSelect(object? sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            LoadLowLevel();
        }
        public void lowLevelSelect(object? sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            loadWorkers();
        }

    }
}