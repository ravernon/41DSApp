using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Input;
using Xamarin.Forms;

namespace App41DS.ViewModels
{
    class FormPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public class PlanningItemModel
        {
            public int WebsiteFunctionalityMask { get; set; }

            public int ResponsiveDevicesMask { get; set; }

            public string AdditionalServicesRequired { get; set; }

            public string ClientName { get; set; }

            public string ContactNumber { get; set; }

            public string ContactName { get; set; }

            public string ContactEmail { get; set; }

            public string DomainName { get; set; }

            public string OtherFunctionality { get; set; }

            public string EmailHosting { get; set; }

            public string Examples { get; set; }

            public double NumberOfPages { get; set; }

            public double NumberOfPhotos { get; set; }

            public double NumberOfDlc { get; set; }

            public bool AlreadyExists { get; set; }

            public bool Office365 { get; set; }

            public bool HasDropbox { get; set; }

            public bool HasExistingBranding { get; set; }
        }

        private PlanningItemModel _planningItemViewModel;
        public PlanningItemModel PlanningItemViewModel
        {
            get
            {
                return _planningItemViewModel;
            }
            set
            {
                _planningItemViewModel = value;
                OnPropertyChanged("PlanningItemViewModel");
            }
        }

        private int _responsiveDevicesMask;

        private int _websiteFunctionalityMask;

        private bool _horizontalNavigation;
        public bool HorizontalNavigation
        {
            get
            {
                return _horizontalNavigation;
            }
            set
            {
                _horizontalNavigation = value;
                OnPropertyChanged("HorizontalNavigation");
            }
        }

        private bool _verticalNavigation;
        public bool VerticalNavigation
        {
            get
            {
                return _verticalNavigation;
            }
            set
            {
                _verticalNavigation = value;
                OnPropertyChanged("VerticalNavigation");
            }
        }

        private bool _photoGallery;
        public bool PhotoGallery
        {
            get
            {
                return _photoGallery;
            }
            set
            {
                _photoGallery = value;
                OnPropertyChanged("PhotoGallery");
            }
        }

        private bool _videoGallery;
        public bool VideoGallery
        {
            get
            {
                return _videoGallery;
            }
            set
            {
                _videoGallery = value;
                OnPropertyChanged("VideoGallery");
            }
        }

        private bool _eNewsletter;
        public bool ENewsletter
        {
            get
            {
                return _eNewsletter;
            }
            set
            {
                _eNewsletter = value;
                OnPropertyChanged("ENewsletter");
            }
        }

        private bool _blog;
        public bool Blog
        {
            get
            {
                return _blog;
            }
            set
            {
                _blog = value;
                OnPropertyChanged("Blog");
            }
        }

        private bool _contactForm;
        public bool ContactForm
        {
            get
            {
                return _contactForm;
            }
            set
            {
                _contactForm = value;
                OnPropertyChanged("ContactForm");
            }
        }

        private bool _contentManagementSystem;
        public bool ContentManagementSystem
        {
            get
            {
                return _contentManagementSystem;
            }
            set
            {
                _contentManagementSystem = value;
                OnPropertyChanged("ContentManagementSystem");
            }
        }

        private bool _socialMediaSharing;
        public bool SocialMediaSharing
        {
            get
            {
                return _socialMediaSharing;
            }
            set
            {
                _socialMediaSharing = value;
                OnPropertyChanged("SocialMediaSharing");
            }
        }

        private bool _thirdPartyPlugins;
        public bool ThirdPartyPlugins
        {
            get
            {
                return _thirdPartyPlugins;
            }
            set
            {
                _thirdPartyPlugins = value;
                OnPropertyChanged("ThirdPartyPlugins");
            }
        }

        private bool _phone;
        public bool Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private bool _tablet;
        public bool Tablet
        {
            get
            {
                return _tablet;
            }
            set
            {
                _tablet = value;
                OnPropertyChanged("Tablet");
            }
        }

        private bool _desktop;
        public bool Desktop
        {
            get
            {
                return _desktop;
            }
            set
            {
                _desktop = value;
                OnPropertyChanged("Desktop");
            }
        }

        private bool _laptop;
        public bool Laptop
        {
            get
            {
                return _laptop;
            }
            set
            {
                _laptop = value;
                OnPropertyChanged("Laptop");
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        private bool _isGridBusy;
        public bool IsGridBusy
        {
            get
            {
                return _isGridBusy;
            }
            set
            {
                _isGridBusy = value;
                OnPropertyChanged("IsGridBusy");
            }
        }

        private string _msg;
        public string Message
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
                OnPropertyChanged("Message");
            }
        }   

        public ICommand SaveCommand { protected set; get; }

        public ICommand ClearCommand { protected set; get; }

        public FormPageViewModel()
        {
            PlanningItemViewModel = new PlanningItemModel();

            IsGridBusy = true;

            this.SaveCommand = new Command(() =>
            {

                Message = (string.IsNullOrEmpty(PlanningItemViewModel.ClientName) ? "Client name," : null) +
                          (string.IsNullOrEmpty(PlanningItemViewModel.ContactName) ? "Contact name," : null) +
                          (string.IsNullOrEmpty(PlanningItemViewModel.ContactNumber) ? "Contact number," : null) +
                          (string.IsNullOrEmpty(PlanningItemViewModel.ContactEmail) ? "Contact email," : null) +
                          (string.IsNullOrEmpty(PlanningItemViewModel.DomainName) ? "Domain name," : null) +
                          (string.IsNullOrEmpty(PlanningItemViewModel.Examples) ? "Examples," : null) +
                          (string.IsNullOrEmpty(PlanningItemViewModel.EmailHosting) ? "EmailHosting" : null);

                if (!string.IsNullOrEmpty(Message))
                {
                    Message = "fields with '*' are required";
                    return;
                }

                Save();
            });

            this.ClearCommand = new Command(() =>
            {

                Clear();
            });
        }

