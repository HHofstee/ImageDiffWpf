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
        private string left_image_name;
        private string right_image_name;
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
            LeftImageName = image_name;
            RightImageName = ref_image_name;
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
                    LeftImageName = image_name;
                RaisePropertyChanged("ImageName");
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
                    RightImageName = adobe_image_name;
                RaisePropertyChanged("AdobeImageName");
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
                    RightImageName = diff_image_name;
                RaisePropertyChanged("DiffImageName");
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
                    LeftImageName = ref_image_name;
                if (RightToggleButtonName == "Reference")
                    RightImageName = ref_image_name;
                RaisePropertyChanged("RefImageName");
            }
        }

        public string LeftImageName
        {
            get
            {
                return left_image_name;
            }
            set
            {
                left_image_name = value;
                RaisePropertyChanged("LeftImageName");
            }
        }

        public string RightImageName
        {
            get
            {
                return right_image_name;
            }
            set
            {
                right_image_name = value;
                RaisePropertyChanged("RightImageName");
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
            string image_name = "";

            switch (button_names[i])
            {
                case "Image":
                    image_name = imagediff.ImageName;
                    break;
                case "Adobe":
                    image_name = imagediff.AdobeImageName;
                    break;
                case "Diff":
                    image_name = imagediff.DiffImageName;
                    break;
                case "Reference":
                    image_name = imagediff.RefImageName;
                    break;
            }

            if (left_or_right == "Left")
            {
                imagediff.LeftToggleButtonName = button_names[i];
                imagediff.LeftImageName = image_name;
            }
            else
            {
                imagediff.RightToggleButtonName = button_names[i];
                imagediff.RightImageName = image_name;
            }
        }
    }
}
