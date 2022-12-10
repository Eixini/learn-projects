﻿using System;
using System.ComponentModel;

namespace BeehiveManagementSystem;

internal class Queen : Bee, INotifyPropertyChanged
{
    public const float EGGS_PER_SHIFT = 0.45f;
    public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

    private IWorker[] workers = new IWorker[0];
    private float eggs = 0;
    private float unassignedWorkers = 3;

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public string StatusReport { get; private set; }

    public override float CostPerShift { get { return 2.15f; } }

    public Queen() : base("Queen")
    {
        AssignBee("Nectar Collector");
        AssignBee("Honey Manufacturer");
        AssignBee("Egg Care");
    }

    private void AddWorker(IWorker worker)
    {
        if (unassignedWorkers >= 1)
        {
            unassignedWorkers--;
            Array.Resize(ref workers, workers.Length + 1);
            workers[workers.Length - 1] = worker;
        }
    }

    private void UpdateStatusReport()
    {
        StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n" +
            $"\nEgg count:{eggs:0.0}\nUnassigned workers: {unassignedWorkers:0.0}\n" +
            $"\n{WorkerStatus("Nectar Collector")}\n" +
            $"{WorkerStatus("Honey manufacturer")}\n" +
            $"{WorkerStatus("Egg Care")}\n" +
            $"TOTAL WORKERS: {workers.Length}";
        OnPropertyChanged("StatusReport");
    }

    public void CareForEggs(float eggsToConvert)
    {
        if (eggs >= eggsToConvert)
        {
            eggs -= eggsToConvert;
            unassignedWorkers += eggsToConvert;
        }
    }

    private string WorkerStatus(string job)
    {
        int count = 0;
        foreach (IWorker worker in workers)
            if (worker.Job == job)
                count++;
        string s = "s";
        if (count == 1)
            s = "";
        return $"{count} {job} bee{s}";
    }

    public void AssignBee(string job)
    {
        switch (job)
        {
            case "Nectar Collector":
                AddWorker(new NectarCollector());
                break;
            case "Honey Manufacturer":
                AddWorker(new HoneyManufacturer());
                break;
            case "Egg Care":
                AddWorker(new EggCare(this));
                break;
        }
        UpdateStatusReport();
    }

    protected override void DoJob()
    {
        eggs += EGGS_PER_SHIFT;
        foreach (Bee worker in workers)
            worker.WorkTheNextShift();
        HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
        UpdateStatusReport();
    }
}