        private void Bitmask()
        {
            _websiteFunctionalityMask = Convert.ToInt16(HorizontalNavigation ? WebsiteFunctionality.HorizontalNavigation : WebsiteFunctionality.None) +
                                        Convert.ToInt16(VerticalNavigation ? WebsiteFunctionality.VerticalNavigation : WebsiteFunctionality.None) +
                                        Convert.ToInt16(PhotoGallery ? WebsiteFunctionality.PhotoGallery : WebsiteFunctionality.None) +
                                        Convert.ToInt16(VideoGallery ? WebsiteFunctionality.VideoGallery : WebsiteFunctionality.None) +
                                        Convert.ToInt16(ENewsletter ? WebsiteFunctionality.ENewsletter : WebsiteFunctionality.None) +
                                        Convert.ToInt16(Blog ? WebsiteFunctionality.Blog : WebsiteFunctionality.None) +
                                        Convert.ToInt16(ContactForm ? WebsiteFunctionality.ContactForm : WebsiteFunctionality.None) +
                                        Convert.ToInt16(ContentManagementSystem ? WebsiteFunctionality.ContentManagementSystem : WebsiteFunctionality.None) +
                                        Convert.ToInt16(SocialMediaSharing ? WebsiteFunctionality.SocialMediaSharing : WebsiteFunctionality.None) +
                                        Convert.ToInt16(ThirdPartyPlugins ? WebsiteFunctionality.ThirdPartyPlugins : WebsiteFunctionality.None);

            _responsiveDevicesMask = Convert.ToInt16(Phone ? ResponsiveDevices.Phone : ResponsiveDevices.None) +
                                     Convert.ToInt16(Tablet ? ResponsiveDevices.Tablet : ResponsiveDevices.None) +
                                     Convert.ToInt16(Desktop ? ResponsiveDevices.Desktop : ResponsiveDevices.None) +
                                     Convert.ToInt16(Laptop ? ResponsiveDevices.Laptop : ResponsiveDevices.None);
        }

        private async void Save()
        {
            Bitmask();

            IsBusy = true;

            IsGridBusy = false;

            if (string.IsNullOrEmpty(PlanningItemViewModel.OtherFunctionality))
            {
                PlanningItemViewModel.OtherFunctionality = "none";
            }

            if (string.IsNullOrEmpty(PlanningItemViewModel.AdditionalServicesRequired))
            {
                PlanningItemViewModel.AdditionalServicesRequired = "none";
            }

            PlanningItemViewModel.WebsiteFunctionalityMask = _websiteFunctionalityMask;
            PlanningItemViewModel.ResponsiveDevicesMask = _responsiveDevicesMask;

            PlanningItemViewModel.NumberOfDlc = Convert.ToDouble(string.Format("{0:F0}", PlanningItemViewModel.NumberOfDlc));
            PlanningItemViewModel.NumberOfPages = Convert.ToDouble(string.Format("{0:F0}", PlanningItemViewModel.NumberOfPages));
            PlanningItemViewModel.NumberOfPhotos = Convert.ToDouble(string.Format("{0:F0}", PlanningItemViewModel.NumberOfPhotos));

            try
            {
                HttpClient client = new HttpClient();

                string url = "http://api.41stdegree.com/api/planning";

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Converters.Add(new JsonDoubleToIntConverter());
                settings.Formatting = Formatting.Indented;

                string p = JsonConvert.SerializeObject(PlanningItemViewModel, settings);

                HttpResponseMessage response = await client.PostAsync(url, new StringContent(p, Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                PlanningItemModel info = JsonConvert.DeserializeObject<PlanningItemModel>(responseBody);

                IsBusy = false;

                IsGridBusy = true;

                Message = "saved successfully";

                if (PlanningItemViewModel.OtherFunctionality == "none")
                {
                    PlanningItemViewModel.OtherFunctionality = null;
                }

                if (PlanningItemViewModel.AdditionalServicesRequired == "none")
                {
                    PlanningItemViewModel.AdditionalServicesRequired = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                IsBusy = false;

                IsGridBusy = true;

                Message = "failed to save";

                if (PlanningItemViewModel.OtherFunctionality == "none")
                {
                    PlanningItemViewModel.OtherFunctionality = null;
                }

                if (PlanningItemViewModel.AdditionalServicesRequired == "none")
                {
                    PlanningItemViewModel.AdditionalServicesRequired = null;
                }
            }
        }

        private void Clear()
        {           
            PlanningItemViewModel = new PlanningItemModel();

            HorizontalNavigation = false;

            HorizontalNavigation = false;

            VerticalNavigation = false;

            PhotoGallery = false;

            VideoGallery = false;

            ENewsletter = false;

            Blog = false;

            ContactForm = false;

            ContentManagementSystem = false;

            SocialMediaSharing = false;

            ThirdPartyPlugins = false;

            Phone = false;

            Tablet = false;

            Desktop = false;

            Laptop = false;

            Message = null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
