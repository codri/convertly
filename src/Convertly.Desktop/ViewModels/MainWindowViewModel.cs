using Convertly.Core.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Convertly.Desktop.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly UnitConverterService unitConverterService;

        private ObservableCollection<string> measurementTypes;

        private ObservableCollection<string> measurementUnitTypes;

        private string selectedMeasurementType;

        private string selectedSourceUnitType;

        private string selectedTargetUnitType;


        private double selectedSourceValue;

        private double computedTargetValue;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainWindowViewModel()
        {
            this.unitConverterService = new UnitConverterService();
        }

        private void CalculateConvertedValue()
        {
            // calculate the converted value
            this.ComputedTargetValue =
                this.unitConverterService.Convert(this.selectedSourceValue,
                    this.selectedSourceUnitType,
                    this.selectedTargetUnitType,
                    this.selectedMeasurementType);
        }

        public string ChangeSelectedSourceType
        {
            set
            {
                this.selectedSourceUnitType = value;

                this.CalculateConvertedValue();
            }
        }

        public string ChangeSelectedTargetType
        {
            set
            {
                this.selectedTargetUnitType = value;

                this.CalculateConvertedValue();
            }
        }


        public double SelectedSourceValue
        {
            get
            {
                return this.selectedSourceValue;
            }

            set
            {
                this.selectedSourceValue = value;

                this.CalculateConvertedValue();
                this.OnPropertyChanged("Source");
            }
        }

        public double ComputedTargetValue
        {
            get
            {
                return this.computedTargetValue;
            }

            set
            {
                this.computedTargetValue = value;

                this.OnPropertyChanged("ComputedTargetValue");
            }
        }

        public string ChangeSelectedMeasurementType
        {
            set
            {
                this.selectedMeasurementType = value;
                var types = this.unitConverterService.MeasurementUnitTypes(this.selectedMeasurementType);

                this.measurementUnitTypes?.Clear();
                foreach(var measurementType in types)
                {
                    this.measurementUnitTypes?.Add(measurementType);
                }
            }
        }

        public ObservableCollection<string> MeasurementUnitTypes
        {
            get
            {
                if (this.measurementUnitTypes is null)
                {
                    this.measurementUnitTypes = new ObservableCollection<string>(
                        this.unitConverterService.MeasurementUnitTypes(this.selectedMeasurementType));
                }

                return this.measurementUnitTypes;
            }
        }

        public ObservableCollection<string> MeasurementTypes
        {
            get
            {
                if (this.measurementTypes is null)
                {
                    this.measurementTypes = new ObservableCollection<string>(
                        this.unitConverterService.MeasurementTypes);

                    this.selectedMeasurementType = this.measurementTypes.First();
                }

                return this.measurementTypes;
            }
        }
    }
}
