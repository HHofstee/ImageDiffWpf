using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight;
using System.Windows.Input;

namespace Imagediff
{
    public class ImagediffViewModel : ViewModelBase
    {
        private string image_name;
        private string adobe_image_name;
        private string diff_image_name;
        private string ref_image_name;
        private string left_toggle_button_name;
        private string right_toggle_button_name;

        //protected void OnPropertyChanged(string propName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        //}

        public ImagediffViewModel() : this( "Image Name", "Adobe Image Name", "Diff Image Name", "Ref Image Name") { }
        public ImagediffViewModel(string image_name, string adobe_image_name, string diff_image_name, string ref_image_name)
        {
            ImageName = image_name;
            AdobeImageName = adobe_image_name;
            DiffImageName = diff_image_name;
            RefImageName = ref_image_name;
            LeftToggleButtonName = "Image";
            RightToggleButtonName = "Reference";
        }

        public string ImageName
        {
            get
            {
                return image_name;
            }
            set
            {
                image_name = value;
                if (LeftToggleButtonName == "Image")
                    RaisePropertyChanged("LeftImageName");
            }
        }

        public string AdobeImageName
        {
            get
            {
                return adobe_image_name;
            }
            set
            {
                adobe_image_name = value;
                if (RightToggleButtonName == "Adobe")
                    RaisePropertyChanged("RightImageName");
            }
        }

        public string DiffImageName
        {
            get
            {
                return diff_image_name;
            }
            set
            {
                diff_image_name = value;
                if (RightToggleButtonName == "Diff")
                    RaisePropertyChanged("RightImageName");
            }
        }

        public string RefImageName
        {
            get
            {
                return ref_image_name;
            }
            set
            {
                ref_image_name = value;
                if (LeftToggleButtonName == "Reference")
                    RaisePropertyChanged("LeftImageName");
                if (RightToggleButtonName == "Reference")
                    RaisePropertyChanged("RightImageName");
            }
        }

        public string LeftImageName
        {
            get
            {
                return ConvertButtonNameToImageName(LeftToggleButtonName);
            }
        }

        public string RightImageName
        {
            get
            {
                return ConvertButtonNameToImageName(RightToggleButtonName);
            }
        }

        public string LeftToggleButtonName
        {
            get
            {

                return left_toggle_button_name;
            }
            set
            {
                left_toggle_button_name = value;
                RaisePropertyChanged("LeftToggleButtonName");
                RaisePropertyChanged("LeftImageName");
            }
        }

        public string RightToggleButtonName
        {
            get
            {
                return right_toggle_button_name;
            }
            set
            {
                right_toggle_button_name = value;
                RaisePropertyChanged("RightToggleButtonName");
                RaisePropertyChanged("RightImageName");
            }
        }

        public ICommand ToggleLeft
        {
            get
            {
                return new ToggleCommand(this, "Left", new string[] { "Image", "Reference" });
            }
        }

        public ICommand ToggleRight
        {
            get
            {
                return new ToggleCommand(this, "Right", new string[] {"Reference", "Diff", "Adobe"});
            }
        }

        private string ConvertButtonNameToImageName(string button_name)
        {
            switch (button_name)
            {
                default:
                case "Image":
                    return ImageName;
                case "Adobe":
                    return AdobeImageName;
                case "Diff":
                    return DiffImageName;
                case "Reference":
                    return RefImageName;
            }
        }
    }

    public class ToggleCommand : ICommand
    {
        ImagediffViewModel imagediff;
        string left_or_right;
        string[] button_names;

        public ToggleCommand(ImagediffViewModel imagediff, string left_or_right, string[] button_names)
        {
            this.imagediff = imagediff;
            this.left_or_right = left_or_right;
            this.button_names = button_names;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string current_button_name = left_or_right == "Left" ? imagediff.LeftToggleButtonName : imagediff.RightToggleButtonName;
            int i = (Array.IndexOf(button_names, current_button_name) + 1) % button_names.Length;

            if (left_or_right == "Left")
                imagediff.LeftToggleButtonName = button_names[i];
            else
                imagediff.RightToggleButtonName = button_names[i];
        }
    }
}
