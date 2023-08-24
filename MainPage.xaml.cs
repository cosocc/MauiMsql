using System.Collections.ObjectModel;
using System.ComponentModel;
using MauiMsql.DataBases;


namespace MauiMsql
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private static AccountRepository context;
        public ObservableCollection<Admin> Adminsbind { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Adminsbind = new ObservableCollection<Admin>();
            context = new AccountRepository();
            var admins = context.Admins.ToList(); // Assuming GetAdmins() is a method that retrieves admins from the database
            foreach (var admin in admins)
            {
                Adminsbind.Add(admin);
                System.Diagnostics.Debug.WriteLine($"Name: {admin.f_name}, Pass: {admin.f_pass}, Prior: {admin.f_prior}");
            }

            BindingContext = this;
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        protected override void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedAdmin = (Admin)e.SelectedItem;
            //System.Diagnostics.Debug.WriteLine($"Name:{nameof(selectedName)},Type of context: {selectedName.GetType()}");

            var selectedName = selectedAdmin.f_name;
            var selectedpass = selectedAdmin.f_pass;
            var selectedprior = selectedAdmin.f_prior;
            //var selectedBackAdmin = await context.GetAdminByNameAsync(selectedName);

            //if (selectedBackAdmin != null)
            //{
            //    var password = selectedBackAdmin.f_pass;
            //    // Do something with the password
            //}


            if (!string.IsNullOrEmpty(selectedpass))
            {
                // Do something with the password
                System.Diagnostics.Debug.WriteLine($"Selected admin name: {selectedName}, Password: {selectedpass}");
            }
          ((ListView)sender).SelectedItem = null; // Clear selection
        }

    }
}




