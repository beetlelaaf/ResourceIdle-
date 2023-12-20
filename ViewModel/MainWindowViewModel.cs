﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ResourceIdlePersonal.Model;

namespace ResourceIdlePersonal.ViewModel
{
    public partial class MainWindowViewModel : INotifyPropertyChanged
    { 
        public Dictionary<string, Resource> Resources { get; set; }
        public Dictionary<string, Machine> Machines { get; set; }

        public MainWindowViewModel()
        {
            InitializeResources();
            InitializeMachines();
            InitializeCommands();
        }

        public ICommand IncrementWoodByOneCommand { get; private set; }
        public ICommand IncrementStoneByOneCommand { get; private set; }

        public void InitializeCommands()
        {
            IncrementWoodByOneCommand = new RelayCommand(() => IncrementResource(Resources["Wood"], 1));
            IncrementStoneByOneCommand = new RelayCommand(() => IncrementResource(Resources["Stone"], 1));
        }

        public void InitializeResources()
        {
            Resources = new Dictionary<string, Resource>
            {
                { "Wood", new Resource { Name = "Wood", Quantity = 0 } },
                { "Stone", new Resource { Name = "Stone", Quantity = 0 } }
            };
        }

        public void InitializeMachines()
        {
            Machines = new Dictionary<string, Machine>
            {
                { 
                    "WoodCutter", new Machine 
                    { 
                        Name = "WoodCutter", 
                        ProductionRate = 2,
                        Cost = {{ "Wood", 20 }, { "Stone", 10 }}
                    }
                },
                {
                    "StoneMine", new Machine
                    {
                        Name = "StoneMine",
                        ProductionRate = 1,
                        Cost = {{ "Wood", 40 }, { "Stone", 40 }}
                    }
                },
            };
        }

        public Machine WoodCutterMachine => Machines["WoodCutter"];
        public Machine StoneMineMachine => Machines["StoneMine"];
        public Resource WoodResource => Resources["Wood"];
        public Resource StoneResource => Resources["Stone"];


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
