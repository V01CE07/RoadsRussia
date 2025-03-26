
using Avalonia.Controls;
using Avalonia.Interactivity;
using calendar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace calendar;

public partial class addWorker : Window
{
    public Worker _worker;
    public bool newWorker;

    public List<HighLevelDepartment> highLevel;
    public List<MediumLevelDepartment> mediumLevel;
    public List<LowLevelDepartment> lowLevel;

   
    public List<JobList> jobList;
    public List<CabinetList> cabinetList;

    public addWorker()
    {
        InitializeComponent();
        DataContext = this;

        _worker = new Worker();
        newWorker = true;

        LoadHighLevels();
        LoadMediumLevels();
        LoadLowLevels();
        LoadJobPositions();
        LoadCabinets();


    }
    public addWorker(Worker worker)
    {
        InitializeComponent();
        DataContext = this;

        _worker = worker;
        newWorker = false;

        LoadHighLevels();
        LoadMediumLevels();
        LoadLowLevels();
        LoadJobPositions();
        LoadCabinets();

        textBoxName.Text = _worker.NameWorker;
        textBoxEmail.Text = _worker.EmailWorker;
        textBoxPhone.Text = _worker.PhonenumberWorker;

        position.SelectedItem = _worker.JobPositionWorkerNavigation;
        cabinet.SelectedItem = _worker.CabinetWorkerNavigation;

        isFiredCheck.IsChecked = _worker.IsfiredWorker;

        highDepartmentChoice.SelectedItem = highLevel.FirstOrDefault(x => x.IdDepartmenthigh == _worker.HighDepartmentWorker);

        if (highDepartmentChoice.SelectedItem is HighLevelDepartment selectedHighLevels)
        {
            LoadMediumLevels();
            mediumDepartmentChoice.SelectedItem = mediumLevel.FirstOrDefault(x => x.IdDepartmentmedium == _worker.MediumDepartmentWorker);

            if (mediumDepartmentChoice.SelectedItem is MediumLevelDepartment selectedMediumLevels)
            {
                LoadLowLevels();
                lowDepartmentChoice.SelectedItem = lowLevel.FirstOrDefault(x => x.IdDepartmentlow == _worker.LowDepartmentWorker);
            }


        }
    }

    public void LoadHighLevels()
    {
        highLevel = Helper.Database.HighLevelDepartments
            .OrderBy(x => x.IdDepartmenthigh).ToList();
        highDepartmentChoice.ItemsSource = highLevel;
    }

    public void LoadMediumLevels()
    {
        if (highDepartmentChoice.SelectedItem is HighLevelDepartment selectedHighLevel)
        {
            mediumLevel = Helper.Database.MediumLevelDepartments
                .Where(x => x.ParentDepartmentmedium == selectedHighLevel.IdDepartmenthigh)
                .OrderBy(x => x.IdDepartmentmedium)
                .ToList();
            mediumDepartmentChoice.ItemsSource = mediumLevel;
        }
    }

    public void LoadLowLevels()
    {
        if (mediumDepartmentChoice.SelectedItem is MediumLevelDepartment selectedMediumLevel)
        {
            lowLevel = Helper.Database.LowLevelDepartments
                .Where(x => x.ParentDepartmentlow == selectedMediumLevel.IdDepartmentmedium)
                .OrderBy(x => x.IdDepartmentlow)
                .ToList();
            lowDepartmentChoice.ItemsSource = lowLevel;
        }
    }

    public void LoadJobPositions()
    {
        jobList = Helper.Database.JobLists
                .OrderBy(x => x.Id)
                .ToList();
        
        position.ItemsSource = jobList;
    }

    public void LoadCabinets()
    {
        cabinetList = Helper.Database.CabinetLists
            .OrderBy(x => x.IdCabinet)
            .ToList();
        cabinet.ItemsSource = cabinetList;
    }

    public void HighLevelChoiceSelect(object sender, SelectionChangedEventArgs e)
    {
        LoadMediumLevels();
        LoadLowLevels();
    }

    public void saveButton(object? sender, RoutedEventArgs e)
    {
       
        string name = textBoxName.Text;
        string phone = textBoxPhone.Text;
        string email = textBoxEmail.Text;

        HighLevelDepartment selectedHighLevel = highDepartmentChoice.SelectedItem as HighLevelDepartment;
        MediumLevelDepartment selectedMediumLevel = mediumDepartmentChoice.SelectedItem as MediumLevelDepartment;
        LowLevelDepartment selectedLowLevel = lowDepartmentChoice.SelectedItem as LowLevelDepartment;
        JobList selectedJobList = position.SelectedItem as JobList;
        CabinetList selectedCabinetList = cabinet.SelectedItem as CabinetList;

        bool isFired;
        if (isFiredCheck.IsChecked == null)
        {
            isFired = false;
        }
        else
        {
            isFired = isFiredCheck.IsChecked.Value;
        }

        if (newWorker)
        {
            _worker = new Worker();
            _worker.IsfiredWorker = isFired;
            _worker.NameWorker = name;
            _worker.PhonenumberWorker = phone;
            _worker.EmailWorker = email;

            if (selectedHighLevel != null) _worker.HighDepartmentWorker = selectedHighLevel.IdDepartmenthigh;
            if (selectedMediumLevel != null) _worker.MediumDepartmentWorker = selectedMediumLevel.IdDepartmentmedium;
            if (selectedLowLevel != null) _worker.LowDepartmentWorker = selectedLowLevel.IdDepartmentlow;
            if (selectedJobList != null) _worker.JobPositionWorker = selectedJobList.Id;
            if (selectedCabinetList != null) _worker.CabinetWorker = selectedCabinetList.IdCabinet;

            Helper.Database.Workers.Add(_worker);
        }
        else
        {

            Worker existingWorker = Helper.Database.Workers.FirstOrDefault(x => x.IdWorker == _worker.IdWorker);

            if (existingWorker != null)
            {

                existingWorker.NameWorker = name;
                existingWorker.PhonenumberWorker = phone;
                existingWorker.EmailWorker = email;
                existingWorker.IsfiredWorker = isFired;

                if (selectedHighLevel != null) existingWorker.HighDepartmentWorker = selectedHighLevel.IdDepartmenthigh;
                if (selectedMediumLevel != null) existingWorker.MediumDepartmentWorker = selectedMediumLevel.IdDepartmentmedium;
                if (selectedLowLevel != null) existingWorker.LowDepartmentWorker = selectedLowLevel.IdDepartmentlow;
                if (selectedJobList != null) existingWorker.JobPositionWorker = selectedJobList.Id;
                if (selectedCabinetList != null) existingWorker.CabinetWorker = selectedCabinetList.IdCabinet;


            }
            else
            {

                errorText.Text = "Ошибка";
                return;
            }
        }

        Helper.Database.SaveChanges();
        MainWindow main = new MainWindow();
        main.Show();
        Close();
    }

    public void deleteButton(object? sender, RoutedEventArgs e) 
    { 
        if (!newWorker)
        {
            MainWindow main = new MainWindow();
            Helper.Database.Workers.Remove(_worker);
            Helper.Database.SaveChanges();
            
            main.Show();
            Close();
            
        }    
    }

    public void cancelButton(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();  
        mainWindow.Show();
        Close();
    }
}
